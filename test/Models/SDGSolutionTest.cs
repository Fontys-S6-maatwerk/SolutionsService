using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolutionsService.Models;

namespace SolutionsTest.Models
{
    public class SDGSolutionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PropertiesTest()
        {
            Guid SolId = Guid.NewGuid();
            Guid SDGId = Guid.NewGuid();

            SDGSolution sdgsol = new SDGSolution()
            {
                SolutionId = SolId,
                SDGId = SDGId,
                Solution = new Article() { Id = SolId },
                SDG = new SDG() { Id = SDGId }
            };

            Assert.AreEqual(SDGId, sdgsol.SDGId);
            Assert.AreEqual(SolId, sdgsol.SolutionId);

            Assert.NotNull(sdgsol.Solution);
            Assert.NotNull(sdgsol.SDG);

            Assert.AreEqual(sdgsol.SDG.Id, sdgsol.SDGId);
            Assert.AreEqual(sdgsol.Solution.Id, sdgsol.SolutionId);
        }
    }
}
