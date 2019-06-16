using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public string getFlag
        {
            get { return context.getFlag(); }
        }

        public void setFlag(string value)
        {
            context.SetFlag(value);
        }


        public List<Cake> Cakes
        {
            get { return context.getCakes(); } 
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.getOrders(); 
            }
        }

        public IEnumerable<User.UserList> Users
        {
            get
            {
                return context.getUsers();
            }
        }

        public void SaveOrder(Order order)
        {
            context.insertOrder(order);
        }

        public void RegisterUser(string Name, string Pass, string Phone, string EMail)
        {
            context.insertUser(Name, Pass, Phone, EMail);
        }

        public void saveCake(Cake cake)
        {
            context.saveCake(cake);
        }

        public void delCake(Cake cake)
        {
            context.deleteCake(cake);
        }
    }
}