using System;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;

//namespace ShopASP.App_Start
namespace ShopASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            //Route Category
            routes.MapPageRoute(null, "list/{category}/{page}",
                                       "~/Pages/Listing.aspx");

            //Route Pages
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");

            //Main Route on Product list
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute("list", "list", "~/Pages/Listing.aspx");


            //Route for cart
            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");

            //Route for order
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");

            //Login Route
            routes.MapPageRoute("login", "login", "~/Pages/Login.aspx");
        }
    }
}