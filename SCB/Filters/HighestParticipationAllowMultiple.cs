using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Filters
{
    public class HighestParticipationAllowMultiple : IFilter<IEnumerable<Election>>
    {
        public IEnumerable<Election> Apply(IEnumerable<Election> Input)
        {
            return Input.Select(E =>
            {
                return new Election
                {
                    Year = E.Year,
                    Results = _FindAllResultsWithParticipation(
                        E.Results,
                        _FindHighestParticipationResult(E.Results).Participation
                    )
                };
            });
        }

        private ElectionResult _FindHighestParticipationResult(List<ElectionResult> Results)
        {
            return Results.OrderByDescending(R => R.Participation.Value.Value).First();
        }

        private List<ElectionResult> _FindAllResultsWithParticipation(List<ElectionResult> Results, Participation Value)
        {
            return Results.Where(R => R.Participation.Value.Value == Value.Value.Value).ToList();
        }
    }
}
