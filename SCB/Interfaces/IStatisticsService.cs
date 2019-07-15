using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Interfaces
{
    public interface IStatisticsService
    {
        IEnumerable<Election> RetrieveElections();
        IEnumerable<Election> RetrieveAndFilterElections(IFilter<Election> Filter);
        IEnumerable<Election> RetrieveAndFilterElections(IFilter<IEnumerable<Election>> Filter);
    }
}
