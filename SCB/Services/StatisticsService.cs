using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Services
{
    public class StatisticsService : IStatisticsService
    {
        private IStatisticsRepository m_Repo = null;

        public StatisticsService(IStatisticsRepository Repo)
        {
            m_Repo = Repo;
        }

        public IEnumerable<Election> RetrieveAndFilterElections(IFilter<Election> Filter)
        {
            return _RetrieveElections().Select(E => Filter.Apply(E));
        }

        public IEnumerable<Election> RetrieveAndFilterElections(IFilter<IEnumerable<Election>> Filter)
        {
            return Filter.Apply(_RetrieveElections());
        }

        public IEnumerable<Election> RetrieveElections()
        {
            return _RetrieveElections();
        }

        private IEnumerable<Election> _RetrieveElections()
        {
            return m_Repo.RetrieveElections();
        }
    }
}
