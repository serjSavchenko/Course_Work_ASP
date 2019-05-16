using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShopASP.Models
{

    public class Order
    {
        ClassDataBase db = new ClassDataBase();
        ClassSetupProgram stp = new ClassSetupProgram();

        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public bool isCash { get; set; }
        public string Status { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public Order()
        {
            OrderId = 0;
            Name = "";
            Line1 = "";
            Line2 = "";
            Line3 = "";
            City = "";
            isCash = false;
            Status = "";
            OrderLines = new List<OrderLine>();
        }
        public Order(string info)
        {
            if (info != null && info != "")
            {
                string[] val = info.Split('!');
                OrderId = Convert.ToInt32(val[0]);
                Name = val[1];
                Line1 = val[2];
                Line2 = val[3];
                Line3 = val[4];
                City = val[5];
                if (Convert.ToInt32(val[6]) == 1)
                    isCash = true;
                else
                    isCash = false;
                Status = val[7];

                //----------------------------------------
                List<OrderLine> tempOrderLines = new List<OrderLine>();

                db.Execute<OrderLine>(ref stp, "SELECT * FROM cake.orderlines where Order_OrderId = " + val[0] + ";", ref tempOrderLines);

                OrderLines = tempOrderLines;
                //----------------------------------------
            }
        }



        public class OrderLine
        {

            ClassDataBase db = new ClassDataBase();
            ClassSetupProgram stp = new ClassSetupProgram();

            public int OrderLineId { get; set; }
            public int Quantity { get; set; }
            public Cake Cake { get; set; }
            public int Order { get; set; }

            public OrderLine(int quantity, Cake cake, int orderID)
            {
                OrderLineId = 0;
                Quantity = quantity;
                Cake = cake;
                Order = orderID;
            }

            public OrderLine(string info)
            {
                if (info != null && info != "")
                {
                    string[] val = info.Split('!');
                    OrderLineId = Convert.ToInt32(val[0]);
                    Quantity = Convert.ToInt32(val[1]);

                    //------------------------------------

                    List<Cake> tempCakes = new List<Cake>();
                    tempCakes.Clear();

                    db.Execute<Cake>(ref stp, "SELECT * FROM cake.cakes where CakeId = " + val[2] + ";", ref tempCakes);


                    if (tempCakes.Count > 0)
                    {
                        Cake = tempCakes[0];
                    }
                    else
                    {
                        Cake = new Cake();
                    }


                    //------------------------------------

                    Order = Convert.ToInt32(val[3]);
                }
            }

        }
    }
}