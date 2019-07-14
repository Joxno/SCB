using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Presenters
{
    public class RegionPresenter : ITextPresenter<Region>
    {
        public string Present(Region Input)
        {
            return Input.Name;
        }
    }
}
