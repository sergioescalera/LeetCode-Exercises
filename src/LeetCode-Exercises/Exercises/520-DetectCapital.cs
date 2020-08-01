using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class DetectCapital
    {
        public static void Run()
        {
            var ex = new  DetectCapital();

            do
            {
                Console.WriteLine("Enter word");

                var word = Console.ReadLine();

                if (String.IsNullOrEmpty(word))
                {
                    break;
                }

                var capital = ex.DetectCapitalUse(word);

                Console.WriteLine(capital ? "Correct" : "Incorrect");
                Console.WriteLine();

            } while (true);
        }

        public bool DetectCapitalUse(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                return false;
            }

            var lower = 0;
            var upper = 0;

            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];

                var u = char.IsUpper(c);
                var l = char.IsLower(c);

                if (u && lower > 0)
                {
                    return false;
                }

                if (l && upper > 1)
                {
                    return false;
                }

                if (l)
                {
                    lower++;
                }

                else if (u)
                {
                    upper++;
                }
            }

            return lower == word.Length
                || upper == word.Length
                || (upper == 1 &&  lower== word.Length - 1 && char.IsUpper(word[0]));
        }
    }
}
