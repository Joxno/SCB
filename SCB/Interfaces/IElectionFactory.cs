using SCB.DTO;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Interfaces
{
    public interface IElectionFactory
    {
        Election[] CreateElections(ElectionParticipationResult Elections, RegionResult Regions);
    }
}
