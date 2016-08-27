using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SureBetExplorer
{
    class BetClicSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public BetClicSite(string adress)
        {
            _webAdress = adress;
            ScrapeEvents();
        }

        public void ScrapeEvents()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_webAdress);

            HtmlNode wrapper = document.DocumentNode.SelectNodes("//div[@id='cal-wrapper-prelive']").First();
            foreach (var daySection in wrapper.SelectNodes(".//div"))
            {
                foreach (var schedule in daySection.SelectNodes(".//div[@class='cal-schedule']"))
                {
                    foreach (var singleEvent in schedule.SelectNodes(".//div[@class='event']"))
                    {
                        string eventName = singleEvent.SelectNodes(".//div[@class='match-entry']//div[@class='match-name']//a").First().InnerHtml;
                        _eventsNames.Add(eventName);

                        string oddsHomeString = singleEvent.SelectNodes(".//div[@class='match-entry']//div[@class='match-odds']//div[1]//span").First().InnerHtml;
                        double oddsHome = Convert.ToDouble(oddsHomeString);

                        string oddsDrawString = singleEvent.SelectNodes(".//div[@class='match-entry']//div[@class='match-odds']//div[2]//span").First().InnerHtml;
                        double oddsDraw = Convert.ToDouble(oddsDrawString);

                        string oddsAwayString = singleEvent.SelectNodes(".//div[@class='match-entry']//div[@class='match-odds']//div[3]//span").First().InnerHtml;
                        double oddsAway = Convert.ToDouble(oddsAwayString);

                        _events.Add(new Tuple<string, double, double, double>(eventName, oddsHome, oddsDraw, oddsAway));
                    }
                }
            }
        }

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }
    }
}
