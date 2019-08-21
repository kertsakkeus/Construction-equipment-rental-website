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
        public void RentHeavyProductForFiveDays()
        {
            var price = PriceCalculation.EquipmentPrice(Types.Heavy, 5);
            Assert.AreEqual(400, price);
        }

        [TestMethod]
        public void RentRegularProductForNineDays()
        {
            var price = PriceCalculation.EquipmentPrice(Types.Regular, 9);
            Assert.AreEqual(500, price);
        }

        [TestMethod]
        public void RentSpezializedProductForTwoDays()
        {
            var price = PriceCalculation.EquipmentPrice(Types.Specialized, 2);
            Assert.AreEqual(120, price);
        }

        [TestMethod]
        public void CheckIfIdEqualsWithProductName()
        {
            var controller = new EquipmentController();
            string name = controller.equipment[2].Name;
            Assert.AreEqual("Komatsu crane", name);
        } 
    }
}
