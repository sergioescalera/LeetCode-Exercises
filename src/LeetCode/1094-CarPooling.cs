using System;
using System.Linq;

namespace LeetCode
{
    public class CarPoolingSolution
    {
        public bool CarPooling(int[][] trips, int capacity)
        {
            if (trips == null)
            {
                throw new ArgumentNullException(nameof(trips));
            }

            if (trips.Length == 0)
            {
                return true;
            }

            if (capacity < 0)
            {
                return false;
            }

            var sorted = trips
                .Select(trip => new
                {
                    passengers = trip[0],
                    location = trip[1]
                })
                .Concat(trips
                .Select(trip => new
                {
                    passengers = -1 * trip[0],
                    location = trip[2]
                }))
                .GroupBy(o => o.location)
                .OrderBy(o => o.Key)
                .ToArray();

            var current = 0;

            foreach (var location in sorted)
            {
                var passengers = location.Sum(o => o.passengers);

                current += passengers;

                if (current > capacity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
