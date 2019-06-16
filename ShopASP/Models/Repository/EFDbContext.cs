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
        public List<User.UserList> UserList = new List<User.UserList>();
        public List<Flag> FilterFlag = new List<Flag>();

        public string getFlag()
        {
            FilterFlag.Clear();
            db.Execute<Flag>(ref stp, "SELECT * FROM cake.testblob;", ref FilterFlag);
            return FilterFlag[0].FlagStatus;
        }

        public void SetFlag(string value)
        {
            db.ExecuteNonQuery(ref stp, "UPDATE `cake`.`testblob` SET `Content` = '"+ value +"' WHERE (`ID_Image` = '1');");
        }

        public List<Cake> getCakes() {

            Cakes.Clear();

            db.Execute<Cake>(ref stp, "SELECT * FROM `cake`.`cakes` where Quantity > 0;", ref Cakes);

            return Cakes;
        }

        public List<User.UserList> getUsers() {

            UserList.Clear();

            db.Execute<User.UserList>(ref stp, "SELECT * FROM cake.users;", ref UserList);

            return UserList;
        }

        public void insertUser(string User_Name, string User_Password, string User_Phone, string User_EMail)
        {
            UserList.Clear();

            db.Execute<User.UserList>(ref stp, "SELECT * FROM cake.users;", ref UserList);

            int userCount = (UserList.Count() > 0) ? UserList[UserList.Count() - 1].UserID + 1 : 1;
            User.UserList temp = UserList.Where(u => u.User_EMail == User_EMail).FirstOrDefault();


            if (temp == null)
            {
                db.ExecuteNonQuery(ref stp, "INSERT INTO `cake`.`users` (`User_ID`, `User_Name`, `User_Password`, `Permission`, `User_Phone`, `User_EMail`) VALUES ('" + userCount.ToString() + "', '" + User_Name + "', '" + User_Password + "', 'User', '" + User_Phone + "', '" + User_EMail + "');");
            }
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

        public void saveCake(Cake cake)
        {
            Cakes = getCakes();
            int multiplier = 100;
            decimal double_value = cake.Price;
            int double_result = (int)((double_value - (int)double_value) * multiplier);
            if (Cakes.Exists(c => c.CakeId == cake.CakeId))
            {
                db.ExecuteNonQuery(ref stp, "UPDATE `cake`.`cakes` SET `Name` = '" + cake.Name.ToString() + "', `Description` = '" + cake.Description.ToString() + "', `Category` = '" + cake.Category.ToString() + "', `Price` = '" + Math.Truncate(cake.Price).ToString() + '.' + double_result.ToString() + "', `CreateDate` = '" + cake.CreateDate.Year + '-' + cake.CreateDate.Month + '-' + cake.CreateDate.Day + ' ' + cake.CreateDate.ToString("HH:mm:ss") + "', `SpoiledDate` = '" + cake.SpoiledDate.Year + '-' + cake.SpoiledDate.Month + '-' + cake.SpoiledDate.Day + ' ' + cake.SpoiledDate.ToString("HH:mm:ss") + "', `Quantity` = '" + cake.Quantity.ToString() + "' WHERE (`CakeId` = '" + cake.CakeId.ToString() + "');");
            }
            else
            {
                int cakeCount = (Cakes.Count() > 0) ? Cakes[Cakes.Count() - 1].CakeId + 1 : 1;
                db.ExecuteNonQuery(ref stp, "INSERT INTO `cake`.`cakes` (`CakeId`, `Name`, `Description`, `Category`, `Price`, `CreateDate`, `SpoiledDate`, `Quantity`) VALUES ('"+ cakeCount.ToString() +"', '"+ cake.Name.ToString() +"', '"+ cake.Description.ToString() +"', '"+ cake.Category.ToString() +"', '"+ Math.Truncate(cake.Price).ToString() + '.' + double_result.ToString() + "', '"+ cake.CreateDate.Year + '-' + cake.CreateDate.Month + '-' + cake.CreateDate.Day + ' ' + cake.CreateDate.ToString("HH:mm:ss") + "', '"+ cake.SpoiledDate.Year + '-' + cake.SpoiledDate.Month + '-' + cake.SpoiledDate.Day + ' ' + cake.SpoiledDate.ToString("HH:mm:ss") + "', '"+ cake.Quantity.ToString() +"');");
            }
        }

        public void deleteCake(Cake cake)
        {
            Cakes = getCakes();
            if (Cakes.Exists(c => c.CakeId == cake.CakeId))
            {
                db.ExecuteNonQuery(ref stp, "DELETE FROM `cake`.`cakes` WHERE (`CakeId` = '"+ cake.CakeId.ToString() +"');");
            }
        }
    }
}