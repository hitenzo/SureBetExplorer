using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SureBetExplorer
{
    public interface IRepository
    {
        void Add(SureBetInfo sureBet);
        void Remove(int id);
    }
}
