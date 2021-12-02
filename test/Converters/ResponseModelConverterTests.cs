using NUnit.Framework;
using SolutionsService.Models;
using SolutionsService.Models.ResponseModels;
using SolutionsService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Converters;

namespace SolutionsTest.Converters
{
    public class ResponseModelConverterTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PopulatedSDGTest()
        {
            SDG sdg = new SDG()
            {
                Id = Guid.NewGuid(),
                Name = "Honger",
                SDGNumber = 1
            };

            SDGResponse response = ResponseModelBuilder.BuildSDGResponse(sdg);

            Assert.AreEqual("Honger", response.Name);
            Assert.AreEqual(1, response.SDGNumber);
            Assert.AreEqual(sdg.Id, response.Id);
        }
    }
}
