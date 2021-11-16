using NUnit.Framework;
using SolutionsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsTest.Models
{
    public class LikeTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            Like like = new Like()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Solution = new HowTo()
            };

            Assert.NotNull(like.Id);
            Assert.NotNull(like.UserId);
            Assert.IsTrue(like.Id != like.UserId);
        }
    }
}
