using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopASP.Models;
using ShopASP.Models.Repository;
using ShopASP.Pages.Helpers;

namespace ShopASP.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int cakeId;
                if (int.TryParse(Request.Form["remove"], out cakeId))
                {
                    Cake cakeToRemove = repository.Cakes
                        .Where(g => g.CakeId == cakeId).FirstOrDefault();
                    if (cakeToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(cakeToRemove);
                    }
                }
                if (int.TryParse(Request.Form["addItem"], out cakeId))
                {
                    Cake cakeToAdd = repository.Cakes
                        .Where(g => g.CakeId == cakeId).FirstOrDefault();
                    if (cakeToAdd != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(cakeToAdd, 1);
                    }
                }
                if (int.TryParse(Request.Form["delItem"], out cakeId))
                {
                    Cake cakeToDel = repository.Cakes
                        .Where(g => g.CakeId == cakeId).FirstOrDefault();
                    if (cakeToDel != null)
                    {
                        SessionHelper.GetCart(Session).DelItem(cakeToDel, 1);
                    }
                }
            }
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "list",
                     null).VirtualPath;
            }
        }

        public string CheckoutUrl
        {
            get
            {
                List<CartLine> temp = (List<CartLine>)GetCartLines();
                if (temp.Count != 0)
                {
                    return RouteTable.Routes.GetVirtualPath(null, "checkout",
                        null).VirtualPath;
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Нет ни одной покупки!');", true);
                    return RouteTable.Routes.GetVirtualPath(null, "cart",
                        null).VirtualPath;
                }
            }
        }
    }
}