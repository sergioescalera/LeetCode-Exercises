using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ClimbingStairs
    {
        public static void Run()
        {
            var exercise = new ClimbingStairs();

            do
            {
                var n = exercise.ReadNum();

                if (n == null)
                    break;

                var s = exercise.ClimbStairs(n.Value);

                Console.WriteLine("{0}={1}", n, s);

            } while (true);
        }

        static IDictionary<int, int> storage = new Dictionary<int, int>();

        public int ClimbStairs(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            if (storage.ContainsKey(n))
            {
                return storage[n];
            }

            var s = ClimbStairs(n - 2) + ClimbStairs(n - 1);

            storage[n] = s;

            return s;
        }
    }
}
