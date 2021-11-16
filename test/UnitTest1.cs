using NUnit.Framework;
using SolutionsService.Models;

namespace SolutionsTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void MakeTestModel()
        {
            Solution solution = new Article();

            Assert.AreNotEqual(solution, null);
        }
    }
}