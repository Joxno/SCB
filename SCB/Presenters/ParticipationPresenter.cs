using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class ParticipationPresenter : ITextPresenter<Participation>
    {
        private static readonly PercentagePresenter m_PercentPresenter = new PercentagePresenter();
        public string Present(Participation Input)
        {
            return m_PercentPresenter.Present(Input.Value);
        }
    }
}
