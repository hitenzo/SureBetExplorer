using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public class SureBetFinder
    {
        private List<SureBetInfo> _sureBets = new List<SureBetInfo>();
        private List<IBettingWebsite> _websites;

        public SureBetFinder(List<IBettingWebsite> websites)
        {
            _websites = websites;
            ScrapeEvents();
            MatchEvents();
        }

        public void ScrapeEvents()
        {
            foreach (IBettingWebsite singleWebSite in _websites)
            {
                Task task = new Task(() => singleWebSite.ScrapeEvents());
                task.Start();
                task.Wait();
            }
        }

        public void MatchEvents()
        {
            for (int i = 0; i <= _websites.Count - 2; i++)
            {
                for (int j = i + 1; j <= _websites.Count - 1; j++)
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

        public List<SureBetInfo> GetSureBets()
        {
            return _sureBets;
        }

        public void DetermineSureBet(IEnumerable<string> matchingEvents, int i, int j)
        {
            foreach (var matchingEvent in matchingEvents)
            {
                Tuple<string, double, double, double> firstEventInfo = _websites[i].GetEvents().Single(t => t.Item1 == matchingEvent);
                Tuple<string, double, double, double> secondEventInfo = _websites[j].GetEvents().Single(t => t.Item1 == matchingEvent);

                double oddsHome = Math.Max(firstEventInfo.Item2, secondEventInfo.Item2);
                double oddsDraw = Math.Max(firstEventInfo.Item3, secondEventInfo.Item3);
                double oddsAway = Math.Max(firstEventInfo.Item4, secondEventInfo.Item4);

                double conditionOfEvent = (1 / oddsHome) + (1 / oddsDraw) + (1 / oddsAway);
                if (conditionOfEvent < 1)
                {
                    double betForHome = (1 / (1 / oddsHome + 1 / oddsDraw + 1 / oddsAway)) / oddsHome;
                    double betForDraw = (1 / (1 / oddsHome + 1 / oddsDraw + 1 / oddsAway)) / oddsDraw;
                    double betForAway = (1 / (1 / oddsHome + 1 / oddsDraw + 1 / oddsAway)) / oddsAway;
                    string firstSiteName = _websites[i].ToString();
                    string secondSiteName = _websites[j].ToString();

                    //_sureBets.Add(string.Format("{0}, {1} and {2} : {3} of betting money for 1, {4} for x, {5} for 2. Bet the highest possible odds from both bookmakers",
                    //    matchingEvent, firstSiteName, secondSiteName, betForHome, betForDraw, betForAway));
                    SureBetInfo sureBet = new SureBetInfo();
                    sureBet.MatchingEvent = matchingEvent;
                    sureBet.FirstSiteName = firstSiteName;
                    sureBet.SecondSiteName = secondSiteName;
                    sureBet.BetForHome = betForHome;
                    sureBet.BetForDraw = betForDraw;
                    sureBet.BetForAway = betForAway;
                    _sureBets.Add(sureBet);
                }
            }
        }
    }
}
