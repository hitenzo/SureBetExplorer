using System;
using System.Collections.Generic;
using System.Linq;

namespace SureBetExplorer
{
    public class MainController
    {
        private List<string> sureBets = new List<string>();

        public MainController(List<IBettingWebsite> websites)
        {
            SureBetFinder finder = new SureBetFinder(websites);
            sureBets = finder.GetSureBets();
            if (sureBets.Any())
            {
                SaveToFile saver = new SaveToFile(sureBets);
            }
        }
    }
}
