using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ShopASP.Models;

namespace ShopASP.Pages.Helpers
{
    public enum SessionKey
    {
        CART,
        USER,
        RETURN_URL
    }

    public static class SessionHelper
    {

        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }

        public static Cart GetCart(HttpSessionState session)
        {
            Cart myCart = Get<Cart>(session, SessionKey.CART);
            if (myCart == null)
            {
                myCart = new Cart();
                Set(session, SessionKey.CART, myCart);
            }
            return myCart;
        }

        public static User GetUser(HttpSessionState session)
        {
            User myUser = Get<User>(session, SessionKey.USER);
            if (myUser == null)
            {
                myUser = new User();
                Set(session, SessionKey.USER, myUser);
            }
            return myUser;
        }
    }
}