using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class Cake
    {
        public int CakeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SpoiledDate { get; set; }
        public int Quantity { get; set; }
        public Cake()
        {
            CakeId = 0;
            Name = "";
            Description = "";
            Category = "";
            Price = 0;
            CreateDate = DateTime.Now;
            SpoiledDate = DateTime.Now.AddDays(1);
            Quantity = 0;
        }
        public Cake(string info)
        {
            if (info != null && info != "")
            {
                string[] val = info.Split('!');
                CakeId = Convert.ToInt32(val[0]);
                Name = val[1];
                Description = val[2];
                Category = val[3];
                Price = Convert.ToDecimal(val[4]);
                CreateDate = Convert.ToDateTime(val[5]);
                SpoiledDate = Convert.ToDateTime(val[6]);
                Quantity = Convert.ToInt32(val[7]);
            }
        }
    }
}