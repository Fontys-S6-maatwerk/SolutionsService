using NUnit.Framework;
using SolutionsService.Models;
using SolutionsService.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolutionsService.Converters;

namespace SolutionsTest.Converters
{
    public class SDGConverterTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EmptyConversionTest()
        {
            SDGRequestModel reqModel = new SDGRequestModel();

            SDG dataModel = SDGRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.True(dataModel.Id == Guid.Empty);
            Assert.Null(dataModel.Name);
            Assert.True(dataModel.SDGNumber == 0);
            Assert.True(dataModel.Solutions.Count == 0);
        }

        [Test]
        public void PopulatedConversionTest()
        {
            SDGRequestModel reqModel = new SDGRequestModel()
            {
                Name = "Tegen Honger",
                SDGNumber = 1
            };

            SDG dataModel = SDGRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.True(dataModel.Id == Guid.Empty);
            Assert.AreEqual("Tegen Honger", dataModel.Name);
            Assert.AreEqual(1, dataModel.SDGNumber);
            Assert.True(dataModel.Solutions.Count == 0);
        }
    }
}
