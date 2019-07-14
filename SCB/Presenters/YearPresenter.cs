using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class YearPresenter : ITextPresenter<Year>
    {
        public string Present(Year Input)
        {
            return Input.Value.ToString();
        }
    }
}
