using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class MultipleElectionResultPresenter : ITextPresenter<IEnumerable<ElectionResult>>
    {
        private static readonly RegionPresenter m_RegionPresenter = new RegionPresenter();
        private static readonly ParticipationPresenter m_ParticipationPresenter = new ParticipationPresenter();
        public string Present(IEnumerable<ElectionResult> Input)
        {
            return
                Input.Count() == 0 ? _PresentNone() :
                Input.Count() == 1 ? _PresentSingle(Input.First()) :
                _HasMultipleParticipationValues(Input) ? _PresentMultiple(Input) :
                _PresentMultipleWithSameParticipation(Input);

        }

        private string _PresentSingle(ElectionResult Result)
        {
            return
                m_RegionPresenter.Present(Result.Region)
                + " " +
                m_ParticipationPresenter.Present(Result.Participation);
        }

        private string _PresentMultiple(IEnumerable<ElectionResult> Result)
        {
            return
                "\n" +
                String.Join("\n", Result.Select(R => _PresentSingle(R)));
        }

        private string _PresentMultipleWithSameParticipation(IEnumerable<ElectionResult> Result)
        {
            return
                String.Join(", ", Result.Select(R => m_RegionPresenter.Present(R.Region)))
                + ": " +
                m_ParticipationPresenter.Present(Result.First().Participation);
        }

        private string _PresentNone()
        {
            return "No values found!";
        }

        private bool _HasMultipleParticipationValues(IEnumerable<ElectionResult> Result)
        {
            return Result
                .Select(R => R.Participation.Value.Value)
                .Distinct()
                .Count() > 1;
        }
    }
}
