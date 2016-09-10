using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SureBetExplorer
{
    public class WilliamHillSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public WilliamHillSite(string adress)
        {
            _webAdress = adress;
            ScrapeEvents();
        }

        public void ScrapeEvents()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_webAdress);

            //To Do: click on pop up

            IWebElement wrapper = driver.FindElement(By.Id("ip_sport_0_types"));
        }

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }
    }
}
