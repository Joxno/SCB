using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class ElectionPresenter : ITextPresenter<Election>
    {
        private static readonly ElectionResultPresenter m_ResultPresenter = new ElectionResultPresenter();
        private static readonly YearPresenter m_YearPresenter = new YearPresenter();
        public string Present(Election Input)
        {
            return 
                Input.Results.Count == 0 ? _PresentNone(Input) :
                Input.Results.Count == 1 ? _PresentSingle(Input) :
                _PresentMultiple(Input);
        }

        private string _PresentSingle(Election Input)
        {
            return 
                m_YearPresenter.Present(Input.Year) + ": " + 
                m_ResultPresenter.Present(Input.Results.First());
        }

        private string _PresentMultiple(Election Input)
        {
            return 
                m_YearPresenter.Present(Input.Year) + ":\n" +
                String.Join("\n", Input.Results.Select(R => m_ResultPresenter.Present(R)));
        }

        private string _PresentNone(Election Input)
        {
            return m_YearPresenter.Present(Input.Year) + ": No Election Results!";
        }
    }
}
