using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class CookieManager
    {
        public static List<CartItems> GetCookie()
        {
            try
            {
                List<CartItems> cartItems = new List<CartItems>();

                var cookie = "Id=" + HttpContext.Current.Request.Cookies["Id"].Value;

                string[] items = cookie.Split('|');

                for (int i = 0; i < items.Length - 1; i++)
                {
                    int indexPrice = items[i].IndexOf('P');
                    int indexTime = items[i].IndexOf('T');
                    string id = items[i].Substring(0, indexPrice);
                    string price = items[i].Substring(indexPrice, indexTime - 4);
                    string time = items[i].Substring(indexTime);
                    time = time.Substring(5);
                    price = price.Substring(6);
                    id = id.Substring(3);

                    cartItems.Add(new CartItems { Id = id, Price = price, Time = time });
                }
                return cartItems;
            }
            catch
            {
                return null;
            }
        }
    }
}