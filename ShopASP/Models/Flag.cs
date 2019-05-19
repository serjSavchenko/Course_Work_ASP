using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class Flag
    {
        public string FlagStatus { get; set; }
        public Flag()
        {
            FlagStatus = "";
        }
        public Flag(string info)
        {
            if (info != null && info != "")
            {
                string[] val = info.Split('!');
                FlagStatus = val[1].Trim();
            }
        }
    }
}