using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LongestCommonPrefixExercise
    {
        public static void Run()
        {
            var exercise = new LongestCommonPrefixExercise();

            var inputs = new[] { new[] { "flower", "flow", "flight" } };

            foreach (var input in inputs)
            {
                var solution = exercise.LongestCommonPrefix(input);

                Console.WriteLine("{0}: {1}", String.Join(", ", input), solution);
            }
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null)
                return "";

            if (strs.Length == 0)
                return "";

            if (strs.Length == 1)
                return strs[0];

            var prefix = new StringBuilder();
            var first = strs[0];

            for (int i = 0; i < first.Length; i++)
            {
                var c = first[i];

                for (int j = 1; j < strs.Length; j++)
                {
                    var str = strs[j];

                    if (str.Length <= i)
                    {
                        return prefix.ToString();
                    }

                    if (str[i] != c)
                    {
                        return prefix.ToString();
                    }
                }

                prefix.Append(c);
            }

            return prefix.ToString();
        }
    }
}
