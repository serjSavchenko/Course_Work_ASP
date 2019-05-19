using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using ShopASP.Models;
using ShopASP.Models.Repository;
using ShopASP.Pages.Helpers;


namespace ShopASP.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Welcome.Visible = false;
            LoginForm.Visible = false;
            ifRegister.Visible = false;

            User myUser = SessionHelper.GetUser(Session);
            Repository repos = new Repository();
            User.UserList temp = new User.UserList();

            IEnumerable<User.UserList> listOfUsers = repos.Users;


            if (myUser.getCurUser.UserID == temp.UserID)
            {
                Welcome.Visible = false;
                LoginForm.Visible = true;
            }
            else
            {
                ifRegister.Visible = true;
                Welcome.Visible = false;
                LoginForm.Visible = false;
            }
            if (IsPostBack)
            {
                if (Name.Value.Trim().ToString() != "" && Password.Value.Trim().ToString() != "")
                {
                    if (Password.Value.ToString().Length >= 8)
                    {
                        Models.User.UserList line = listOfUsers
                            .Where(us => us.User_Name == Name.Value.ToString())
                            .FirstOrDefault();
                        if (line == null)
                        {
                            //repos.RegisterUser(Name.Value.ToString(), Password.Value.ToString());
                            ifRegister.Visible = false;
                            Welcome.Visible = true;
                            LoginForm.Visible = false;
                            //Response.Redirect("login");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "alert('Такой логин уже существует!');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myscript", "alert('Пароль должен состоять как минимум из 8 символов!');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),"myscript","alert('Введите корректные данные!');",true);
                }
            }
        }
    }
}