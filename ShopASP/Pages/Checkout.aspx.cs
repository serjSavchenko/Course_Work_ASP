using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using ShopASP.Models;
using ShopASP.Models.Repository;
using ShopASP.Pages.Helpers;

namespace ShopASP.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order myOrder = new Order();
                if (TryUpdateModel(myOrder,
                   new FormValueProvider(ModelBindingExecutionContext)))
                {
                    if (Name.Value.ToString().Trim() != "" && Line1.Value.ToString().Trim() != "" && Line2.Value.ToString().Trim() != "" && Line3.Value.ToString().Trim() != "" && City.Value.ToString().Trim() != "")
                    {
                        myOrder.Name = Name.Value;
                        myOrder.Line1 = Line1.Value;
                        myOrder.Line2 = Line2.Value;
                        myOrder.Line3 = Line3.Value;
                        myOrder.City = City.Value;

                        myOrder.OrderLines = new List<Order.OrderLine>();

                        Cart myCart = SessionHelper.GetCart(Session);

                        foreach (CartLine line in myCart.Lines)
                        {
                            myOrder.OrderLines.Add(new Order.OrderLine(line.Quantity, line.Cake, myOrder.OrderId));
                        }

                        new Repository().SaveOrder(myOrder);
                        myCart.Clear();

                        checkoutForm.Visible = false;
                        checkoutMessage.Visible = true;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Один из полей заполнен не верно, либо пробелами!');", true);
                    }
                }
            }
        }
    }
}