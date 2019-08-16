using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bondora_HomeTask.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int id)
        {
            ViewBag.product_name = "Kert";
            ViewBag.product_price = "50€";
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}
