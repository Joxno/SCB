using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Interfaces
{
    public interface IFilter<T>
    {
        T Apply(T Input);
    }
}
