using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class MultipleElectionsPresenter : ITextPresenter<IEnumerable<Election>>
    {
        private static readonly ITextPresenter<Election> m_ElectionPresenter = new ElectionPresenter();
        public string Present(IEnumerable<Election> Input)
        {
            return String.Join("\n", Input.Select(E => m_ElectionPresenter.Present(E)));
        }
    }
}
