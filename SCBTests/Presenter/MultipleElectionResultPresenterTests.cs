using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Models;
using SCB.Presenters;

namespace SCBTests.Presenter
{
    [TestClass]
    public class MultipleElectionResultPresenterTests
    {
        [TestMethod]
        public void PresentEmptyElectionResult()
        {
            var t_Presenter = new MultipleElectionResultPresenter();
            var t_PresentedText = t_Presenter.Present(new List<ElectionResult>());

            Assert.AreEqual("No values found!", t_PresentedText);
        }

        [TestMethod]
        public void PresentSingleElectionResult()
        {
            var t_Presenter = new MultipleElectionResultPresenter();
            var t_PresentedText = t_Presenter.Present(
            new List<ElectionResult>
            {
                new ElectionResult
                {
                    Participation = new Participation { Value = new Percentage { Value = 0.33m } },
                    Region = new Region { Code = -1, Name = "Foobar" }
                }
            });

            Assert.AreEqual("Foobar 33.0%", t_PresentedText);
        }

        [TestMethod]
        public void PresentMultipleElectionResult()
        {
            var t_Presenter = new MultipleElectionResultPresenter();
            var t_PresentedText = t_Presenter.Present(
            new List<ElectionResult>
            {
                new ElectionResult
                {
                    Participation = new Participation { Value = new Percentage { Value = 0.33m } },
                    Region = new Region { Code = -1, Name = "Foobar" }
                },
                new ElectionResult
                {
                    Participation = new Participation { Value = new Percentage { Value = 0.20m } },
                    Region = new Region { Code = -1, Name = "Bar" }
                }
            });

            Assert.AreEqual("Foobar 33.0%\nBar 20.0%", t_PresentedText);
        }

        [TestMethod]
        public void PresentMultipleElectionResultWithSameParticipation()
        {
            var t_Presenter = new MultipleElectionResultPresenter();
            var t_PresentedText = t_Presenter.Present(
            new List<ElectionResult>
            {
                new ElectionResult
                {
                    Participation = new Participation { Value = new Percentage { Value = 0.33m } },
                    Region = new Region { Code = -1, Name = "Foobar" }
                },
                new ElectionResult
                {
                    Participation = new Participation { Value = new Percentage { Value = 0.33m } },
                    Region = new Region { Code = -1, Name = "Bar" }
                }
            });

            Assert.AreEqual("Foobar, Bar: 33.0%", t_PresentedText);
        }
    }
}
