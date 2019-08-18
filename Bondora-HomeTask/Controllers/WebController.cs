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

            return View();
        }

        public async Task<ActionResult> Product(int id)
        {
            List<string> ProductInfo = new List<string>();

            ProductInfo = await ApiRequests.GetProduct(id);

            ViewBag.product_name = ProductInfo[0];
            ViewBag.product_type = ProductInfo[1];
            ViewBag.product_image = ProductInfo[2];

            return View();
        }

        public ActionResult Cart()
        {
            List<CartItems> cartItems = new List<CartItems>();

            cartItems = CookieManager.GetCookie();

            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}
