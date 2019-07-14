using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class PercentagePresenter : ITextPresenter<Percentage>
    {
        public string Present(Percentage Input)
        {
            return Input.Value.ToString("P1", new CultureInfo("en-US"));
        }
    }
}
