using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    /// <summary>
    /// 1 <= hour <= 12
    /// 0 <= minutes <= 59
    /// Answers within 10^-5 of the actual value will be accepted as correct.
    /// </summary>
    [Exercise]
    public class AngleBetweenHandsClock
    {
        public static void Run()
        {
            var ex = new AngleBetweenHandsClock();

            do
            {
                var h = ex.ReadNum("Enter hour");

                if (h == null)
                    break;

                var m = ex.ReadNum("Enter min");

                if (m == null)
                    break;

                var angle = ex.AngleClock(h.Value, m.Value);

                Console.WriteLine("The angle is {0}", angle);
                Console.WriteLine();

            } while (true);
        }

        public double AngleClock(int hour, int minutes)
        {
            if (hour < 1 || hour > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes));
            }

            var minPosition = minutes / 60.0;

            var minDegree = minPosition * 360.0;

            var hourPosition = (hour == 12 ? 0 : hour / 12.0) + minPosition / 12;

            var hourDegree = hourPosition * 360.0;

            var diff = Math.Abs(minDegree - hourDegree);

            return diff > 180 ? 360 - diff : diff;
        }
    }
}
