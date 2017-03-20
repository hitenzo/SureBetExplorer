using System;
using System.Collections.Generic;
using System.Linq;

namespace SureBetExplorer
{
    public class MainController
    {
        private List<SureBetInfo> sureBets = new List<SureBetInfo>();

        public MainController(List<IBettingWebsite> websites)
        {
            SureBetFinder finder = new SureBetFinder(websites);
            sureBets = finder.GetSureBets();
            if (sureBets.Any())
            {
                // to do: save sure bets
                //SaveToFile saver = new SaveToFile(sureBets);
            }
        }
    }
}
