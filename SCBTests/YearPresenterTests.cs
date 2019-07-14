using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Presenters;
using SCB.Models;

namespace SCBTests
{
    /// <summary>
    /// Summary description for YearPresenterTests
    /// </summary>
    [TestClass]
    public class YearPresenterTests
    { 
        [TestMethod]
        public void PresentYear()
        {
            var t_Presenter = new YearPresenter();
            var t_PresentedText = t_Presenter.Present(new Year { Value = 1900 });

            Assert.AreEqual("1900", t_PresentedText);
        }
    }
}
