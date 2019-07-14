using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Converters;
using SCB.DTO;

namespace SCBTests
{
    [TestClass]
    public class RegionConverterTests
    {
        [TestMethod]
        public void ConvertToRegion()
        {
            var t_Converter = new RegionConverter();
            var t_DTO = new RegionResult
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

            var t_ConvertedValue = t_Converter.Convert(t_DTO);

            Assert.IsNotNull(t_ConvertedValue);
            Assert.IsTrue(t_ConvertedValue.Length == 2);

            Assert.AreEqual(t_ConvertedValue[0].Code, 0);
            Assert.AreEqual(t_ConvertedValue[0].Name, "Foo");

            Assert.AreEqual(t_ConvertedValue[1].Code, 1);
            Assert.AreEqual(t_ConvertedValue[1].Name, "Bar");
        }
    }
}
