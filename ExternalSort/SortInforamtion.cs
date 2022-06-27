using System.Diagnostics;

namespace ExternalSort
{
    public class SortInformation
    {
        public int ComparesNumber { get; set; }
        public int PassesNumber { get; set; }
        public Stopwatch ElapsedTime { get; set; }

        public SortInformation()
        {
            ComparesNumber = 0;
            PassesNumber = 0;
            ElapsedTime = new Stopwatch();
        }
    }
}
