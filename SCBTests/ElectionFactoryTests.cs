using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Converters;
using SCB.DTO;
using SCB.Factories;

namespace SCBTests
{
    [TestClass]
    public class ElectionFactoryTests
    {
        [TestMethod]
        public void CreateElections()
        {
            var t_Factory = new ElectionFactory(new RegionConverter(), new ElectionParticipationConverter());
            var t_RegionDTO = new RegionResult
            {
                title = "",
                variables = new Variable[]
                {
                    new Variable
                    {
                        code = "Region",
                        values = new string[] { "00", "01" },
                        valueTexts = new string[] { "Foo", "Bar" }
                    }
                }
            };

            var t_ElectionDTO = new ElectionParticipationResult
            {
                data = new Data[]
                {
                    new Data { key = new string[] { "00", "1900" }, values = new string[] { "50.0" } },
                    new Data { key = new string[] { "01", "1900" }, values = new string[] { "25.0" } }
                }
            };

            var t_Elections = t_Factory.CreateElections(t_ElectionDTO, t_RegionDTO);

            Assert.IsTrue(t_Elections.Length == 1);

            Assert.IsTrue(t_Elections[0].Results.Count == 2);
            Assert.IsTrue(t_Elections[0].Year.Value == 1900);

            Assert.AreEqual(0, t_Elections[0].Results[0].Region.Code);
            Assert.AreEqual("Foo", t_Elections[0].Results[0].Region.Name);
            Assert.AreEqual(0.5m, t_Elections[0].Results[0].Participation.Value.Value);

            Assert.AreEqual(1, t_Elections[0].Results[1].Region.Code);
            Assert.AreEqual("Bar", t_Elections[0].Results[1].Region.Name);
            Assert.AreEqual(0.25m, t_Elections[0].Results[1].Participation.Value.Value);
        }
    }
}
