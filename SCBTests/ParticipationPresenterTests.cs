using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Models;
using SCB.Presenters;

namespace SCBTests
{
    [TestClass]
    public class ParticipationPresenterTests
    {
        [TestMethod]
        public void PresentParticipation()
        {
            var t_Presenter = new ParticipationPresenter();
            var t_PresentedText = t_Presenter.Present(
                new Participation { Value = new Percentage { Value = 0.25m } }
            );

            Assert.AreEqual("25.0%", t_PresentedText);

        }
    }
}
