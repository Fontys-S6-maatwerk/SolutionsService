using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolutionsService.Models;

namespace SolutionsTest.Models
{
    public class HowToTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            List<SDG> sdgs = new List<SDG>()
            {
                new SDG(){Id = Guid.NewGuid(), SDGNumber = 1, Name = "De eerste" }
            };

            List<Material> materials = new List<Material>()
            {
                new Material(){ Id = Guid.NewGuid(), Name = "Materiaal"}
            };

            List<Tool> tools = new List<Tool>()
            {
                new Tool(){ Id = Guid.NewGuid(), Name = "Tool"}
            };

            List<Step> steps = new List<Step>()
            {
                new Step(){ Id = Guid.NewGuid(), CoverImage = "image.png", Description = "omschrijving van de stap"}
            };

            HowTo art = new HowTo()
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                Name = "Artikel 1",
                WeatherExtreme = "Regen",
                HeaderImageURL = "image.png",
                Description = "Omschrijving",
                UploadDate = DateTime.Now,
                LastUpdatedTime = DateTime.Now,
                ViewCount = 123,
                Introduction = "Intro",
                Difficulty = "makkelijk",
                SDGs = sdgs,
                Materials = materials,
                Tools = tools,
                Steps = steps
            };

            Assert.NotNull(art.Id);
            Assert.NotNull(art.AuthorId);
            Assert.IsTrue(art.Id != art.AuthorId);

            Assert.AreEqual("Artikel 1", art.Name);
            Assert.AreEqual("Regen", art.WeatherExtreme);
            Assert.AreEqual("image.png", art.HeaderImageURL);
            Assert.AreEqual("Omschrijving", art.Description);
            Assert.AreEqual("makkelijk", art.Difficulty);
            Assert.AreEqual("Intro", art.Introduction);
            Assert.AreEqual(123, art.ViewCount);

            Assert.IsTrue(art.UploadDate < DateTime.Now);
            Assert.IsTrue(art.LastUpdatedTime < DateTime.Now);

            Assert.NotNull(art.SDGs);
            Assert.NotNull(art.Likes);
            Assert.NotNull(art.Tools);
            Assert.NotNull(art.Materials);
            Assert.NotNull(art.Steps);
        }
    }
}
