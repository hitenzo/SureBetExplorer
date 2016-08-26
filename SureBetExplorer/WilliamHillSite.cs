using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SureBetExplorer
{
    class WilliamHillSite: IBettingWebsite
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
            HtmlDocument document = web.Load("http://www.c-sharpcorner.com");
        }

        public List<string> GetEventsNames()
        {
            throw new NotImplementedException();
        }
    }
}
