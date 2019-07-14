using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Models
{
    public class Election
    {
        public Year Year { get; set; }
        public List<ElectionResult> Results { get; set; }
    }
}
