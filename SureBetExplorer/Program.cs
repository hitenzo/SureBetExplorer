using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventsList = new List<Tuple<string, double, double>>();
            var sportingBet = new SportingBetSite("https://pl.sportingbet.com/sporty-oferta-na-dzi%C5%9B-pi%C5%82ka-no%C5%BCna/8-102-410.html");
            var betClic = new BetClicSite("https://pl.betclic.com/kalendarz/pi%C5%82ka-nozna-s1i1");
            var williamHill = new WilliamHillSite("http://sports.williamhill.com/bet/pl/betting/y/5/tm/Pi%C5%82ka+no%C5%BCna.html");

            eventsList.AddRange(sportingBet.Events);
            eventsList.AddRange(betClic.Events);
            eventsList.AddRange(williamHill.Events);

            var mainController = new MainController(eventsList);
        }
    }
}
