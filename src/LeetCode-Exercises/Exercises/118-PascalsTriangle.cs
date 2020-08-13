using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercisesd
{
    [Exercise]
    public class PascalsTriangle
    {
        public static void Run()
        {
            var ex = new PascalsTriangle();

            do
            {
                var n = ex.ReadNum("Enter row index");

                if (n == null)
                {
                    break;
                }

                var list = ex.GetRow(n.Value);
                
                foreach (var row in list)
                {
                    Console.WriteLine(String.Join(", ", row));
                }
                Console.WriteLine();

            } while (true);
        }

        static IDictionary<int, IList<int>> cache = new Dictionary<int, IList<int>>();

        public IList<IList<int>> GetRow(int rowIndex)
        {
            if (rowIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            if (rowIndex == 0)
            {
                return new List<IList<int>> { new[] { 1 } };
            }

            if (cache.ContainsKey(rowIndex))
            {
                return cache.Values.ToList();
            }

            var list = GetRow(rowIndex - 1);

            var previousRow = list.Last();

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

            cache.Add(rowIndex, row);

            list.Add(row);

            return list;
        }
    }
}
