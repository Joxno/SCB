using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Converters;
using SCB.DTO;

namespace SCBTests
{
    [TestClass]
    public class ElectionParticipationConverterTests
    {
        [TestMethod]
        public void ConvertToElection()
        {
            var t_Converter = new ElectionParticipationConverter();
            var t_DTO = new ElectionParticipationResult
            {
                data = new Data[]
                 {
                     new Data { key = new string[] { "00", "1900" }, values = new string[] { "90.0" } },
                     new Data { key = new string[] { "01", "1900" }, values = new string[] { "50.0" } }
                 }
            };

            var t_Elections = t_Converter.Convert(t_DTO);

            Assert.IsTrue(t_Elections.Length == 1);
            Assert.IsTrue(t_Elections[0].Results.Count == 2);
            Assert.AreEqual(1900, t_Elections[0].Year.Value);

            Assert.AreEqual(0, t_Elections[0].Results[0].Region.Code);
            Assert.AreEqual(0.9m, t_Elections[0].Results[0].Participation.Value.Value);

            Assert.AreEqual(1, t_Elections[0].Results[1].Region.Code);
            Assert.AreEqual(0.5m, t_Elections[0].Results[1].Participation.Value.Value);
        }
    }
}
