using System;
using System.Collections.Generic;

namespace SureBetExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var websiteList = new List<IBettingWebsite>();

            IBettingWebsite sportingBet = new SportingBetSite("https://pl.sportingbet.com/sporty-oferta-na-dzi%C5%9B-pi%C5%82ka-no%C5%BCna/8-102-410.html");
            IBettingWebsite betClic = new BetClicSite("https://pl.betclic.com/kalendarz/pi%C5%82ka-nozna-s1i1");
            IBettingWebsite williamHill = new WilliamHillSite("http://sports.williamhill.com/bet/pl/betting/y/5/tm/Pi%C5%82ka+no%C5%BCna.html");

            websiteList.Add(sportingBet);
            websiteList.Add(betClic);
            websiteList.Add(williamHill);

            var mainController = new MainController(websiteList);
        }
    }
}
