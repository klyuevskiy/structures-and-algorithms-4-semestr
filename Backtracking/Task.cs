using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    static class Task
    {
        // по интервалам движения автобусов посторить их времена прибытия
        static int[] GetArrivalTimes(List<int> timesIntervals)
        {
            int[] arrivalTimes = new int[timesIntervals.Count];

            // время прибытия 1 = первому интервалу
            arrivalTimes[0] = timesIntervals[0];

            // далее к каждому времени прибтия прибаляем интервал
            for (int i = 1; i < timesIntervals.Count; i++)
            {
                arrivalTimes[i] = arrivalTimes[i - 1] + timesIntervals[i];
            }

            return arrivalTimes;
        }

        static bool CheckBuses(int[] arrivalTimes, int timePosition, List<Bus> buses)
        {
            // прошли все времена, возвращем истину
            if (timePosition == arrivalTimes.Length)
                return true;

            foreach (Bus bus in buses)
            {
                // к этому автобусу подходит время, пробуем его
                if (bus.AddTime(arrivalTimes[timePosition]))
                {
                    // перебор успешен
                    if (CheckBuses(arrivalTimes, timePosition + 1, buses))
                        return true;
                    else
                        bus.PopTime();
                }
            }

            // всё прошли, значит нет подходящих
            return false;
        }

        // метод решения задачи, принимает интревалы даижения автобусов, возвращает автобусы
        static public List<Bus> Solve(List<int> timesIntervals)
        {
            // по интервалам получить времена прибытия автобусов
            int[] arrivalTimes = GetArrivalTimes(timesIntervals);

            // список автобусов
            List<Bus> buses = new List<Bus>();

            // пока такое кол-во автобусов не подойдёт, добавляем ещё один
            while (!CheckBuses(arrivalTimes, 0, buses))
            {
                // каждый раз добавляем новый автобус
                buses.Add(new Bus());
            }

            return buses;
        }
    }
}
