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
    public class StepConverterTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestEmptyConversion()
        {
            StepRequestModel stepReqModel = new StepRequestModel();

            Step steppie = StepRequestModelConverter.ConvertReqModelToDataModel(stepReqModel);

            Assert.Null(steppie.CoverImage);
            Assert.Null(steppie.Description);
            Assert.AreEqual(steppie.Id, Guid.Empty);
            Assert.Null(steppie.Solution);
        }

        [Test]
        public void TestPopulatedConversion()
        {
            StepRequestModel stepReqModel = new StepRequestModel()
            {
                CoverImage = "image.png",
                Description = "leuke stap"
            };

            Step steppie = StepRequestModelConverter.ConvertReqModelToDataModel(stepReqModel);

            Assert.AreEqual("image.png", steppie.CoverImage);
            Assert.AreEqual("leuke stap", steppie.Description);
            Assert.AreEqual(steppie.Id, Guid.Empty);
            Assert.Null(steppie.Solution);
        }
    }
}
