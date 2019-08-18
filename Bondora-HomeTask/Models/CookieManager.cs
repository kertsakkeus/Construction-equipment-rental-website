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
            List<CartItems> cartItems = new List<CartItems>();

            var xd = "Id=" + HttpContext.Current.Request.Cookies["Id"].Value;

            string[] items = xd.Split('|');

            for (int i = 0; i < items.Length - 1; i++)
            {
                int index = items[i].IndexOf('P');
                string id = items[i].Substring(0, index);
                string price = items[i].Substring(index);
                price = price.Substring(6);
                id = id.Substring(3);

                cartItems.Add(new CartItems { Id = id, Price = price });
            }
            return cartItems;
        }
    }
}