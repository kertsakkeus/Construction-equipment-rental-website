using Bondora_HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bondora_HomeTask.Controllers
{
    public class WebController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string items = await ApiRequests.GetAllEquipment();

            ViewBag.equipment = items;

            string[] cartItems = await ApiRequests.GetCartItems();

            ViewBag.cart_num = cartItems[1];
            ViewBag.cart_price = cartItems[2];

            return View();
        }

        public async Task<ActionResult> Product(int id)
        {
            List<string> ProductInfo = new List<string>();

            ProductInfo = await ApiRequests.GetProduct(id);

            ViewBag.product_name = ProductInfo[0];
            ViewBag.product_type = ProductInfo[1];
            ViewBag.product_image = ProductInfo[2];

            string[] cartItems = await ApiRequests.GetCartItems();

            ViewBag.cart_num = cartItems[1];
            ViewBag.cart_price = cartItems[2];

            return View();
        }

        public async Task<ActionResult> Cart()
        {
            string[] cartItems = await ApiRequests.GetCartItems();

            ViewBag.cartItems = cartItems[0];
            ViewBag.cart_num = cartItems[1];
            ViewBag.cart_price = cartItems[2];
            ViewBag.cart_item = cartItems[3];

            return View();
        }

        public async Task<ActionResult> Checkout()
        {
            string[] cartItems = await ApiRequests.GetCartItems();

            ViewBag.cart_num = cartItems[1];
            ViewBag.cart_price = cartItems[2];
            ViewBag.cart_item = cartItems[3];

            return View();
        }

        public async Task<ActionResult> Invoice(string name, string last_name, string country, string address, string zipcode, string city, string province, string phone, string email)
        {
            string url = HttpContext.Request.Url.AbsoluteUri;

            if (!url.Contains("?"))
            {
                return View("Error");
            }

            DateTime today = DateTime.Today;
            string date = today.ToString();
            string due_date;

            date = date.Substring(0, date.Length - 9);

            due_date = today.AddDays(5).ToString();
            due_date = due_date.Substring(0, due_date.Length - 9);

            string[] cartItems = await ApiRequests.GetCartItems();

            ViewBag.name = name + " " + last_name;
            ViewBag.address = address + ", " + zipcode + " " + city + ", " + province + ", " + country;
            ViewBag.email = email;
            ViewBag.phone = phone;
            ViewBag.date = date;
            ViewBag.due_date = due_date;
            ViewBag.cart_price = cartItems[2];
            ViewBag.cart_items = cartItems[4];

            return View();
        }
    }
}
