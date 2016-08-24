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
                        DetermineSureBet(_events[i], _events[j]);
                    }
                }
            }
        }

        public List<Tuple<string, double, double>> GetSureBets()
        {
            List<Tuple<string, double, double>> sureBets = new List<Tuple<string, double, double>>();
            //TO DO: check matched events for possibility of sure bet and returns events which are sure bets
            return sureBets;
        }

        public void DetermineSureBet(Tuple<string, double, double> firstEvent, Tuple<string, double, double> secondEvent)
        {
            //TO DO: check odds if sure bet occurs, if yes add
        }

    }
}
