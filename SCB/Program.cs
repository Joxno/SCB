using SCB.Converters;
using SCB.Factories;
using SCB.Filters;
using SCB.Interfaces;
using SCB.Models;
using SCB.Presenters;
using SCB.Repositories;
using SCB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB
{
    class Program
    {
        static void Main(string[] args)
        {
            var t_Service = _CreateStatisticsService();
            var t_Presenter = _CreatePresenter();
            var t_Statistics = t_Service.RetrieveAndFilterElections(new HighestParticipation());

            Console.Write(t_Presenter.Present(t_Statistics));
        }

        private static IStatisticsService _CreateStatisticsService()
        {
            /* Manual Constructor Dependency Injection */
            /* No need to depend on a heavy DI framework for simple DI */
            return new StatisticsService(
                new SCBLazyRepository(
                    new ElectionFactory(
                        new RegionConverter(), new ElectionParticipationConverter()))
                );
        }

        private static ITextPresenter<IEnumerable<Election>> _CreatePresenter()
        {
            return new MultipleElectionsPresenter();
        }
    }
}
