using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class StepTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            Step step = new Step()
            {
                Id = Guid.NewGuid(),
                CoverImage = "Image.png",
                Description = "Doe het zo",
                Solution = new HowTo(),
            };

            Assert.NotNull(step.Id);
            Assert.AreEqual("Image.png", step.CoverImage);
            Assert.AreEqual("Doe het zo", step.Description);
            Assert.NotNull(step.Solution);
        }
    }
}
