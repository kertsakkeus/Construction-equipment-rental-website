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

        public async Task<ActionResult> Invoice(string name, string last_name, string country, string address, string zipcode, string city, string province, string phone, string email, string invoice)
        {
            string url = HttpContext.Request.Url.AbsoluteUri;
            string respond;
            string path = ControllerContext.HttpContext.Server.MapPath("");

            if (!url.Contains("?"))
            {
                return View("Error");
            }

            if (invoice == "true")
            {
                respond = await InvoiceFile.MakeInvoice(name, last_name, country, address, zipcode, city, province, phone, email, path);
            }
            else
            {
                respond = "Thank you for your purchase!";
            }

            ViewBag.respond = respond;

            return View();
        }
    }
}
