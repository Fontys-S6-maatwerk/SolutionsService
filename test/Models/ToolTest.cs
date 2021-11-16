using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class ToolTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            Tool tool = new Tool()
            {
                Id = Guid.NewGuid(),
                Name = "hamer",
                Solution = new HowTo()
            };

            Assert.NotNull(tool.Id);
            Assert.AreEqual("hamer", tool.Name);
            Assert.NotNull(tool.Solution);
        }
    }
}
