using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Filters
{
    public class HighestParticipationPerElection : IFilter<IEnumerable<Election>>
    {
        public IEnumerable<Election> Apply(IEnumerable<Election> Input)
        {
            return Input.Select(E =>
            {
                return new Election
                {
                    Year = E.Year,
                    Results = new List<ElectionResult>
                    {
                        E.Results.OrderByDescending(R => R.Participation.Value.Value).First()
                    }
                };
            });
        }
    }
}
