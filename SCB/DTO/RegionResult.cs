using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.DTO
{
    public class RegionResult
    {
        public string title { get; set; }
        public Variable[] variables { get; set; }
    }

    public class Variable
    {
        public string code { get; set; }
        public string text { get; set; }
        public string[] values { get; set; }
        public string[] valueTexts { get; set; }
        public bool elimination { get; set; }
        public bool time { get; set; }
    }

}
