using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SureBetExplorer
{
    class SportingBetSite: IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public SportingBetSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(_webAdress);

            HtmlNode wrapper = document.DocumentNode.SelectNodes("//div[@class='TeamTieCoupon']")[2];
            foreach (var singleEvent in wrapper.SelectNodes(".//div[@class='couponEvents']//div[@class='event']"))
            {
                string eventName = singleEvent.SelectNodes(".//div[@class='columns']//div[@class='eventInfo']//div[@class='eventName']//a").First().InnerHtml;
                _eventsNames.Add(eventName);

                HtmlNode homeInfo = singleEvent.SelectNodes(".//div[@class='columns']//div[@class='selections']//div[@class='market']//div[@class='home']").First();
                string oddsHomeString = homeInfo.SelectNodes(".//div[@id='isOffered']//a[@class='price']//span[@class='EU']").First().InnerHtml;
                double oddsHome = Convert.ToDouble(oddsHomeString);

                HtmlNode drawInfo = singleEvent.SelectNodes(".//div[@class='columns']//div[@class='selections']//div[@class='market']//div[@class='draw']").First();
                string oddsDrawString = drawInfo.SelectNodes(".//div[@id='isOffered']//a[@class='price']//span[@class='EU']").First().InnerHtml;
                double oddsDraw = Convert.ToDouble(oddsDrawString);

                HtmlNode awayInfo = singleEvent.SelectNodes(".//div[@class='columns']//div[@class='selections']//div[@class='market']//div[@class='away']").First();
                string oddsAwayString = awayInfo.SelectNodes(".//div[@id='isOffered']//a[@class='price']//span[@class='EU']").First().InnerHtml;
                double oddsAway = Convert.ToDouble(oddsAwayString);

                _events.Add(new Tuple<string, double, double, double>(eventName, oddsHome, oddsDraw, oddsAway));
            }
        }

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }
    }
}
