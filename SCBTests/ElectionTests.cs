using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Models;
using SCB.Presenters;

namespace SCBTests
{
    [TestClass]
    public class ElectionTests
    {
        private ElectionPresenter m_Presenter = null;
        [TestInitialize]
        public void Initialize()
        {
            m_Presenter = new ElectionPresenter();
        }

        [TestMethod]
        public void PresentElection()
        {
            var t_PresentedText = m_Presenter.Present(_CreateElection());

            Assert.AreEqual("1900: Foobar 99.0%", t_PresentedText);
        }

        [TestMethod]
        public void PresentElectionMultipleResults()
        {
            var t_PresentedText = m_Presenter.Present(_CreateElectionWithMultipleResults());

            Assert.AreEqual("1900:\nFoo 99.0%\nBar 75.0%", t_PresentedText);
        }

        [TestMethod]
        public void PresentEmptyElection()
        {
            var t_PresentedText = m_Presenter.Present(_CreateEmptyElection());

            Assert.AreEqual("1900: No Election Results!", t_PresentedText);
        }

        private Election _CreateElection()
        {
            return new Election
            {
                Year = new Year { Value = 1900 },
                Results = new List<ElectionResult>
                {
                    new ElectionResult
                    {
                        Region = new Region { Code = -1, Name = "Foobar" },
                        Participation = new Participation { Value = new Percentage { Value = 0.99m } }
                    }
                }
            };
        }

        private Election _CreateElectionWithMultipleResults()
        {
            return new Election
            {
                Year = new Year { Value = 1900 },
                Results = new List<ElectionResult>
                {
                    new ElectionResult
                    {
                        Region = new Region { Code = -1, Name = "Foo" },
                        Participation = new Participation { Value = new Percentage { Value = 0.99m } }
                    },
                    new ElectionResult
                    {
                        Region = new Region { Code = -1, Name = "Bar" },
                        Participation = new Participation { Value = new Percentage { Value = 0.75m } }
                    }
                }
            };
        }

        private Election _CreateEmptyElection()
        {
            return new Election
            {
                Year = new Year { Value = 1900 },
                Results = new List<ElectionResult>()
            };
        }
    }
}
