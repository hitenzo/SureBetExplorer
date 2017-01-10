using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SureBetExplorer
{
    public class BetClicSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events = new List<Tuple<string, double, double, double>>();
        private List<string> _eventsNames = new List<string>();
        private string _webAdress;

        public BetClicSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_webAdress);

            IWebElement wrapper = driver.FindElement(By.XPath("//*[@ id='cal-wrapper-prelive']"));
            var names = wrapper.FindElements(By.XPath(".//*[@data-track-event-name]//div[@class='match-name']/a"));
            var allOddsHome = wrapper.FindElements(By.XPath(".//*[@data-track-event-name]//div[@class='match-odds']/div[1]/span"));
            var allOddsDraw = wrapper.FindElements(By.XPath(".//*[@data-track-event-name]//div[@class='match-odds']/div[2]/span"));
            var allOddsAway = wrapper.FindElements(By.XPath(".//*[@data-track-event-name]//div[@class='match-odds']/div[3]/span"));

            for (int i = 0; i <= names.Count - 1; i++)
            {
                string nameOfEvent = names[i].Text;
                _eventsNames.Add(nameOfEvent);

                double oddsHome = double.Parse(allOddsHome[i].Text);
                double oddsDraw = double.Parse(allOddsDraw[i].Text);
                double oddsAway = double.Parse(allOddsAway[i].Text);

                _events.Add(new Tuple<string, double, double, double>(nameOfEvent, oddsHome, oddsDraw, oddsAway));
            }
            driver.Close();
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
