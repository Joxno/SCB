using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Filters;
using SCB.Services;
using SCBTests.Mock;

namespace SCBTests
{
    [TestClass]
    public class StatisticsServiceTests
    {
        [TestMethod]
        public void RetrieveStatisticsWithNoFilter()
        {
            var t_Repo = new MockStatisticsRepository();
            var t_Service = new StatisticsService(t_Repo);

            var t_Elections = t_Service.RetrieveElections().ToList();

            Assert.AreEqual(1, t_Elections.Count);
            Assert.AreEqual(1900, t_Elections[0].Year.Value);
            Assert.AreEqual(2, t_Elections[0].Results.Count);
        }

        [TestMethod]
        public void RetrieveStatisticsWithFilter()
        {
            var t_Repo = new MockStatisticsRepository();
            var t_Service = new StatisticsService(t_Repo);

            var t_Elections = t_Service.RetrieveAndFilterElections(
                new HighestParticipationPerElection()
            ).ToList();

            Assert.AreEqual(1, t_Elections.Count);
            Assert.AreEqual(1900, t_Elections[0].Year.Value);
            Assert.AreEqual(1, t_Elections[0].Results.Count);

            Assert.AreEqual("Foo", t_Elections[0].Results[0].Region.Name);
            Assert.AreEqual(0.9m, t_Elections[0].Results[0].Participation.Value.Value);
        }
    }
}
