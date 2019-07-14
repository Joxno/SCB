using SCB.DTO;
using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Converters
{
    public class RegionConverter : IConverter<RegionResult, Region[]>
    {
        public Region[] Convert(RegionResult Value)
        {
            return Value.variables
                .Where(V => V.code == "Region")
                .SelectMany(V => V.values.Zip(V.valueTexts, 
                    (C, N) => new Region { Code = int.Parse(C), Name = N }))
                .ToArray();
        }
    }
}
