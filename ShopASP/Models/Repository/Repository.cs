using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

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
    }
}