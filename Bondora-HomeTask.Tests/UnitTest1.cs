using System;
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
            var xd = PriceCalculation.EquipmentPrice(Types.Heavy, 5);
            Assert.AreEqual(400, xd);
        }
    }
}
