using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Bus
    {
        public int FirstArrivalTime { get; set; }
        public int Interval { get; set; }
        int lastTime;

        public Bus()
        {
            FirstArrivalTime = -1;
            Interval = -1;
            lastTime = -1;
        }

        public bool IsRightTime(int time)
        {
            // если ещё не задано время прихода и интервал то подходит
            if (FirstArrivalTime == -1 || Interval == -1)
                return true;

            // время прихода и интервал есть, надо проверить корректность

            return lastTime + Interval == time;
        }

        public bool AddTime(int time)
        {
            if (!IsRightTime(time))
                return false;

            // нет врямя прибьытия ставим его
            if (FirstArrivalTime == -1)
            {
                FirstArrivalTime = time;
            }
            // нет интервала, значит есть только вреся прибытия, обновялем знчения
            else if (Interval == -1)
            {
                Interval = time - FirstArrivalTime;
                lastTime = time;
            }
            else if (lastTime + Interval == time)
            {
                lastTime = time;
            }

            return true;
        }

        public void PopTime()
        {
            // arrvalTime == -1 => нет времён ещё, удалять нечего
            if (FirstArrivalTime != -1)
            {
                // Interval == -1 => 1 только время прибытия
                if (Interval == -1)
                {
                    FirstArrivalTime = -1;
                }
                // если время прибытия отличается на один интервал, значит удаляем 2 время, интервал обновляем
                else if (FirstArrivalTime + Interval == lastTime)
                {
                    Interval = -1;
                }
                // удаляём 3+ время, обновляемс только предыдущее значение
                else
                {
                    lastTime -= Interval;
                }
            }
        }
    }
}
