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
        private List<Tuple<string, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public BetClicSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            throw new NotImplementedException();
        }

        public List<string> GetEventsNames()
        {
            throw new NotImplementedException();
        }
    }
}
