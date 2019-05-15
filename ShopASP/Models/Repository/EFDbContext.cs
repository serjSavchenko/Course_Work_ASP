using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ShopASP.Models.Repository
{
    public class EFDbContext
    {
        public ClassDataBase db = new ClassDataBase();
        public ClassSetupProgram stp = new ClassSetupProgram();
        public List<Cake> Cakes = new List<Cake>();
        public List<Order> Orders = new List<Order>();

        public List<Cake> getCakes() {

            Cakes.Clear();

            db.Execute<Cake>(ref stp, "SELECT * FROM `cake`.`cakes` where Quantity > 0;", ref Cakes);

            return Cakes;

        }


        public List<Order> getOrders()
        {
            Orders.Clear();

            db.Execute<Order>(ref stp, "SELECT * FROM Orders;", ref Orders);

            return Orders;
        }


        public void insertOrder(Order order)
        {
            Orders = getOrders();

            if (Orders.Exists(x => x.OrderId == order.OrderId))
            {

                int temp = (order.isCash == true) ? 1 : 0, counter = 0;
                Order tempOrder = Orders.Find(x => x.OrderId == order.OrderId);
                List<Order.OrderLine> tempLines = tempOrder.OrderLines;

                foreach (Order.OrderLine lines in order.OrderLines) {
                    if (lines != tempLines[counter])
                    {
                        db.ExecuteNonQuery(ref stp, "UPDATE `cake`.`orderlines` SET `Quantity` = '"+ lines.Quantity.ToString() +"', `Cake_CakeId` = '"+ lines.Cake.CakeId.ToString() +"', `Order_OrderId` = '" + lines.Order.ToString() + "' WHERE (`OrderLineId` = '" + lines.OrderLineId.ToString() +"');");

                        counter++;
                    }
                    else counter++;
                }


                db.ExecuteNonQuery(ref stp, "UPDATE `cake`.`Orders` SET `Name` = '"+ order.Name.ToString() +"', `Line1` = '"+ order.Line1.ToString() + "', `Line2` = '"+ order.Line2.ToString() + "', `Line3` = '"+ order.Line3.ToString() + "', `City` = '"+ order.City.ToString() +"', `isCash` = '"+ temp.ToString() + "', `Status` = '"+ order.Status.ToString() +"' WHERE (`OrderID` = '"+ order.OrderId.ToString() + "')");
            }
            else
            {
                List<Order.OrderLine> orderLines = new List<Order.OrderLine>();


                db.Execute<Order.OrderLine>(ref stp, "SELECT * FROM cake.orderlines;", ref orderLines);


                int linesCount = (orderLines.Count() > 0) ? orderLines[orderLines.Count() - 1].OrderLineId + 1 : 1;
                int orderCounter = (Orders.Count() > 0) ? Orders[Orders.Count() - 1].OrderId + 1 : 1;
                int temp = (order.isCash == true) ? 1 : 0;

                db.ExecuteNonQuery(ref stp, "INSERT INTO `cake`.`orders` (`OrderID`, `Name`, `Line1`, `Line2`, `Line3`, `City`, `isCash`, `Status`) VALUES ('" + orderCounter.ToString() + "', '" + order.Name.ToString() + "', '" + order.Line1.ToString() + "', '" + order.Line2.ToString() + "', '" + order.Line3.ToString() + "', '" + order.City.ToString() + "', '" + temp.ToString() + "', 'В обработке');");

                foreach (Order.OrderLine line in order.OrderLines)
                {
                    db.ExecuteNonQuery(ref stp, "INSERT INTO `cake`.`orderlines` (`OrderLineId`, `Quantity`, `Cake_CakeId`, `Order_OrderId`) VALUES ('" + linesCount.ToString() + "', '" + line.Quantity.ToString() + "', '" + line.Cake.CakeId.ToString() + "', '" + orderCounter.ToString() + "');");
                    db.ExecuteNonQuery(ref stp, "UPDATE `cake`.`cakes` SET `Quantity` = '"+ (line.Cake.Quantity - line.Quantity).ToString() +"' WHERE (`CakeId` = '"+ line.Cake.CakeId.ToString() +"');");
                    linesCount++;
                }

                            
            }
        }
    }
}