using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class MaterialTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            Material mat = new Material()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Solution = new HowTo()
            };

            Assert.NotNull(mat.Id);
            Assert.AreEqual("Test", mat.Name);
            Assert.NotNull(mat.Solution);
        }
    }
}
