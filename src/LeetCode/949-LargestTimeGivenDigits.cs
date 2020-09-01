using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class LargestTimeGivenDigits
    {
        /// <summary>
        /// Example 1:
        /// Input: [1,2,3,4] Output: "23:41"
        /// Example 2:
        /// Input: [5,5,5,5] Output: ""
        /// Note:
        /// A.length == 4
        /// 0 <= A[i] <= 9
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string LargestTimeFromDigits(int[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (a.Length != 4)
            {
                throw new ArgumentException();
            }

            var maxHr = "23";
            var maxMin = "59";
            var min = "00";
            var time = GetCombinations(a)
                .Where(c => c.Item1.CompareTo(min) >= 0 && c.Item2.CompareTo(min) >= 0)
                .Where(c => c.Item1.CompareTo(maxHr) <= 0 && c.Item2.CompareTo(maxMin) <= 0)
                .Select(c => $"{c.Item1}:{c.Item2}")
                .OrderByDescending(c => c)
                .FirstOrDefault();

            return time ?? String.Empty;
        }

        private IEnumerable<Tuple<string, string>> GetCombinations(int[] a)
        {
            var indexes = Enumerable.Range(0, 4);

            foreach (var i in indexes)
            {
                var d1 = a[i];

                if (d1 > 2)
                {
                    continue;
                }

                foreach (var j in indexes.Where(j => j != i))
                {
                    var d2 = a[j];

                    foreach (var k in indexes.Where(k => k != i && k != j))
                    {
                        var d3 = a[k];

                        if (d3 > 6)
                        {
                            continue;
                        }

                        foreach (var l in indexes.Where(l => l != i && l != j && l != k))
                        {
                            var d4 = a[l];

                            yield return Tuple.Create($"{d1}{d2}", $"{d3}{d4}");
                        }
                    }
                }
            }

            yield break;
        }
    }
}
