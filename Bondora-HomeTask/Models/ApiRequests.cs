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
                            "<a href = 'Web/Product?id=" + itemsList[i].Id + "'>" +
                                "<img src = '../Images/" + itemsList[i].Image + "'>" +
                                "<div class='product_tag'>" + itemsList[i].Type + "</div>" +
                        "</div>" +
                        "<div class='product_content text-center'>" +
                            "<div class='product_title'><a href = 'Web/Product?id=" + itemsList[i].Id + "'>" + itemsList[i].Name + "</a></div>" +
                            "<div class='product_price'>$0.00</div>" +
                            "<div class='product_button ml-auto mr-auto trans_200'><a href = '#' > add to cart</a></div>" +
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

        public static async Task<string> GetCartItems()
        {
            try
            {
                List<CartItems> cartItemsList = new List<CartItems>();

                string cartItems = "";

                var jsonArray = JArray.Parse(await APIRequest());
                int count = jsonArray.Count();

                List<Items> itemsList = jsonArray.ToObject<List<Items>>();

                for (int i = 0; i < count; i++)
                {
                    if (cartItemsList[i].Id == itemsList[i].Id)
                    {
                        cartItems = cartItems + "";
                    }
                }

                return cartItems;
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