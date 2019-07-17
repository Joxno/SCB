using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Models;
using SCB.Presenters;

namespace SCBTests
{
    [TestClass]
    public class ElectionResultPresenterTests
    {
        [TestMethod]
        public void PresentElectionResult()
        {
            var t_Presenter = new ElectionResultPresenter();
            var t_PresentedText = t_Presenter.Present(new ElectionResult
            {
                Participation = new Participation { Value = new Percentage { Value = 0.33m } },
                Region = new Region { Code = -1, Name = "Foobar" }
            });

            Assert.AreEqual("Foobar 33.0%", t_PresentedText);
        }
    }
}
