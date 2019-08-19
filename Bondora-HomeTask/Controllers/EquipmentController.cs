using Bondora_HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bondora_HomeTask.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentController : ApiController
    {
        private Equipment[] equipment= new Equipment[]
        {
            new Equipment  { Id = 0, Name = "Caterpillar bulldozer", Type = Types.Regular, Image = "product_1.jpg"},
            new Equipment  { Id = 1, Name = "KamAZ truck", Type = Types.Regular, Image = "product_2.jpg" },
            new Equipment  { Id = 2, Name = "Komatsu crane", Type = Types.Heavy, Image = "product_3.jpg" },
            new Equipment  { Id = 3, Name = "Volvo steamroller", Type = Types.Regular, Image = "product_4.jpg" },
            new Equipment  { Id = 4, Name = "Bosch jackhammer", Type = Types.Specialized, Image = "product_5.jpg" },
            new Equipment  { Id = 5, Name = "Stella", Type = Types.Heavy, Image = "product_5.jpg" }
        };
        
        // GET: api/equipment
        public IEnumerable<Equipment> GetAllEquipment()
        {
            return equipment;
        }

        // GET: api/equipment?id=5
        public Equipment GetEquipment(int id)
        {
            var product = equipment.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        // GET: api/equipment?id=5&time=2
        public Equipment GetEquipmentPrice(int id, int time)
        {
            var product = equipment.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return null;
            }
            product.Price = PriceCalculation.EquipmentPrice(product.Type, time);
            return product;
        }
    }
}
