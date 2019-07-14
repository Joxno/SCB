using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Models;
using SCB.Presenters;

namespace SCBTests
{
    [TestClass]
    public class PercentagePresenterTests
    {
        [TestMethod]
        public void PresentPercentage()
        {
            var t_Presenter = new PercentagePresenter();
            var t_PresentedText = t_Presenter.Present(new Percentage { Value = 0.10m });

            Assert.AreEqual("10.0%", t_PresentedText);
        }
    }
}
