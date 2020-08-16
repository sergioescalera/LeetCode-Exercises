using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class NonOverlappingIntervals
    {
        public static void Run()
        {
            var intervals = new[]
            {
                new [] { -100,-87 },
                new [] {-99,-44},
                new [] {-98,-19},
                new [] {-97,-33},
                new [] {-96,-60},
                new [] {-95,-17},
                new [] {-94,-44}, new [] {-93,-9}, new [] {-92,-63}, new [] {-91,-76}, new [] {-90,-44}, new [] {-89,-18}, new [] {-88,10}, new [] {-87,-39}, new [] {-86,7}, new [] {-85,-76}, new [] {-84,-51}, new [] {-83,-48}, new [] {-82,-36}, new [] {-81,-63}, new [] {-80,-71}, new [] {-79,-4}, new [] {-78,-63}, new [] {-77,-14}, new [] {-76,-10}, new [] {-75,-36}, new [] {-74,31}, new [] {-73,11}, new [] {-72,-50}, new [] {-71,-30}, new [] {-70,33}, new [] {-69,-37}, new [] {-68,-50}, new [] {-67,6}, new [] {-66,-50}, new [] {-65,-26}, new [] {-64,21}, new [] {-63,-8}, new [] {-62,23}, new [] {-61,-34}, new [] {-60,13}, new [] {-59,19}, new [] {-58,41}, new [] {-57,-15}, new [] {-56,35}, new [] {-55,-4}, new [] {-54,-20}, new [] {-53,44}, new [] {-52,48}, new [] {-51,12}, new [] {-50,-43}, new [] {-49,10}, new [] {-48,-34}, new [] {-47,3}, new [] {-46,28}, new [] {-45,51}, new [] {-44,-14}, new [] {-43,59}, new [] {-42,-6}, new [] {-41,-32}, new [] {-40,-12}, new [] {-39,33}, new [] {-38,17}, new [] {-37,-7}, new [] {-36,-29}, new [] {-35,24}, new [] {-34,49}, new [] {-33,-19}, new [] {-32,2}, new [] {-31,8}, new [] {-30,74}, new [] {-29,58}, new [] {-28,13}, new [] {-27,-8}, new [] {-26,45}, new [] {-25,-5}, new [] {-24,45}, new [] {-23,19}, new [] {-22,9}, new [] {-21,54}, new [] {-20,1}, new [] {-19,81}, new [] {-18,17}, new [] {-17,-10}, new [] {-16,7}, new [] {-15,86}, new [] {-14,-3}, new [] {-13,-3}, new [] {-12,45}, new [] {-11,93}, new [] {-10,84}, new [] {-9,20}, new [] {-8,3}, new [] {-7,81}, new [] {-6,52}, new [] {-5,67}, new [] {-4,18}, new [] {-3,40}, new [] {-2,42}, new [] {-1,49}, new [] {0,7}, new [] {1,104}, new [] {2,79}, new [] {3,37}, new [] {4,47}, new [] {5,69}, new [] {6,89}, new [] {7,110}, new [] {8,108}, new [] {9,19}, new [] {10,25}, new [] {11,48}, new [] {12,63}, new [] {13,94}, new [] {14,55}, new [] {15,119}, new [] {16,64}, new [] {17,122}, new [] {18,92}, new [] {19,37}, new [] {20,86}, new [] {21,84}, new [] {22,122}, new [] {23,37}, new [] {24,125}, new [] {25,99}, new [] {26,45}, new [] {27,63}, new [] {28,40}, new [] {29,97}, new [] {30,78}, new [] {31,102}, new [] {32,120}, new [] {33,91}, new [] {34,107}, new [] {35,62}, new [] {36,137}, new [] {37,55}, new [] {38,115}, new [] {39,46}, new [] {40,136}, new [] {41,78}, new [] {42,86}, new [] {43,106}, new [] {44,66}, new [] {45,141}, new [] {46,92}, new [] {47,132}, new [] {48,89}, new [] {49,61}, new [] {50,128}, new [] {51,155}, new [] {52,153}, new [] {53,78}, new [] {54,114}, new [] {55,84}, new [] {56,151}, new [] {57,123}, new [] {58,69}, new [] {59,91}, new [] {60,89}, new [] {61,73}, new [] {62,81}, new [] {63,139}, new [] {64,108}, new [] {65,165}, new [] {66,92}, new [] {67,117}, new [] {68,140}, new [] {69,109}, new [] {70,102}, new [] {71,171}, new [] {72,141}, new [] {73,117}, new [] {74,124}, new [] {75,171}, new [] {76,132}, new [] {77,142}, new [] {78,107}, new [] {79,132}, new [] {80,171}, new [] {81,104}, new [] {82,160}, new [] {83,128}, new [] {84,137}, new [] {85,176}, new [] {86,188}, new [] {87,178}, new [] {88,117}, new [] {89,115}, new [] {90,140}, new [] {91,165}, new [] {92,133}, new [] {93,114}, new [] {94,125}, new [] {95,135}, new [] {96,144}, new [] {97,114}, new [] {98,183}, new [] {99,157 }
            };

            var ex = new NonOverlappingIntervals();

            ex.EraseOverlapIntervals(intervals);
        }

        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            if (intervals.Length == 0)
            {
                return 0;
            }

            var removed = new List<int>();
            var sorted = intervals
                .OrderBy(o => o[0])
                .ThenBy(o => o[1])
                .ToArray();
            var previous = 0;

            for (int i = 1; i < sorted.Length; i++)
            {
                var a = sorted[previous];
                var b = sorted[i];

                if (a[1] <= b[0])
                {
                    previous = i;

                    continue;
                }

                if (a[1] < b[1])
                {
                    removed.Add(i);
                }
                else
                {
                    removed.Add(previous);
                    previous = i;
                }
            }

            return removed.Count;
        }
    }
}
