using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopASP.Pages.Helpers;
using ShopASP.Models.Repository;

namespace ShopASP.Pages
{
    public partial class Listing : System.Web.UI.Page
    {

        private Repository repository = new Repository();
        private int pageSize = 5;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterCakes().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }



        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Models.Cake> GetCakes()
        {
            return FilterCakes()
                .OrderBy(c => c.CakeId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }


        private IEnumerable<Models.Cake> FilterCakes()
        {
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];

            return currentCategory == null ? repository.Cakes :
                repository.Cakes
                    .Where(p => p.Category == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedCakeId;
                if (int.TryParse(Request.Form["add"], out selectedCakeId))
                {
                    Models.Cake selectedCake = repository.Cakes
                        .Where(g => g.CakeId == selectedCakeId).FirstOrDefault();

                    if (selectedCake != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedCake, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);
                    }
                }
            }
        }
    }
}