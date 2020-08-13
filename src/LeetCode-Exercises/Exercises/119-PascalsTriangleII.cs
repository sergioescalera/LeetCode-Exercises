using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PascalsTriangleII
    {
        public static void Run()
        {
            var ex = new PascalsTriangleII();

            do
            {
                var n = ex.ReadNum("Enter row index");

                if (n == null)
                {
                    break;
                }

                var row = ex.GetRow(n.Value);

                Console.WriteLine(String.Join(", ", row));
                Console.WriteLine();

            } while (true);
        }

        static IDictionary<int, IList<int>> _cache = new Dictionary<int, IList<int>>();

        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            if (rowIndex == 0)
            {
                return new[] { 1 };
            }

            if (_cache.ContainsKey(rowIndex))
            {
                return _cache[rowIndex];
            }

            var previousRow = GetRow(rowIndex - 1);

            var row = new int[previousRow.Count + 1];

            for (int i = 0; i < row.Length; i++)
            {
                if (i == 0)
                {
                    row[0] = previousRow[0];
                }
                else if (i == row.Length - 1)
                {
                    row[row.Length - 1] = previousRow[previousRow.Count - 1];
                }
                else
                {
                    row[i] = previousRow[i - 1] + previousRow[i];
                }
            }

            _cache.Add(rowIndex, row);

            return row;
        }
    }
}
