using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LetterCombinationsPhoneNumbe
    {
        public static void Run()
        {
            var exercise = new LetterCombinationsPhoneNumbe();

            do
            {
                Console.WriteLine("Enter digits");

                var line = Console.ReadLine();

                if (String.IsNullOrEmpty(line))
                    break;

                var list = exercise.LetterCombinations(line);

                Console.WriteLine(String.Join(", ", list));

            } while (true);
        }

        static readonly IDictionary<char, string[]> mapping = new Dictionary<char, string[]>
        {
            {  '2', new [] { "a", "b", "c" } },
            {  '3', new [] { "d", "e", "f" } },
            {  '4', new [] { "g", "h", "i" } },
            {  '5', new [] { "j", "k", "l" } },
            {  '6', new [] { "m", "n", "o" } },
            {  '7', new [] { "p", "q", "r", "s" } },
            {  '8', new [] { "t", "u", "v" } },
            {  '9', new [] { "w", "x", "y", "z" } }
        };

        public IList<string> LetterCombinations(string digits)
        {
            return LetterCombinations(digits, 0);
        }

        private IList<string> LetterCombinations(string digits, int index)
        {
            if (digits == null)
                return new string[0];

            if (index >= digits.Length)
                return new string[0];

            var digit = digits[index];

            if (mapping.ContainsKey(digit) == false)
                return new string[0];

            var letters = mapping[digit];

            if (index == digits.Length - 1)
                return letters;

            var combinations = LetterCombinations(digits, index + 1);

            var result = new List<String>();

            foreach (var letter in letters)
            {
                foreach (var combination in combinations)
                {
                    result.Add($"{letter}{combination}");
                }
            }

            return result;
        }
    }
}
