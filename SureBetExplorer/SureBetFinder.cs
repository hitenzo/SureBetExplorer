using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    class SureBetFinder
    {
        //private List<Tuple<string, double, double>> _events;
        //private List<Tuple<string, double, double>> _matchedEvents;
        //private List<Tuple<string, double, double>> _sureBets;
        private List<IBettingWebsite> _websites;

        public SureBetFinder(List<IBettingWebsite> websites)
        {
            _websites = websites;
            Match();
        }

        public void Match()
        {
            
        }

        public List<Tuple<string, double, double, double>> GetSureBets()
        {
            List<Tuple<string, double, double, double>> sureBets = new List<Tuple<string, double, double, double>>();
            //DeterminSureBet()
            return sureBets;
        }

        public void DetermineSureBet(Tuple<string, double, double, double> firstEvent, Tuple<string, double, double, double> secondEvent)
        {
            //TO DO: check odds if sure bet occurs
        }

    }
}
