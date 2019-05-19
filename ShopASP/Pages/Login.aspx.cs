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
    public partial class Login : System.Web.UI.Page
    {
        Repository rep = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = SessionHelper.GetUser(Session);
            User.UserList temp = new User.UserList();

            ClearTable.Visible = false;

            if (myUser.getCurUser.UserID == temp.UserID)
            {
                LoginForm.Visible = true;
                PersonalArea.Visible = false;
                csLinkRegister.HRef = RouteTable.Routes.GetVirtualPath(null, "register",
                    null).VirtualPath;
                if (IsPostBack)
                {
                    Repository repository = new Repository();

                    myUser.Login(Name.Value.ToString(), Password.Value.ToString());

                    if (myUser.getCurUser.UserID == temp.UserID)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Такого пользователя не существует! Проверьте правильность введенных данных!');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Добро пожаловать!');", true);
                        LoginForm.Visible = false;
                        PersonalArea.Visible = true;
                    }
                }
                
            }
            else
            {
                LoginForm.Visible = false;
                PersonalArea.Visible = true;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            User myUser = SessionHelper.GetUser(Session);
            IEnumerable<Order> orders = rep.Orders;
            if (rep.getFlag == "")
            {
                Order line = orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name)
                    .FirstOrDefault();
                if (line == null)
                {
                    ClearTable.Visible = true;
                }
                else
                {
                    ClearTable.Visible = false;
                }

                return orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name);
            }
            if (rep.getFlag == "New")
            {
                Order line = orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                x.Status == "В обработке")
                    .FirstOrDefault();
                if (line == null)
                {
                    ClearTable.Visible = true;
                }
                else
                {
                    ClearTable.Visible = false;
                }

                return orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                x.Status == "В обработке");
            }
            if (rep.getFlag == "Deliver")
            {
                Order line = orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                x.Status == "В доставке")
                    .FirstOrDefault();
                if (line == null)
                {
                    ClearTable.Visible = true;
                }
                else
                {
                    ClearTable.Visible = false;
                }

                return orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                x.Status == "В доставке");
            }
            if (rep.getFlag == "Ready")
            {
                Order line = orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                (x.Status == "Получен" ||
                                x.Status == "Отменен"))
                    .FirstOrDefault();
                if (line == null)
                {
                    ClearTable.Visible = true;
                }
                else
                {
                    ClearTable.Visible = false;
                }

                return orders
                    .Where(x => x.Name == myUser.getCurUser.User_Name &&
                                (x.Status == "Получен" ||
                                x.Status == "Отменен"));
            }
            else
            {
                IEnumerable<Order> temp = new List<Order>();
                return temp;
            }
        }

        public decimal Total(IEnumerable<Order.OrderLine> orderLines)
        {
            decimal result = 0;

            foreach (Order.OrderLine line in orderLines)
            {
                result += (line.Quantity * line.Cake.Price);
            }

            return result;
        }

        protected void AllOrders_ServerClick(object sender, EventArgs e)
        {
            rep.setFlag("");

            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void NewOrders_ServerClick(object sender, EventArgs e)
        {
            rep.setFlag("New");

            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void DeliverOrders_ServerClick(object sender, EventArgs e)
        {
            rep.setFlag("Deliver");

            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void ReadyOrders_ServerClick(object sender, EventArgs e)
        {
            rep.setFlag("Ready");

            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        public string ReturnUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "list",
                     null).VirtualPath;
            }
        }
    }
}