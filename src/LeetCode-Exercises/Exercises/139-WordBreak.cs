using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class WordBreakI
    {
        public static void Run()
        {
            var ex = new WordBreakI();

            do
            {
                Console.WriteLine("Enter text");

                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                    break;

                Console.WriteLine("Enter words");

                var words = Console.ReadLine();

                if (string.IsNullOrEmpty(words))
                    break;

                var val = ex.WordBreak(line, words.Split(' '));

                Console.WriteLine("Result {0}", val);

                Console.WriteLine();
                Console.WriteLine();

            } while (true);
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (wordDict == null || wordDict.Count == 0)
                return false;

            var words = new HashSet<string>(wordDict);

            return WordBreak(
                s,
                words,
                new Dictionary<int, bool>());
        }

        private bool WordBreak(
            string s,
            HashSet<string> words,
            IDictionary<int, bool> memory)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (memory.ContainsKey(s.Length))
            {
                return memory[s.Length];
            }

            for (int i = 1; i <= s.Length; i++)
            {
                var word = s.Substring(0, i);

                if (words.Contains(word) == false)
                {
                    continue;
                }

                if (i == s.Length)
                {
                    return true;
                }

                var val = WordBreak(s.Substring(i), words, memory);

                if (val)
                {
                    return true;
                }
            }

            memory.Add(s.Length, false);

            return false;
        }
    }
}
