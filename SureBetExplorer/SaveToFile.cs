using System;
using System.Collections.Generic;
using System.IO;

namespace SureBetExplorer
{
    public class SaveToFile
    {
        public SaveToFile(List<string> sureBets)
        {
            File.WriteAllLines(@"C:\Users\hitenz\folderTest\SureBetList.txt", sureBets);
        }
    }
}
