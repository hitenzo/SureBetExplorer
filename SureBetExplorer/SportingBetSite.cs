using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    class SportingBetSite: IBettingWebsite
    {
        public List<Tuple<string, double, double>> Events { get; set; }
        private string _webAdress;

        public SportingBetSite(string adress)
        {
            _webAdress = adress;
        }

        public void ScrapeEvents()
        {
            throw new NotImplementedException();
        }
    }
}
