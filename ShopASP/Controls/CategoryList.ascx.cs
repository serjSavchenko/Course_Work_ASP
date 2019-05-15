using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using ShopASP.Models.Repository;

namespace ShopASP.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {

        public IEnumerable<string> GetCategories()
        {
            return new Repository().Cakes
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x);
        }

        public string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<a href='{0}'>Главная</a>", path);
        }

        public string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"]
                ?? Request.QueryString["category"];

            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "category", category },
                    {"page", "1"} }).VirtualPath;

            return string.Format("<a href='{0}' {1}>{2}</a>",
                path, category == selectedCategory ? "class='selected'" : "", category);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}