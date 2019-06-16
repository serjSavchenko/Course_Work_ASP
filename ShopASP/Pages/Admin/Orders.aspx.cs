using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Web.Routing;
using ShopASP.Models;
using ShopASP.Models.Repository;

namespace ShopASP.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int dispatchID;
                if (int.TryParse(Request.Form["dispatch"], out dispatchID))
                {
                    Order myOrder = repository.Orders.Where(o => o.OrderId == dispatchID).FirstOrDefault();
                    if (myOrder != null && myOrder.Status != "В доставке")
                    {
                        myOrder.Status = "В доставке";
                        repository.SaveOrder(myOrder);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Заказ уже в службе доставки!');", true);
                    }
                }
                if (int.TryParse(Request.Form["ready"], out dispatchID))
                {
                    Order myOrder = repository.Orders.Where(o => o.OrderId == dispatchID).FirstOrDefault();
                    if (myOrder != null && myOrder.Status != "Получен")
                    {
                        myOrder.Status = "Получен";
                        repository.SaveOrder(myOrder);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Заказ уже имеет статус полученного!');", true);
                    }
                }
                if (int.TryParse(Request.Form["getPositions"], out dispatchID))
                {
                    Order myOrder = repository.Orders.Where(o => o.OrderId == dispatchID).FirstOrDefault();
                    if (myOrder != null)
                    {
                        string resultForAlert = "";
                        foreach (Order.OrderLine ol in myOrder.OrderLines)
                        {
                            resultForAlert += ol.Cake.Name + " >>>> " + ol.Quantity.ToString() + "; ";
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + resultForAlert + "');", true);
                    }
                }
            }
        }

        public bool ifDispatch(int OrderID) {
            Order myOrder = repository.Orders.Where(o => o.OrderId == OrderID && o.Status == "В доставке").FirstOrDefault();
            if (myOrder != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ifReady(int OrderID)
        {
            Order myOrder = repository.Orders.Where(o => o.OrderId == OrderID && (o.Status == "Получен" || o.Status == "Отменен")).FirstOrDefault();
            if (myOrder != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Order> GetOrders([Control] bool showDispatched, [Control] bool showReady)
        {

            if (!showDispatched && !showReady)
            {
                return repository.Orders;
            }
            else if (showDispatched && !showReady)
            {
                return repository.Orders.Where(o => o.Status == "В доставке");
            }
            else if (!showDispatched && showReady)
            {
                return repository.Orders.Where(o => o.Status == "Получен");
            }
            else
            {
                return repository.Orders;
            }
        }

        public decimal Total(IEnumerable<Order.OrderLine> orderLines)
        {
            decimal total = 0;
            foreach (Order.OrderLine ol in orderLines)
            {
                total += ol.Cake.Price * ol.Quantity;
            }
            return total;
        }
    }
}