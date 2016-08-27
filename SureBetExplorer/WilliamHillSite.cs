using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

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
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_webAdress);

            HtmlNode wrapper = document.DocumentNode.SelectNodes("//div[@id='ip_sport_0_types']").First();
            foreach (var section in wrapper.SelectNodes(".//div"))
            {
                HtmlNode eventsGroup = section.SelectNodes("//div//div//table//tbody").First();
                foreach (var singleEvent in eventsGroup.SelectNodes(".//tr"))
                {
                    string eventName = singleEvent.SelectNodes(".//td[3]//a//span").First().InnerHtml;
                    _eventsNames.Add(eventName);

                    string oddsHomeString = singleEvent.SelectNodes(".//td[5]//div//div[id]").First().InnerHtml;
                    double oddsHome = Convert.ToDouble(oddsHomeString);

                    string oddsDrawString = singleEvent.SelectNodes(".//td[6]//div//div[id]").First().InnerHtml;
                    double oddsDraw = Convert.ToDouble(oddsDrawString);

                    string oddsAwayString = singleEvent.SelectNodes(".//td[7]//div//div[id]").First().InnerHtml;
                    double oddsAway = Convert.ToDouble(oddsAwayString);

                    _events.Add(new Tuple<string, double, double, double>(eventName, oddsHome, oddsDraw, oddsAway));
                }
            }
        }

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }
    }
}
