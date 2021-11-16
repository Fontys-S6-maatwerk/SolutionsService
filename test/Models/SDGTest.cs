using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class SDGTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            SDG sdg = new SDG()
            {
                Id = Guid.NewGuid(),
                SDGNumber = 1,
                Name = "De meest belangrijke"
            };

            Assert.NotNull(sdg.Id);
            Assert.AreEqual(1, sdg.SDGNumber);
            Assert.AreEqual("De meest belangrijke", sdg.Name);
            Assert.NotNull(sdg.Solutions);
        }
    }
}
