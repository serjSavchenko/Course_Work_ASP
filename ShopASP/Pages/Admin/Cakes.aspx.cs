using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Routing;
using System.Web.UI.WebControls;
using ShopASP.Models;
using ShopASP.Models.Repository;
using System.Web.ModelBinding;

namespace ShopASP.Pages.Admin
{
    public partial class Cakes : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Cake> GetCakes()
        {
            return repository.Cakes;
        }

        public void UpdateCake(int CakeID)
        {
            Cake myCake = repository.Cakes
                .Where(p => p.CakeId == CakeID).FirstOrDefault();
            IEnumerable<Order> orders = repository.Orders
                .Where(o => o.Status != "Получен" || o.Status != "Отменен");
            Order.OrderLine line = new Order.OrderLine();

            foreach (Order order in orders)
            {
                line = new Order.OrderLine();
                if (line.Order == 0)
                {
                    line = order.OrderLines.Where(ol => ol.Cake.CakeId == CakeID).FirstOrDefault();
                    if (line != null) { if (line.Order != 0) break; }
                    
                }
            }

            if (line == null || line.Order == 0)
            {
                if (myCake != null && TryUpdateModel(myCake,
                    new FormValueProvider(ModelBindingExecutionContext)))
                {
                    repository.saveCake(myCake);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Сохранено!');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Товар невозможно изменить так как есть не закрытые заказы с ним! Попробуйте позже!');", true);
            }
        }

        public void DeleteCake(int CakeID)
        {
            Cake myCake = repository.Cakes
                .Where(p => p.CakeId == CakeID).FirstOrDefault();
            IEnumerable<Order> orders = repository.Orders
                .Where(o => o.Status != "Получен" || o.Status != "Отменен");
            Order.OrderLine line = new Order.OrderLine();

            foreach (Order order in orders)
            {
                line = new Order.OrderLine();
                if (line.Order == 0)
                {
                    line = order.OrderLines.Where(ol => ol.Cake.CakeId == CakeID).FirstOrDefault();
                    if (line != null) { if (line.Order != 0) break; }

                }
            }

            if (line == null || line.Order == 0)
            {
                if (myCake != null)
                {
                    repository.delCake(myCake);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Удалено!');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Товар невозможно удалить так как есть не закрытые заказы с ним! Попробуйте позже!');", true);
            }
        }

        public void InsertCake()
        {
            Cake myCake = new Cake();
            if (TryUpdateModel(myCake,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.saveCake(myCake);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Доабвлено!');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Проверьте правильность введенных данных! Возможно вы ввели цену с \".\", а не с \",\"!');", true);
            }
        }
    }
}