using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class ApiRequests
    {
        public static async Task<List<string>> GetProduct(int Id)
        {
            try
            {
                List<string> ProductInfo = new List<string>();

                var request = WebRequest.Create(new Uri("http://localhost:61388/api/equipment?id=" + Id.ToString())) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var responseStream = responseObject.GetResponseStream();
                var sr = new StreamReader(responseStream);
                string received = await sr.ReadToEndAsync();

                dynamic json = JObject.Parse(received);

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
    }
}