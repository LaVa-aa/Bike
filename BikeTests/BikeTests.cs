using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Tests
{
    [TestClass()]
    public class BikeTests
    {
        private Bike bike;
        [TestInitialize]
        public void SetUp()
        { 
            bike = new Bike(1, "Flower", "Star", 2000);
        }

        [TestMethod()]
        public void BikeTestName()
        {
            
            Assert.AreEqual("Flower", bike.Name);
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => bike.Name="nb"));
            Assert.ThrowsException<ArgumentNullException>((() => bike.Name = null));

        }

        [TestMethod()]
        public void BikeTestPrice()
        {
            Assert.AreEqual(2000, bike.Price);
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => bike.Price = 0));
        }

    }
}
