using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public class SaveToFile
    {
        public SaveToFile(List<string> sureBets)
        {
            File.WriteAllLines(@"C:\.net projects\SureBetExplorer\SureBetExplorer\SureBetList.txt", sureBets);
        }
    }
}
