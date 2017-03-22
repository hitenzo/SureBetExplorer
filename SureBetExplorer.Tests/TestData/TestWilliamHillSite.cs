using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer.Tests.TestData
{
    public class TestWilliamHillSite : IBettingWebsite
    {
        private List<Tuple<string, double, double, double>> _events = new List<Tuple<string, double, double, double>>
        {
            new Tuple<string, double, double, double> ("Anderlecht - Apoel Nikozja", double.Parse("4,10"), double.Parse("4,0"), double.Parse("5,80")),
            new Tuple<string, double, double, double> ("Roma - Lyon", double.Parse("1,0"), double.Parse("1,0"), double.Parse("1,0")),
            new Tuple<string, double, double, double> ("Ajax - FC Kopenhaga", double.Parse("1,0"), double.Parse("1,0"), double.Parse("1,0"))
        };

        private List<string> _eventsNames = new List<string>
        {
            "Anderlecht - Apoel Nikozja",
            "Roma - Lyon",
            "Ajax - FC Kopenhaga"
        };

        private string _bookMakerSite;
        public string BookmakerName
        {
            get { return "WilliamHill"; }
            set { _bookMakerSite = value; }
        }

        private string _webAdress = "Mock";

        public List<string> GetEventsNames()
        {
            return _eventsNames;
        }

        public List<Tuple<string, double, double, double>> GetEvents()
        {
            return _events;
        }

        public void ScrapeEvents()
        {
            //Console.WriteLine("hello!");
        }
    }
}
