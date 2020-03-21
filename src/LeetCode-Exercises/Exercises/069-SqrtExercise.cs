using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SqrtExercise
    {
        public static void Run()
        {
            var exercise = new SqrtExercise();

            //do
            //{
                for (int x = 1; x < 252525; x++)
                {
                    var sqrt = (Int32)Math.Floor(Math.Sqrt(x));

                    var solution = exercise.MySqrt(x);

                    if (sqrt.Equals(solution) == false)
                    {
                        Debugger.Break();
                    }
                }
                //Console.WriteLine("Enter n =");

                //var n = exercise.ReadNum();

                //if (n == null)
                //{
                //    return;
                //}

                //var solution = exercise.MySqrt(n.Value);

                //Console.WriteLine("sqrt(n)={0}", solution);

            //} while (true);
        }

        public int MySqrt(int x)
        {
            if (x <= 0)
            {
                return 0;
            }

            if (x == 1)
            {
                return 1;
            }

            return (int)FindBinarySearch(x, 1, x - 1);
        }

        private long FindBinarySearch(int x, long start, long end)
        {
            var s = start * start;

            if (s == x)
            {
                return start;
            }

            var e = end * end;

            if (e == x)
            {
                return end;
            }

            if (start >= end)
            {
                return e > x ? end - 1 : end;
            }

            var plus = start + end;
            var middle = plus / 2;
            
            if (plus % 2 != 0)
            {
                middle++;
            }

            if (middle == start || middle == end)
            {
                return e > x ? start : end;
            }

            var m = middle * middle;

            if (m >= x)
            {
                return FindBinarySearch(x, start, middle);
            }

            return FindBinarySearch(x, middle, end);
        }

        private int FindSqrtLinear(int x)
        {
            var h = x / 2;

            for (var i = 2; i <= h; i++)
            {
                var y = i * i;

                if (y < i)
                {
                    return i - 1;
                }

                if (y == x)
                {
                    return i;
                }

                if (y > x)
                {
                    return i - 1;
                }
            }

            return 2;
        }
    }
}
