using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SureBetExplorer
{
    public class SportingBetSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events = new List<Tuple<string, double, double, double>>();
        private List<string> _eventsNames = new List<string>();
        private string _webAdress;

        public SportingBetSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_webAdress);

            IWebElement wrapper = driver.FindElements(By.XPath("//div[@id='eventGroups']/div"))[1];
            var names = wrapper.FindElements(By.CssSelector(".eventName > a"));
            var allOddsHome = wrapper.FindElements(By.XPath(".//*[@class='market']/div[1]/div[@id='isOffered']/a/span[2]"));
            var allOddsDraw = wrapper.FindElements(By.XPath(".//*[@class='market']/div[2]/div[@id='isOffered']/a/span[2]"));
            var allOddsAway = wrapper.FindElements(By.XPath(".//*[@class='market']/div[3]/div[@id='isOffered']/a/span[2]"));

            for (int i=0; i<=names.Count-1; i++)
            {
                string nameOfEvent = names[i].Text.Replace(" v ", " - ");
                _eventsNames.Add(nameOfEvent);

                string oddsHomeString = allOddsHome[i].Text.Replace(".", ",");
                string oddsDrawString = allOddsDraw[i].Text.Replace(".", ",");
                string oddsAwayString = allOddsAway[i].Text.Replace(".", ",");

                double oddsHome = double.Parse(oddsHomeString);
                double oddsDraw = double.Parse(oddsDrawString);
                double oddsAway = double.Parse(oddsAwayString);

                _events.Add(new Tuple<string, double, double, double>(nameOfEvent, oddsHome, oddsDraw, oddsAway));
            }
            driver.Quit();
        }

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }

        public List<Tuple<string, double, double, double>> GetEvents()
        {
            return _events;
        }
    }
}
