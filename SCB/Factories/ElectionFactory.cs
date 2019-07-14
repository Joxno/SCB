using SCB.DTO;
using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Factories
{
    public class ElectionFactory : IElectionFactory
    {
        private IConverter<RegionResult, Region[]> m_RegionConverter = null;
        private IConverter<ElectionParticipationResult, Election[]> m_ElectionConverter = null;

        public ElectionFactory(
            IConverter<RegionResult, Region[]> RegionConverter,
            IConverter<ElectionParticipationResult, Election[]> ElectionConverter)
        {
            m_RegionConverter = RegionConverter;
            m_ElectionConverter = ElectionConverter;
        }
        public Election[] CreateElections(ElectionParticipationResult Elections, RegionResult Regions)
        {
            var t_Regions = m_RegionConverter.Convert(Regions);
            return
                m_ElectionConverter.Convert(Elections)
                .Select(E =>
                {
                    E.Results = E.Results.Select(R =>
                    {
                        R.Region.Name = _LookupRegionByCode(R.Region.Code, t_Regions)?.Name;
                        return R;
                    }).ToList();
                    return E;
                })
                .ToArray();
        }

        private Region _LookupRegionByCode(int Code, Region[] Regions)
        {
            return Regions.Where(R => R.Code == Code).FirstOrDefault();
        }
    }
}
