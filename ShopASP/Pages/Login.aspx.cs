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
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = SessionHelper.GetUser(Session);
            User.UserList temp = new User.UserList();

            if (myUser.getCurUser.UserID == temp.UserID)
            {
                LoginForm.Visible = true;
                PersonalArea.Visible = false;
                csLinkRegister.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
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
            Repository rep = new Repository();
            IEnumerable<Order> orders = rep.Orders;
            return orders
                .Where(x => x.Name == myUser.getCurUser.User_Name);
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
    }
}