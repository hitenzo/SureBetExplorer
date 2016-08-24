using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    interface IBettingWebsite
    {
        List<Tuple<string, double, double>> Events { get; set; }

        void ScrapeEvents();
    }
}
