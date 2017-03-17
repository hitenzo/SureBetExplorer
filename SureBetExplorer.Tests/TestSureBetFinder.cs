using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SureBetExplorer.Tests.TestData;

namespace SureBetExplorer.Tests
{
    [TestClass]
    public class TestSureBetFinder
    {
        [TestMethod]
        public void TestFinder()
        {
            List<IBettingWebsite> listOfWebsites = new List<IBettingWebsite>();
            var sportingSite = new TestSportingBetSite();
            var williamSite = new TestWilliamHillSite();
            var betClickSite = new TestBetClickSite();
            listOfWebsites.Add(sportingSite);
            listOfWebsites.Add(williamSite);
            listOfWebsites.Add(betClickSite);
            var finder = new SureBetFinder(listOfWebsites);
            var actual = finder.GetSureBets().FirstOrDefault();
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "TestData\\SureBetsInfo.txt");
            var expected = File.ReadAllLines(filePath).FirstOrDefault();
            Assert.AreEqual(expected, actual);
        }
    }
}
