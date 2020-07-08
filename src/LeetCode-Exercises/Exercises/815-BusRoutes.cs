using LeetCode.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class BusRoutes
    {
        public static void Run()
        {
            /*
             * 
Example:
Input: 
routes = [[1, 2, 7], [3, 6, 7]]
S = 1
T = 6
Output: 2
Explanation: 
The best strategy is take the first bus to the bus stop 7, then take the second bus to the bus stop 6.

             */
        }

        public int NumBusesToDestination(int[][] routes, int s, int t)
        {
            if (routes == null || routes.Length == 0)
            {
                return -1;
            }

            var sets = routes
                .Select(r => new SortedSet<int>(r))
                .ToArray();

            return NumBusesToDestination(sets, s, t);
        }

        private int NumBusesToDestination(SortedSet<int>[] routes, int start, int end)
        {
            if (start == end)
            {
                return 0;
            }

            var visited = new HashSet<int>();
            var taken = new HashSet<int>();
            var queue = new Queue<BusCount>();
            
            visited.Add(start);

            for (int i = 0; i < routes.Length; i++)
            {
                var route = routes[i];

                if (route.Contains(start) == false)
                {
                    continue;
                }

                if (route.Contains(end))
                {
                    return 1;
                }

                queue.Enqueue(new BusCount
                {
                    count = 1,
                    route = route
                });

                taken.Add(i);
            }
            
            while (queue.Count > 0)
            {
                var bus = queue.Dequeue();

                foreach (var stop in bus.route)
                {
                    for (int i = 0; i < routes.Length; i++)
                    {
                        var route = routes[i];

                        if (taken.Contains(i))
                        {
                            continue;
                        }

                        if (route.Contains(stop) == false)
                        {
                            continue;
                        }

                        if (route.Contains(end))
                        {
                            return bus.count + 1;
                        }

                        queue.Enqueue(new BusCount
                        {
                            count = bus.count + 1,
                            route = route
                        });

                        taken.Add(i);
                    }
                }
            }

            return -1;
        }

        class BusCount
        {
            public int count;

            public SortedSet<int> route;
        }
    }
}
