using System;
using System.Collections.Generic;
using Bondora_HomeTask.Controllers;
using Bondora_HomeTask.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bondora_HomeTask.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RentHeavyProduct()
        {
            var price = PriceCalculation.EquipmentPrice(Types.Heavy, 5);
            Assert.AreEqual(400, price);
        }

        [TestMethod]
        public void ProductName()
        {
            var controller = new EquipmentController();
            string name = controller.equipment[2].Name;
            Assert.AreEqual("Komatsu crane", name);
        } 
    }
}
