using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public class MainController
    {
        private List<string> _sureBets = new List<string>();

        public MainController(List<IBettingWebsite> websites)
        {
            foreach (IBettingWebsite singleWebSite in websites)
            {
                Task task = new Task( ()=> singleWebSite.ScrapeEvents() );
                task.Start();
                task.Wait();
            }

            SureBetFinder finder = new SureBetFinder(websites);
        }

        //TO DO: save founded events to a file
    }
}
