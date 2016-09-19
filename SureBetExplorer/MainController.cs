using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public class MainController
    {
        List<string> _sureBets = new List<string>();

        public MainController(List<IBettingWebsite> websites)
        {
            SureBetFinder finder = new SureBetFinder(websites);
        }

        //TO DO: save founded events to a file
    }
}
