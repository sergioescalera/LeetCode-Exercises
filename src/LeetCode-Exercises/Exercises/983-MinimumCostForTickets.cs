using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class MinimumCostForTickets
    {
        public static void Run()
        {
            var ex = new MinimumCostForTickets();

            do
            {
                var days = ex.ReadNums("Enter days");

                if (days == null)
                {
                    break;
                }

                var costs = ex.ReadNums("Enter costs");

                if (costs == null)
                {
                    break;
                }

                var cost = ex.MincostTickets(days, costs);

                Console.WriteLine("Min cost is {0}", cost);

            } while (true);
        }

        public int MincostTickets(int[] days, int[] costs)
        {
            if (days == null)
            {
                throw new ArgumentNullException(nameof(days));
            }

            if (costs == null)
            {
                throw new ArgumentNullException(nameof(costs));
            }

            if (days.Length < 1 || days.Length > 365)
            {
                throw new ArgumentException("Days length is not valid");
            }

            if (costs.Length != 3)
            {
                throw new ArgumentException("Costs length not in range");
            }

            return MincostTickets(days, costs, 0, -1, new Dictionary<string, int>());
        }

        private int MincostTickets(
            int[] days, 
            int[] costs, 
            int index, 
            int lastDayCovered,
            IDictionary<string, int> memory)
        {
            if (index >= days.Length)
            {
                return 0;
            }

            var day = days[index];

            if (day <= lastDayCovered)
            {
                return MincostTickets(days, costs, index + 1, lastDayCovered, memory);
            }

            var key = $"{index}_{lastDayCovered}";

            if (memory.ContainsKey(key))
            {
                return memory[key];
            }

            var _1daypass = costs[0];
            var _1daycost = MincostTickets(days, costs, index + 1, day, memory);

            var _7daypass = costs[1];
            var _7daycost = MincostTickets(days, costs, index + 1, day + 7 - 1, memory);

            var _30daypass = costs[2];
            var _30daycost = MincostTickets(days, costs, index + 1, day + 30 - 1, memory);

            var min = Math.Min(Math.Min(
                _1daypass + _1daycost, 
                _7daypass + _7daycost),
                _30daypass + _30daycost);

            memory.Add(key, min);

            return min;
        }
    }
}
