using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopASP.Models;
using ShopASP.Pages.Helpers;

namespace ShopASP.Controls
{
    public partial class LoginUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = SessionHelper.GetUser(Session);
            User.UserList temp = new User.UserList();
            myUser.Login("Oleg", "12345");
            if (myUser.getCurUser.UserID != temp.UserID)
            {
                csLinkLogin.InnerText = myUser.getCurUser.User_Name.ToString();
                csLinkRegister.InnerText = "Выход";
                csLinkLogin.HRef = RouteTable.Routes.GetVirtualPath(null, "login",
                null).VirtualPath;
                csLinkRegister.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
            }
            else
            {
                csLinkLogin.InnerText = "Вход";
                csLinkRegister.InnerText = "Регистрация";
                csLinkLogin.HRef = RouteTable.Routes.GetVirtualPath(null, "login",
                null).VirtualPath;
                csLinkRegister.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
            }
        }
    }
}