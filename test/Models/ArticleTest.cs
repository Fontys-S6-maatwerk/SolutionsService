using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class ArticleTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            List<SDGSolution> sdgs = new List<SDGSolution>()
            {
                new SDGSolution(){
                    SDG = new SDG(){Id = Guid.NewGuid(), SDGNumber = 1, Name = "De eerste" },
                    SDGId = Guid.NewGuid()
                }
            };

            Article art = new Article()
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                Name = "Artikel 1",
                WeatherExtreme = "Regen",
                HeaderImageURL = "image.png",
                Description = "Omschrijving",
                UploadDate = DateTime.Now,
                LastUpdatedTime = DateTime.Now,
                Content = "de oplossing staat hier",
                ViewCount = 123,
                SDGs = sdgs
            };

            Assert.NotNull(art.Id);
            Assert.NotNull(art.AuthorId);
            Assert.IsTrue(art.Id != art.AuthorId);

            Assert.AreEqual("Artikel 1", art.Name);
            Assert.AreEqual("Regen", art.WeatherExtreme);
            Assert.AreEqual("image.png", art.HeaderImageURL);
            Assert.AreEqual("Omschrijving", art.Description);
            Assert.AreEqual(123, art.ViewCount);
            Assert.AreEqual("de oplossing staat hier", art.Content);

            Assert.IsTrue(art.UploadDate < DateTime.Now);
            Assert.IsTrue(art.LastUpdatedTime < DateTime.Now);

            Assert.NotNull(art.SDGs);
            Assert.NotNull(art.Likes);

            Assert.AreEqual(art.SDGs, sdgs);
        }
    }
}
