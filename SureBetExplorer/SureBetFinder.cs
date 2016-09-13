using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    class SureBetFinder
    {
        private List<Tuple<string, double, double>> _events;
        private List<Tuple<string, double, double>> _matchedEvents;
        private List<Tuple<string, double, double>> _sureBets;
        private List<IBettingWebsite> _websites;

        public SureBetFinder(List<IBettingWebsite> websites)
        {
            _websites = websites;
            MatchEvents();
        }

        public void MatchEvents()
        {
            for (int i=0; i<=_websites.Count-2; i++)
            {
                for (int j=i+1; j<=_websites.Count-1; j++)
                {
                    IBettingWebsite website = _websites[i];
                    List<string> matchingEvents = website.GetEventsNames().Intersect(_websites[j].GetEventsNames()).ToList();

                    if (matchingEvents.Any())
                    {
                        DetermineSureBet(matchingEvents, i, j);
                    }
                }
            }
        }

        public List<Tuple<string, double, double, double>> GetSureBets()
        {
            List<Tuple<string, double, double, double>> sureBets = new List<Tuple<string, double, double, double>>();
            return sureBets;
        }

        public void DetermineSureBet(IEnumerable<string> matchingEvents, int i, int j)
        {
        }

    }
}
