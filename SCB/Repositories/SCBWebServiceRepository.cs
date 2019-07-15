using Newtonsoft.Json;
using SCB.DTO;
using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Repositories
{
    public class SCBLazyRepository : IStatisticsRepository
    {
        private static readonly HttpClient m_Client = new HttpClient();
        private static readonly Uri m_APIURI = new Uri("http://api.scb.se/OV0104/v1/doris/sv/ssd/START/ME/ME0104/ME0104D/ME0104T4");
        private IElectionFactory m_Factory = null;

        public SCBLazyRepository(IElectionFactory Factory)
        {
            m_Factory = Factory;
        }

        public IEnumerable<Election> RetrieveElections()
        {
            return m_Factory.CreateElections(_MakeParticipationRequest(), _MakeRegionRequest());
        }

        private RegionResult _MakeRegionRequest()
        {
            var t_Response =  m_Client.GetAsync(m_APIURI).Result;
            return _HandleRequest<RegionResult>(t_Response);
        }

        private ElectionParticipationResult _MakeParticipationRequest()
        {
            using (var t_JsonData = new StringContent(StatisticsResources.ElectionQuery))
            {
                var t_Response = m_Client.PostAsync(m_APIURI, t_JsonData).Result;
                return _HandleRequest<ElectionParticipationResult>(t_Response);
            } 
        }

        private T _HandleRequest<T>(HttpResponseMessage RegionResponse)
        {
            if (RegionResponse.IsSuccessStatusCode)
                return _Deserialize<T>(_ReadJsonFromResponse(RegionResponse));
            return default;
        }

        private T _Deserialize<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error
            });
        }

        private string _ReadJsonFromResponse(HttpResponseMessage Response)
        {
            return Response.Content.ReadAsStringAsync().Result;
        }
    }
}
