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

        [Test]
        public void PopulatedArticleTest()
        {
            List<SDG> sdgdata = new List<SDG>()
            {
                new SDG()
                {
                    Id = Guid.NewGuid(),
                    Name = "Honger",
                    SDGNumber = 1
            },
                new SDG()
                {
                    Id = Guid.NewGuid(),
                    Name = "Regen",
                    SDGNumber = 2
                }
            };

            Article art = new Article()
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                Content = "test content",
                WeatherExtreme = "Regen",
                HeaderImageURL = "image.png",
                Description = "omschrijving",
                Name = "naam",
                LastUpdatedTime = DateTime.Now,
                UploadDate = DateTime.Now,
                ViewCount = 12345
            };

            List<SDGSolution> sdgList = new List<SDGSolution>();

            foreach(var item in sdgdata)
            {
                sdgList.Add(new SDGSolution() { SDG = item, SDGId = item.Id, Solution = art, SolutionId = art.Id });
            }

            art.SDGs = sdgList;

            ArticleResponse response = art.ConvertToResponseModel();

            Assert.AreEqual(art.Name, response.Name);
            Assert.AreEqual(art.Id, response.Id);
            Assert.AreEqual(art.AuthorId, response.AuthorId);
            Assert.AreEqual(art.WeatherExtreme, response.WeatherExtreme);
            Assert.AreEqual(art.Description, response.Description);
            Assert.AreEqual(art.HeaderImageURL, response.HeaderImageURL);
            Assert.AreEqual(art.ViewCount, response.ViewCount);
            Assert.AreEqual(art.LastUpdatedTime, response.LastUpdatedTime);
            Assert.AreEqual(art.UploadDate, response.UploadDate);
            Assert.AreEqual(art.Content, response.Content);

            for(int i = 0; i < art.SDGs.Count; i++)
            {
                SDG sdg = art.SDGs.ToList()[i].SDG;
                Assert.AreEqual(sdg.Id, response.SDGs[i].Id);
                Assert.AreEqual(sdg.Name, response.SDGs[i].Name);
                Assert.AreEqual(sdg.SDGNumber, response.SDGs[i].SDGNumber);
            }
        }

        [Test]
        public void TestPopulatedHowTo()
        {
            HowTo howTo = new HowTo()
            {
                Introduction = "intro",
                Difficulty = "makkelijk"
            };

            List<Step> step = new List<Step>()
            {
                new Step()
                {
                    Id = Guid.NewGuid(),
                    CoverImage = "image.png",
                    Description = "omschrijving",
                    Solution = howTo
                }
            };
            List<Material> material = new List<Material>()
            {
                new Material()
                {
                    Id = Guid.NewGuid(),
                    Name = "doekje",
                    Solution = howTo
                }
            };
            List<Tool> tool = new List<Tool>()
            {
                new Tool()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hamer",
                    Solution = howTo
                }
            };

            howTo.Materials = material;
            howTo.Steps = step;
            howTo.Tools = tool;

            HowToResponse response = howTo.ConvertToResponseModel();

            Assert.AreEqual(howTo.Introduction, response.Introduction);
            Assert.AreEqual(howTo.Difficulty, response.Difficulty);

            for(int i = 0; i < howTo.Materials.Count; i++)
            {
                Material item = howTo.Materials.ToList()[i];
                Assert.AreEqual(item.Name, response.Materials[i]);
            }

            for(int i = 0; i < howTo.Tools.Count; i++)
            {
                Tool item = howTo.Tools.ToList()[i];
                Assert.AreEqual(item.Name, response.Tools[i]);
            }

            for(int i = 0; i < howTo.Steps.Count; i++)
            {
                Step item = howTo.Steps.ToList()[i];
                Assert.AreEqual(item.CoverImage, response.Steps[i].CoverImage);
                Assert.AreEqual(item.Description, response.Steps[i].Description);
            }
        }
    }
}
