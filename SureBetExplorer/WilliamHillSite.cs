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
        private List<Tuple<string, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public WilliamHillSite(string adress)
        {
            _webAdress = adress;
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
                    
                }
            }
        }

        public List<string> GetEventsNames()
        {
            throw new NotImplementedException();
        }
    }
}
