using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Cake cake, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Cake.CakeId == cake.CakeId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Cake = cake,
                    Quantity = quantity
                });
            }
            else
            {
                if ((line.Quantity + 1) <= line.Cake.Quantity)
                {
                    line.Quantity += quantity;
                }
                else
                {
                    HttpContext.Current.Response.Write("<SCRIPT>alert('На складе только " + line.Quantity.ToString() + " позиций " + line.Cake.Name.ToString() + "')</SCRIPT>");
                }
            }
        }

        public void DelItem(Cake cake, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Cake.CakeId == cake.CakeId)
                .FirstOrDefault();
            if ((line.Quantity - 1) > 0)
            {
                line.Quantity--;
            }
            else
            {
                RemoveLine(cake);
            }
        }

        public void RemoveLine(Cake cake)
        {
            lineCollection.RemoveAll(l => l.Cake.CakeId == cake.CakeId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Cake.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Cake Cake { get; set; }
        public int Quantity { get; set; }
    }
}