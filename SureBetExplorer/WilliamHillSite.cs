using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SureBetExplorer
{
    public class WilliamHillSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events = new List<Tuple<string, double, double, double>>();
        private List<string> _eventsNames = new List<string>();
        private string _webAdress;

        public WilliamHillSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_webAdress);
            var popup = driver.FindElement(By.Id("yesBtn"));
            popup.Click();
            IWebElement wrapper = driver.FindElement(By.Id("ip_sport_0_types"));
            var names = wrapper.FindElements(By.XPath(".//*[@class='marketHolderExpanded']//tr[@class='rowOdd']/td[3]/a/span"));
            var allOddsHome = wrapper.FindElements(By.XPath(".//*[@class='marketHolderExpanded']//tr[@class='rowOdd']/td[5]/div/div[@id]"));
            var allOddsDraw = wrapper.FindElements(By.XPath(".//*[@class='marketHolderExpanded']//tr[@class='rowOdd']/td[6]/div/div[@id]"));
            var allOddsAway = wrapper.FindElements(By.XPath(".//*[@class='marketHolderExpanded']//tr[@class='rowOdd']/td[7]/div/div[@id]"));
            int eventsNumber = Math.Min(allOddsHome.Count, Math.Min(allOddsDraw.Count, allOddsHome.Count));

            for (int i=0; i<= eventsNumber - 1; i++)
            {
                string nameOfEvent = names[i].Text;
                nameOfEvent = Regex.Replace(nameOfEvent, @"\s+", " ");
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
