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
        private List<Tuple<string, double, double>> _events;
        private List<string> _eventsNames;
        private string _webAdress;

        public SportingBetSite(string adress)
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
