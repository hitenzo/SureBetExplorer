using System;
using System.Collections.Generic;
using System.Linq;

namespace SureBetExplorer
{
    public class MainController
    {
        public MainController(List<IBettingWebsite> websites)
        {
            SureBetFinder finder = new SureBetFinder(websites);
            List<SureBetInfo> sureBets = new List<SureBetInfo>();
            sureBets = finder.GetSureBets();
            if (sureBets.Any())
            {
                SureBetRepository sureBetRepository = new SureBetRepository();
                sureBetRepository.Add(sureBets);
            }
        }

    }
}
