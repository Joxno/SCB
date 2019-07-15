using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCBTests.Mock
{
    public class MockStatisticsRepository : IStatisticsRepository
    {
        public IEnumerable<Election> RetrieveElections()
        {
            return new List<Election>
            {
                _CreateElection(1900, new List<ElectionResult> { _CreateResult(0, "Foo", 0.9m), _CreateResult(1, "Bar", 0.5m) })
            };
        }

        private Election _CreateElection(int Year, List<ElectionResult> Results)
        {
            return new Election
            {
                Year = new Year { Value = Year },
                Results = Results
            };
        }

        private ElectionResult _CreateResult(int Code, string Name, decimal Percentage)
        {
            return new ElectionResult
            {
                Region = new Region { Code = Code, Name = Name },
                Participation = new Participation { Value = new Percentage { Value = Percentage } }
            };
        }
    }
}
