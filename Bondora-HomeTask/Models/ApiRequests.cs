using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Bondora_HomeTask.Models
{
    public class ApiRequests
    {
        static readonly string url = "http://localhost:61388/api/equipment";

        public static async Task<List<string>> GetProduct(int Id)
        {
            try
            {
                List<string> ProductInfo = new List<string>();

                dynamic json = JObject.Parse(await APIRequest("?id=" + Id.ToString()));

                string color = json.Type;

                string name = json.Name;
                string type = "<span style='color: " + TypeColorController.GetColor(color) + ";'>" + json.Type + "</span>";
                string image = "<img src=../Images/" + json.Image + ">";

                ProductInfo.Add(name);
                ProductInfo.Add(type);
                ProductInfo.Add(image);

                return ProductInfo;
            }
            catch
            {
                throw new HttpException(404, "Not Found");
            }
        }

        public static async Task<string> GetAllEquipment()
        {
            try
            {
                string htmlItems = "";

                var jsonArray = JArray.Parse(await APIRequest());
                int count = jsonArray.Count();

                List<Items> itemsList = jsonArray.ToObject<List<Items>>();

                for (int i = 0; i < count; i++)
                {
                    htmlItems = htmlItems + "<div class='product grid-item " + itemsList[i].Type.ToLower() + "'>" +
                    "<div class='product_inner'>" +
                        "<div class='product_image'>" +
                            "<a href = 'Product?id=" + itemsList[i].Id + "'>" +
                                "<img src = '../Images/" + itemsList[i].Image + "'>" +
                                "<div class='product_tag'>" + itemsList[i].Type + "</div>" +
                        "</div>" +
                        "<div class='product_content text-center'>" +
                            "<div class='product_title'><a href = 'Product?id=" + itemsList[i].Id + "'>" + itemsList[i].Name + "</a></div>" +
                            "<div class='product_price'>" + PriceCalculation.EquipmentPrice(itemsList[i].Type, 1) + "€" + "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>";
                }

                return htmlItems;
            }
            catch
            {
                throw new HttpException(404, "Not Found");
            }
        }

        public static async Task<string[]> GetCartItems()
        {
            try
            {
                List<CartItems> cartItemsList = new List<CartItems>();

                cartItemsList = CookieManager.GetCookie();

                string[] cartItems = new string[] { "", "0", "0€", "" };

                if (cartItemsList != null)
                {
                    var jsonArray = JArray.Parse(await APIRequest());
                    int count = jsonArray.Count();

                    List<Items> itemsList = jsonArray.ToObject<List<Items>>();

                    for (int j = 0; j < cartItemsList.Count; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (cartItemsList[j].Id == itemsList[i].Id)
                            {
                                cartItems[0] = cartItems[0] + "<li class='cart_item item_list d-flex flex-lg-row flex-column align-items-lg-center align-items-start justify-content-start'>" +
                        "<div class='product d-flex flex-lg-row flex-column align-items-lg-center align-items-start justify-content-start'>" +
                            "<div><div class='product_image'><img src = '../Images/" + itemsList[i].Image + "'></div></div>" +
                            "<div class='product_name'><a href = 'Product?id=" + itemsList[i].Id + "')'>" + itemsList[i].Name + "</a></div>" +
                        "</div>" +
                        "<div class='product_color_" + itemsList[i].Type.ToLower() + " text-lg-center product_text'>" + itemsList[i].Type + "</div>" +
                        "<div class='product_price text-lg-center product_text'>" + PriceCalculation.EquipmentPrice(itemsList[i].Type, 1) + "€" + "</div>" +
                        "<div class='product_time text-lg-center product_text'>" + TimeToDate.GetDate(Convert.ToInt32(cartItemsList[j].Time)) + "</div>" +
                        "<div class='product_total text-lg-center product_text'>" + cartItemsList[j].Price + "€" + "</div>" +
                    "</li>";

                                cartItems[3] = cartItems[3] + "<li class='d-flex flex-row align-items-center justify-content-start'>" +
                        "<div class='cart_extra_total_title'>" + itemsList[i].Name + " | " + TimeToDate.GetDate(Convert.ToInt32(cartItemsList[j].Time)) + "</div>" +
                        "<div class='cart_extra_total_value ml-auto'>" + cartItemsList[j].Price + "€" + "</div>" +
                    "</li>";

                            }
                        }
                    }
                    int totalPrice = 0;

                    for (int i = 0; i < cartItemsList.Count; i++)
                    {
                        totalPrice = totalPrice + Convert.ToInt32(cartItemsList[i].Price);
                    }

                    cartItems[1] = cartItemsList.Count.ToString();
                    cartItems[2] = totalPrice.ToString() + "€";

                    return cartItems;
                }
                return cartItems;
            }
            catch
            {
                throw new HttpException(404, "Not Found");
            }
        }

        public static async Task<List<InvoiceItems>> GetInvoiceInfo()
        {
            try
            {
                List<InvoiceItems> invoiceItems = new List<InvoiceItems>();
                List<CartItems> cartItemsList = new List<CartItems>();

                cartItemsList = CookieManager.GetCookie();

                if (cartItemsList != null)
                {
                    var jsonArray = JArray.Parse(await APIRequest());
                    int count = jsonArray.Count();

                    List<Items> itemsList = jsonArray.ToObject<List<Items>>();

                    for (int j = 0; j < cartItemsList.Count; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (cartItemsList[j].Id == itemsList[i].Id)
                            {
                                invoiceItems.Add(new InvoiceItems { Name = itemsList[i].Name, Price = cartItemsList[j].Price, Time = TimeToDate.GetDate(Convert.ToInt32(cartItemsList[j].Time)), Type = itemsList[i].Type });
                            }
                        }
                    }
                    return invoiceItems;
                }
                return null;
            }
            catch
            {
                throw new HttpException(404, "Not Found");
            }
        }

        public static async Task<string> APIRequest(string requestURL = "")
        {
            try
            {
                var request = WebRequest.Create(new Uri("http://localhost:61388/api/equipment" + requestURL)) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var responseStream = responseObject.GetResponseStream();
                var sr = new StreamReader(responseStream);
                string received = await sr.ReadToEndAsync();

                return received;
            }
            catch
            {
                throw new HttpException(404, "Not Found");
            }
        }
    }
}