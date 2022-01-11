using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SolutionsService.Controllers;
using SolutionsService.Data;
using SolutionsService.Models;
using SolutionsService.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTest.Controllers
{
    public class SolutionControllerTest
    {
        public IEnumerable<SDG> SDGs { get; set; }

        public IEnumerable<Solution> Solutions { get; set; }
        public IEnumerable<SDGSolution> SDGSolutions { get; set; }

        [SetUp]
        public void Setup()
        {
            SDGs = new List<SDG>()
            {
                new SDG()
                {
                    Id = new Guid("FEB4E7C8-9DD4-4B9B-82F3-499D0B464A2B"),
                    Name = "No Poverty",
                    SDGNumber = 1
                },
                new SDG()
                {
                    Id = new Guid("9C46504C-7BB9-472E-BC9E-7DA9957F34CC"),
                    Name = "Zero hunger",
                    SDGNumber = 2
                },
                new SDG()
                {
                    Id = new Guid("27DB908E-B607-4454-9259-8AC399A4CC3F"),
                    Name = "Good health and well-being",
                    SDGNumber = 3
                },
                new SDG()
                {
                    Id = new Guid("2FF25E4B-C275-4C90-AFD4-F42C4EE3197F"),
                    Name = "Quality Education",
                    SDGNumber = 4
                },
                new SDG()
                {
                    Id = new Guid("D0E263F0-4E3B-4FD0-90F4-07753263BD6E"),
                    Name = "Gender equality",
                    SDGNumber = 5
                },
                new SDG()
                {
                    Id = new Guid("764DF34B-2395-4B4E-9434-97109EC8DD6A"),
                    Name = "Clean water and sanitation",
                    SDGNumber = 6
                },
                new SDG()
                {
                    Id = new Guid("F79BC0BB-6E2D-4CB2-BC2B-22CDA995BF81"),
                    Name = "Affordable and clean energy",
                    SDGNumber = 7
                },
                new SDG()
                {
                    Id = new Guid("7FAA4D47-0A98-4750-9C1E-5CA95799CB16"),
                    Name = "Decent work and economic growth",
                    SDGNumber = 8
                },
                new SDG()
                {
                    Id = new Guid("CAAA5420-EBE1-45D7-966F-61C5071A3669"),
                    Name = "Industry, innovation and infrastructure",
                    SDGNumber = 9
                },
                new SDG()
                {
                    Id = new Guid("D49D23C5-AA11-4FCF-B65E-68D71D9A91E5"),
                    Name = "Reducted inequalities",
                    SDGNumber = 10
                },
                new SDG()
                {
                    Id = new Guid("9C4D0AB6-39F1-4FDB-A5E8-117691959C28"),
                    Name = "Sustainable cities and communities",
                    SDGNumber = 11
                },
                new SDG()
                {
                    Id = new Guid("D8821681-A681-4D19-BE44-AF404B3181C5"),
                    Name = "Responsible consumption and production",
                    SDGNumber = 12
                },
                new SDG()
                {
                    Id = new Guid("E1A1894F-A631-4066-8852-703CBA2C33C2"),
                    Name = "Climate action",
                    SDGNumber = 13
                },
                new SDG()
                {
                    Id = new Guid("3624D854-8C88-4023-92B8-134A99D25F6D"),
                    Name = "Life below water",
                    SDGNumber = 14
                },
                new SDG()
                {
                    Id = new Guid("9D6F8727-BC53-4818-8D0C-0E334555663F"),
                    Name = "Life on land",
                    SDGNumber = 15
                },
                new SDG()
                {
                    Id = new Guid("0E1A9682-3632-48AE-8ABE-E7C2F1C7DA75"),
                    Name = "Peace justice and strong institutions",
                    SDGNumber = 16
                },
                new SDG()
                {
                    Id = new Guid("50E63213-7243-4232-BB6B-14BCCB665341"),
                    Name = "Partnerships for the goals",
                    SDGNumber = 17
                }
            };

            Solutions = new List<Solution>()
            {
                new Article()
                {
                    Id = new Guid("1938290f-a34b-e327-aed2-a284756ef3b2"),
                    Name = "Mock Solution one",
                    WeatherExtreme = "Drought",
                    HeaderImageURL = "http://fakeWebsite/api/solutions/images/solution/1938290f-a34b-e327-aed2-a284756ef3b2",
                    Description = "This is the description of mock solution 1",
                    AuthorId = new Guid("a2730f2e-ea12-9380-b36c-39d02e8b638a"),
                    Content = "Content Solution number 1",
                    UploadDate = DateTime.Now,
                    LastUpdatedTime = DateTime.Now,
                    ViewCount = 1,
                    SDGs = new List<SDGSolution>()
                    {
                        new SDGSolution()
                        {
                            SDG = SDGs.ElementAt(12)
                        }
                    }
                },
                new Article()
                {
                    Id = new Guid("ab32110f-99be-65ab-1668-176559abee48"),
                    Name = "Mock Solution two",
                    WeatherExtreme = "Drought",
                    HeaderImageURL = "http://fakeWebsite/api/solutions/images/solution/ab32110f-99be-65ab-1668-176559abee48",
                    Description = "This is the description of mock solution 2",
                    AuthorId = new Guid("a2730f2e-ea12-9380-b36c-39d02e8b638a"),
                    Content = "Content Solution number 2",
                    UploadDate = DateTime.Now,
                    LastUpdatedTime = DateTime.Now,
                    ViewCount = 1,
                    SDGs = new List<SDGSolution>()
                    {
                        new SDGSolution()
                        {
                            SDG = SDGs.ElementAt(12)
                        }
                    }
                },
                new Article()
                {
                    Id = new Guid("fe27819a-7554-7a7e-ffab-bee42788006b"),
                    Name = "Mock Solution three",
                    WeatherExtreme = "",
                    HeaderImageURL = "http://fakeWebsite/api/solutions/images/solution/fe27819a-7554-7a7e-ffab-bee42788006b",
                    Description = "This is the description of mock solution 3",
                    AuthorId = new Guid("44748768-2e5e-7cc6-5937-127864be7f7a"),
                    Content = "Content Solution number 3",
                    UploadDate = DateTime.Now,
                    LastUpdatedTime = DateTime.Now,
                    ViewCount = 1,
                    SDGs = new List<SDGSolution>()
                    {
                        new SDGSolution()
                        {
                            SDG = SDGs.ElementAt(4)
                        }
                    }
                },
                new Article()
                {
                    Id = new Guid("fdedad34-8030-048b-7c14-fed67ba8910c"),
                    Name = "Mock Solution four",
                    WeatherExtreme = "",
                    HeaderImageURL = "http://fakeWebsite/api/solutions/images/solution/fe27819a-7554-7a7e-ffab-bee42788006b",
                    Description = "This is the description of mock solution 4",
                    AuthorId = new Guid("44748768-2e5e-7cc6-5937-127864be7f7a"),
                    Content = "Content Solution number 4",
                    UploadDate = DateTime.Now,
                    LastUpdatedTime = DateTime.Now,
                    ViewCount = 1,
                    SDGs = new List<SDGSolution>()
                    {
                        new SDGSolution()
                        {
                            SDG = SDGs.ElementAt(6)
                        }
                    }
                },
                new HowTo()
                {
                    Id = new Guid("eda34282-ebcf-583a-bade-fe677246409e"),
                    Name = "Mock Solution five",
                    WeatherExtreme = "Flood",
                    HeaderImageURL = "http://fakeWebsite/api/solutions/images/solution/fe27819a-7554-7a7e-ffab-bee42788006b",
                    Description = "This is the description of mock solution 5",
                    AuthorId = new Guid("a2730f2e-ea12-9380-b36c-39d02e8b638a"),
                    Introduction = "Introduction Solution 5",
                    Difficulty = "Easy",
                    Materials = new List<Material>()
                    {
                        new Material()
                        {
                            Id = new Guid("227678cf-b877-5fd4-342e-83f687823aeb"),
                            Name = "Wood",
                        },
                        new Material()
                        {
                            Id = new Guid("9899be52-e438-54d1-c92f-bb4b674209a1"),
                            Name = "Rope"
                        }
                    },
                    Tools = new List<Tool>()
                    {
                        new Tool()
                        {
                            Id = new Guid("cdb63898-153a-a584-9905-0b450ea4b108"),
                            Name = "Hammer"
                        },
                        new Tool()
                        {
                            Id = new Guid("ed129174-9899-04b0-ca24-045ce2d005ae"),
                            Name = "Nails"
                        }
                    },
                    Steps = new List<Step>()
                    {
                        new Step()
                        {
                            Id = new Guid("5928c4a4-73b4-2a47-41ad-0c03f839723a"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/5928c4a4-73b4-2a47-41ad-0c03f839723a",
                            Description = "Cut off any protruding branches or twigs to ensure the logs are straight and uniform in shape."
                        },
                        new Step()
                        {
                            Id = new Guid("95ded4f2-3816-a357-82de-38ce4736a3e5"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/95ded4f2-3816-a357-82de-38ce4736a3e5",
                            Description = "Arrange 9 of the 15 logs side-by-side close to the water’s edge; this makes it easier to “launch” the raft once completed."
                        },
                        new Step()
                        {
                            Id = new Guid("8ce14160-b807-825c-004c-52782cfeab18"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/8ce14160-b807-825c-004c-52782cfeab18",
                            Description = "Once the logs are arranged, pair the remaining six logs — three on top and three on the bottom: one pair near each end and the third in the middle, “sandwiching” the nine logs as per the image below."
                        },
                        new Step()
                        {
                            Id = new Guid("cdc72b91-e829-010a-379a-0100920cb232"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/cdc72b91-e829-010a-379a-0100920cb232",
                            Description = "If you don’t have a hammer and nails, lash the three logs to the other logs with paracord, rope, duct tape, tree roots or similar cordage."
                        },
                        new Step()
                        {
                            Id = new Guid("8291839c-a292-dc92-01a9-02b382910cae"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/8291839c-a292-dc92-01a9-02b382910cae",
                            Description = "As an option, place and securely attach some flat planks of wood or a plywood deck for a more stable floor."
                        },
                        new Step()
                        {
                            Id = new Guid("adb327e9-20c9-21ae-038c-2810928cb28b"),
                            CoverImage = "http://fakeWebsite/api/solutions/images/solution/step/adb327e9-20c9-21ae-038c-2810928cb28b",
                            Description = "Make a couple of oars, (see instructions below) then place the raft on the water."
                        }
                    },
                    UploadDate = DateTime.Now,
                    LastUpdatedTime = DateTime.Now,
                    ViewCount = 1,
                    SDGs = new List<SDGSolution>()
                    {
                        new SDGSolution()
                        {
                            SDG = SDGs.ElementAt(12)
                        }
                    }
                }
            };

            SDGSolutions = new List<SDGSolution>()
            {
                Solutions.ElementAt(0).SDGs.ElementAt(0),
                Solutions.ElementAt(1).SDGs.ElementAt(0),
                Solutions.ElementAt(2).SDGs.ElementAt(0),
                Solutions.ElementAt(3).SDGs.ElementAt(0),
                Solutions.ElementAt(4).SDGs.ElementAt(0)
            };
        }

        [Test]
        public void TestGetSolutionsWithNoFilters()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions;
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters();


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithTypeFilterArticle()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.OfType<Article>();
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SolutionTypes = new List<string>() { "Article" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithTypeFilterHowTo()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.OfType<HowTo>();
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SolutionTypes = new List<string>() { "HowTo" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithWheatherExtremeFilterDrought()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.WeatherExtreme == "Drought");
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { WeatherExtremes = new List<string>() { "Drought" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithWheatherExtremeFilterFreezingTemperatures()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.WeatherExtreme == "Freezing Temperatures");
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { WeatherExtremes = new List<string>() { "Freezing Temperatures" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithWheatherExtremeFilterFlood()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.WeatherExtreme == "Flood");
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { WeatherExtremes = new List<string>() { "Flood" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithSdgFilterClimateAction()
        {
            Mock<DbSet<Solution>> solutionsMockSet = new Mock<DbSet<Solution>>();
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<DbSet<SDGSolution>> sdgSolutionsMockSet = new Mock<DbSet<SDGSolution>>();
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Provider).Returns(SDGSolutions.AsQueryable().Provider);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Expression).Returns(SDGSolutions.AsQueryable().Expression);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.ElementType).Returns(SDGSolutions.AsQueryable().ElementType);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.GetEnumerator()).Returns(SDGSolutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(solutionsMockSet.Object);
            mockSolutionServiceContext.Setup(ssc => ssc.SDGSolutions).Returns(sdgSolutionsMockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.SDGs.Any(ss => ss.SDG == SDGs.ElementAt(12)));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SDGs = new List<string>() { "Climate action" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithSdgFilterGenderEquality()
        {
            Mock<DbSet<Solution>> solutionsMockSet = new Mock<DbSet<Solution>>();
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<DbSet<SDGSolution>> sdgSolutionsMockSet = new Mock<DbSet<SDGSolution>>();
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Provider).Returns(SDGSolutions.AsQueryable().Provider);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Expression).Returns(SDGSolutions.AsQueryable().Expression);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.ElementType).Returns(SDGSolutions.AsQueryable().ElementType);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.GetEnumerator()).Returns(SDGSolutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(solutionsMockSet.Object);
            mockSolutionServiceContext.Setup(ssc => ssc.SDGSolutions).Returns(sdgSolutionsMockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.SDGs.Any(ss => ss.SDG == SDGs.ElementAt(4)));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SDGs = new List<string>() { "Gender equality" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithSdgFilterNoPoverty()
        {
            Mock<DbSet<Solution>> solutionsMockSet = new Mock<DbSet<Solution>>();
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<DbSet<SDGSolution>> sdgSolutionsMockSet = new Mock<DbSet<SDGSolution>>();
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Provider).Returns(SDGSolutions.AsQueryable().Provider);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Expression).Returns(SDGSolutions.AsQueryable().Expression);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.ElementType).Returns(SDGSolutions.AsQueryable().ElementType);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.GetEnumerator()).Returns(SDGSolutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(solutionsMockSet.Object);
            mockSolutionServiceContext.Setup(ssc => ssc.SDGSolutions).Returns(sdgSolutionsMockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.SDGs.Any(ss => ss.SDG == SDGs.ElementAt(0)));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SDGs = new List<string>() { "No Poverty" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithSdgFilterGenderEqualityAndClimateAction()
        {
            Mock<DbSet<Solution>> solutionsMockSet = new Mock<DbSet<Solution>>();
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            solutionsMockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<DbSet<SDGSolution>> sdgSolutionsMockSet = new Mock<DbSet<SDGSolution>>();
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Provider).Returns(SDGSolutions.AsQueryable().Provider);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.Expression).Returns(SDGSolutions.AsQueryable().Expression);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.ElementType).Returns(SDGSolutions.AsQueryable().ElementType);
            sdgSolutionsMockSet.As<IQueryable<SDGSolution>>().Setup(m => m.GetEnumerator()).Returns(SDGSolutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(solutionsMockSet.Object);
            mockSolutionServiceContext.Setup(ssc => ssc.SDGSolutions).Returns(sdgSolutionsMockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.SDGs == SDGs.ElementAt(0) || s.SDGs == SDGs.ElementAt(12));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SDGs = new List<string>() { "Gender equality", "Climate action" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithAuthorFilter1()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.Where(s => s.AuthorId.Equals(new Guid("a2730f2e-ea12-9380-b36c-39d02e8b638a")));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { AuthorId = new Guid("a2730f2e-ea12-9380-b36c-39d02e8b638a")};


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithTypeAndWheatherExtremeFilterArticleDrought()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.OfType<Article>().Where(s => s.WeatherExtreme == "Drought");
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SolutionTypes = new List<string>() { "Article" }, WeatherExtremes = new List<string>() { "Drought" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }

        [Test]
        public void TestGetSolutionsWithTypeAndSdgFilterArticleClimateAction()
        {
            Mock<DbSet<Solution>> mockSet = new Mock<DbSet<Solution>>();
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Provider).Returns(Solutions.AsQueryable().Provider);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.Expression).Returns(Solutions.AsQueryable().Expression);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.ElementType).Returns(Solutions.AsQueryable().ElementType);
            mockSet.As<IQueryable<Solution>>().Setup(m => m.GetEnumerator()).Returns(Solutions.AsQueryable().GetEnumerator());

            Mock<SolutionsServiceContext> mockSolutionServiceContext = new Mock<SolutionsServiceContext>();
            mockSolutionServiceContext.Setup(ssc => ssc.Solutions).Returns(mockSet.Object);

            IEnumerable<Solution> ExpectedSolutions = Solutions.OfType<Article>().Where(s => s.SDGs.Any(ss => ss.SDG == SDGs.ElementAt(12)));
            OkObjectResult expectedResult = new OkObjectResult(ExpectedSolutions);

            SolutionsController solutionsController = new SolutionsController(mockSolutionServiceContext.Object);
            solutionsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };
            SolutionParameters solutionParameters = new SolutionParameters() { SolutionTypes = new List<string>() { "Article" }, WeatherExtremes = new List<string>() { "Drought" } };


            ActionResult<IEnumerable<Solution>> actualSolutions = solutionsController.GetSolution(solutionParameters);

            Assert.That(((OkObjectResult)actualSolutions.Result).Value, Is.EquivalentTo((IEnumerable<Solution>)expectedResult.Value));
        }
    }
}
