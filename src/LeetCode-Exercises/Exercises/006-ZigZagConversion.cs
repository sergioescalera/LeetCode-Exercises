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
    public class ZigZagConversion
    {
        public static void Run()
        {
            var exercise = new ZigZagConversion();

            do
            {
                Console.WriteLine("Enter line");
                var s = Console.ReadLine();
                var r = exercise.ReadNum("Enter rows");

                if (String.IsNullOrEmpty(s) || r == null)
                    break;

                var z = exercise.Convert(s, r.Value);

                Console.WriteLine("ZigZag({0}, {1})={2}", s, r, z);

            } while (true);
        }

        public string Convert(string s, int numRows)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            if (numRows <= 1)
                return s;

            if (s.Length <= numRows)
                return s;

            var m = new Dictionary<int, char>[numRows];

            var col = 0;
            var row = 0;
            var down = true;

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (down)
                {
                    if (row < numRows)
                    {
                        m[row] = m[row] ?? new Dictionary<int, char>();

                        m[row][col] = c;

                        row++;
                    }
                    else
                    {
                        down = false;

                        row -= 2;
                        col++;

                        m[row][col] = c;

                        row--;
                        col++;
                    }
                }
                else
                {
                    if (row >= 0)
                    {
                        m[row][col] = c;

                        row--;
                        col++;
                    }
                    else
                    {
                        down = true;

                        col--;
                        row += 2;

                        m[row][col] = c;

                        row++;
                    }
                }
            }

            var result = new StringBuilder();

            for (int i = 0; i < numRows; i++)
            {
                var line = m[i];

                result.Append(String.Concat(line.Values));
            }

            return result.ToString();
        }
    }
}
