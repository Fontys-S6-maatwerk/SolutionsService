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
    public class ArticleConverterTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EmptyConversion()
        {
            ArticleRequestModel reqModel = new ArticleRequestModel();

            Article dataModel = ArticleRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.Null(dataModel.Name);
            Assert.Null(dataModel.Description);
            Assert.Null(dataModel.HeaderImageURL);
            Assert.Null(dataModel.WeatherExtreme);
            Assert.Null(dataModel.Content);
            Assert.AreEqual(Guid.Empty, dataModel.AuthorId);
        }

        [Test]
        public void PopulatedConversion()
        {
            ArticleRequestModel reqModel = new ArticleRequestModel()
            {
                Name = "naam",
                Description = "omschrijving",
                HeaderImageUrl = "image.png",
                WeatherExtreme = "regen",
                Content = "zo doe je die ding",
                AuthorId = Guid.NewGuid()
            };

            Article dataModel = ArticleRequestModelConverter.ConvertReqModelToDataModel(reqModel);

            Assert.AreEqual("naam", dataModel.Name);
            Assert.AreEqual("omschrijving", dataModel.Description);
            Assert.AreEqual("image.png", dataModel.HeaderImageURL);
            Assert.AreEqual("regen", dataModel.WeatherExtreme);
            Assert.AreEqual("zo doe je die ding", dataModel.Content);
            Assert.NotNull(dataModel.AuthorId);

            Assert.True(DateTime.Now > dataModel.UploadDate);
            Assert.True(DateTime.Now > dataModel.LastUpdatedTime);

            Assert.AreEqual(0, dataModel.ViewCount);
            Assert.AreEqual(0, dataModel.Likes.Count);
            Assert.AreEqual(0, dataModel.SDGs.Count);
        }
    }
}
