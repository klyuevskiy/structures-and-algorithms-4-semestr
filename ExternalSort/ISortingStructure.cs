using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    interface ISortingStructure
    {
        void Add(int number, int fileIndex);
        (int, int) GetMin();
        int ComparesNumber { get; }
        bool IsEmpty();
    }
}
