using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PermutationSequence
    {
        public static void Run()
        {
            var exercise = new PermutationSequence();

            do
            {
                var n = exercise.ReadNum();
                
                if (n == null)
                {
                    return;
                }

                var k = exercise.ReadNum();

                if (k == null)
                {
                    return;
                }

                var p = exercise.GetPermutation(n.Value, k.Value);

                Console.WriteLine("n={0}, k={1}: {2}", n, k, p);

            } while (true);
        }

        public string GetPermutation(int n, int k)
        {
            if (n < 1 || n > 9)
            {
                throw new ArgumentOutOfRangeException("n");
            }

            if (k < 1)
            {
                throw new ArgumentOutOfRangeException("k");
            }

            var numbers = Enumerable.Range(1, n).ToList();
            var permut = new List<int>();
            var counter = 0;

            if (Permut(numbers, k, permut, ref counter))
            {
                return String.Join("", permut);
            }

            return "";
        }

        private bool Permut(
            List<int> source,
            int stop,
            List<int> current,
            ref int counter)
        {
            var count = source.Count;

            if (count == 0)
            {
                counter++;

                return counter == stop;
            }

            for (var i = 0; i < count; i++)
            {
                var elem = source[i];

                current.Add(elem);
                source.RemoveAt(i);
                
                if (Permut(source, stop, current, ref counter))
                {
                    return true;
                }

                current.RemoveAt(current.Count - 1);
                source.Insert(i, elem);
            }

            return false;
        }
    }
}
