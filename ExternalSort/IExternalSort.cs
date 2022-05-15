using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    public interface IExternalSort
    {
        void Sort(SortFile sortedFile);
    }
}
