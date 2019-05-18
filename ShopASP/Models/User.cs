using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class User
    {
        private ClassDataBase db = new ClassDataBase();
        private ClassSetupProgram stp = new ClassSetupProgram();

        private List<UserList> listUsers = new List<UserList>();
        private UserList loginedUser = new UserList();
        

        public void Login(string Name, string pass)
        {
            db.Execute<UserList>(ref stp, "SELECT * FROM cake.users;", ref listUsers);

            UserList line = listUsers
                .Where(u => u.User_Name == Name)
                .FirstOrDefault();

            if (line != null)
            {
                if (line.getPass == pass)
                {
                    loginedUser = line;
                }
            }
        }

        public void OutLogin()
        {
            if (loginedUser != new UserList())
            {
                loginedUser = new UserList();
            }
        }


        public UserList getCurUser
        {
            get
            {
                return loginedUser;
            }
        }

        public class UserList
        {
            public int UserID { get; set; }
            public string User_Name { get; set; }
            private string User_Password { get; set; }
            public string Permission { get; set; }

            public UserList()
            {
                UserID = 0;
                User_Name = "";
                User_Password = "";
                Permission = "";
            }

            public UserList(string info)
            {
                if (info != null && info != "")
                {
                    string[] val = info.Split('!');
                    UserID = Convert.ToInt32(val[0]);
                    User_Name = val[1];
                    User_Password = val[2];
                    Permission = val[3];
                }
            }

            public string getPass
            {
                get
                {
                    return User_Password;
                }
            }
        }
    }
}