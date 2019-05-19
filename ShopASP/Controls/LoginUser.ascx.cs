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
            csLinkRegister.InnerText = "Регистрация";
            //myUser.Login("Oleg", "12345");
            if (myUser.getCurUser.UserID != temp.UserID)
            {
                csLinkLogin.InnerText = myUser.getCurUser.User_Name.ToString();
                csLinkLogin.HRef = RouteTable.Routes.GetVirtualPath(null, "login",
                null).VirtualPath;
                ButtonExit.Visible = true;
                csLinkRegister.Visible = false;
            }
            else
            {
                ButtonExit.Visible = false;
                csLinkRegister.Visible = true;
                csLinkLogin.InnerText = "Вход";
                csLinkLogin.HRef = RouteTable.Routes.GetVirtualPath(null, "login",
                null).VirtualPath;
                csLinkRegister.HRef = RouteTable.Routes.GetVirtualPath(null, "register",
                null).VirtualPath;
            }
        }

        protected void ButtonExit_ServerClick(object sender, EventArgs e)
        {
            User myUser = SessionHelper.GetUser(Session);
            myUser.OutLogin();
            Response.Redirect(Request.RawUrl);
        }
    }
}