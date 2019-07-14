using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SCB.DTO;

namespace SCBTests
{
    [TestClass]
    public class ElectionParticipationResultTests
    {
        /*
            Intention is not to test Newtonsoft.Json conversion.
            This test is in place to protect against DTO structure changes.
        */

        [TestMethod]
        public void DeserializeValidResult()
        {
            var t_Json = TestResources.ValidParticipationResult;
            var t_Deserialized = JsonConvert.DeserializeObject<ElectionParticipationResult>(t_Json, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error
            });

            Assert.IsNotNull(t_Deserialized);

            Assert.IsTrue(t_Deserialized.data.Length == 1);
            Assert.IsTrue(t_Deserialized.data[0].key[0] == "00");
            Assert.IsTrue(t_Deserialized.data[0].key[1] == "1900");
        }
    }
}
