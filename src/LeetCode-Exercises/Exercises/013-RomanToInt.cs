using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RomanToIntConverter
    {
        public static void Run()
        {
            var exercise = new RomanToIntConverter();

            var input = new[] { "XX", "III", "IX", "IV", "LVIII", "MCMXCIV" };

            foreach (var r in input)
            {
                var v = exercise.RomanToInt(r);

                Console.WriteLine($"Result: {r} = {v}");
            }
        }

        IDictionary<Char, Int32> symbols = new Dictionary<Char, Int32>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int RomanToInt(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            var c = s[0];

            var v = symbols[c];

            var z = s.Substring(1);

            var r = RomanToInt(z);

            if (z.Length == 0 || v >= symbols[z[0]])
            {
                return v + r;
            }

            return r - v;
        }
    }
}
