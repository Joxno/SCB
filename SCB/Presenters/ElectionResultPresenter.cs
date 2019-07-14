using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class ElectionResultPresenter : ITextPresenter<ElectionResult>
    {
        private static readonly RegionPresenter m_RegionPresenter = new RegionPresenter();
        private static readonly ParticipationPresenter m_ParticipationPresenter = new ParticipationPresenter();
        public string Present(ElectionResult Input)
        {
            return 
                m_RegionPresenter.Present(Input.Region)
                + " " +
                m_ParticipationPresenter.Present(Input.Participation);
        }
    }
}
