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
    public class HowToConverterTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestEmptyConversion()
        {
            HowToRequestModel reqModel = new HowToRequestModel();

            HowTo dataModel = HowToRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.Null(dataModel.Name);
            Assert.Null(dataModel.Description);
            Assert.Null(dataModel.Difficulty);
            Assert.Null(dataModel.Introduction);
            Assert.Null(dataModel.HeaderImageURL);
            Assert.Null(dataModel.WeatherExtreme);
            Assert.AreEqual(Guid.Empty, dataModel.AuthorId);

            Assert.AreEqual(0, reqModel.Materials.Count);
            Assert.AreEqual(0, reqModel.Tools.Count);
            Assert.AreEqual(0, reqModel.SDGIds.Count);
            Assert.AreEqual(0, reqModel.Steps.Count);
        }

        [Test]
        public void TestPopulatedConversion()
        {
            HowToRequestModel reqModel = new HowToRequestModel()
            {
                Name = "De How To",
                WeatherExtreme = "regen",
                Description = "omschrijving",
                Difficulty = "makkelijk",
                Introduction = "Hallo Wereld",
                HeaderImageUrl = "image.png",
                AuthorId = Guid.NewGuid(),

                Materials = { "materiaal", "materiaal 2" },
                Tools = { "hamer", "sikkel" },
                SDGIds = { Guid.NewGuid(), Guid.NewGuid() },
                Steps = { new StepRequestModel(), new StepRequestModel() }
            };

            HowTo howTo = HowToRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.AreEqual("De How To", howTo.Name);
            Assert.AreEqual("regen", howTo.WeatherExtreme);
            Assert.AreEqual("omschrijving", howTo.Description);
            Assert.AreEqual("makkelijk", howTo.Difficulty);
            Assert.AreEqual("Hallo Wereld", howTo.Introduction);
            Assert.AreEqual("image.png", howTo.HeaderImageURL);
            Assert.NotNull(howTo.AuthorId);

            Assert.AreEqual(2, howTo.Materials.Count);
            Assert.AreEqual(2, howTo.Tools.Count);
            Assert.AreEqual(2, howTo.SDGs.Count);
            Assert.AreEqual(2, howTo.Steps.Count);

            Assert.True(DateTime.Now > howTo.UploadDate);
            Assert.True(DateTime.Now > howTo.LastUpdatedTime);

            Assert.AreEqual(0, howTo.ViewCount);
        }
    }
}
