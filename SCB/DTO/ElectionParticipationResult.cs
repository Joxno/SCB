using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.DTO
{
    public class ElectionParticipationResult
    {
        public Column[] columns { get; set; }
        public Comment[] comments { get; set; }
        public Data[] data { get; set; }
    }

    public class Column
    {
        public string code { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Comment
    {
        public string variable { get; set; }
        public string value { get; set; }
        public string comment { get; set; }
    }

    public class Data
    {
        public string[] key { get; set; }
        public string[] values { get; set; }
    }

}
