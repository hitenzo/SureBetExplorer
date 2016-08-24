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

        public SureBetFinder(List<Tuple<string, double, double>> events)
        {
            _events = events;
            Match();
            _sureBets = GetSureBets();
        }

        public void Match()
        {
            for (int i = 0; i <= _events.Count - 2; i++)
            {
                for (int j = i + 1; j <= _events.Count - 1; j++)
                {
                    if (_events[i].Item1 == _events[j].Item1)
                    {
                        _matchedEvents.Add(_events[i]);
                        _matchedEvents.Add(_events[j]);
                    }
                }
            }
        }

        public List<Tuple<string, double, double>> GetSureBets()
        {
            List<Tuple<string, double, double>> sureBets;
            //TO DO: check matched events for possibility of sure bet and returns events which are sure bets
        }

    }
}
