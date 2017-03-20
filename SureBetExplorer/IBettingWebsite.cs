using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public interface IBettingWebsite
    {
        void ScrapeEvents();

        List<string> GetEventsNames();

        List<Tuple<string, double, double, double>> GetEvents();

        string BookmakerName { get; set; }
    }
}
