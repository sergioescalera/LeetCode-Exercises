using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class WordBreakII
    {
        public static void Run()
        {
            var ex = new WordBreakII();

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

                var sentences = ex.WordBreak(line, words.Split(' '));

                Console.WriteLine();

                foreach (var sentence in sentences)
                {
                    Console.WriteLine(sentence);
                }

                Console.WriteLine();
                Console.WriteLine();

            } while (true);
        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (wordDict == null || wordDict.Count == 0)
                return new String[0];

            var words = new HashSet<string>(wordDict);

            return WordBreak(
                s, 
                words,
                new Dictionary<int, IList<string>>(),
                minLength: words.Select(o => o.Length).Min(),
                maxLength: words.Select(o => o.Length).Max());
        }

        private IList<string> WordBreak(
            string s, 
            HashSet<string> words,
            IDictionary<int, IList<string>> memory,
            int minLength,
            int maxLength)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (s.Length < minLength)
            {
                return new String[0];
            }

            if (memory.ContainsKey(s.Length))
            {
                return memory[s.Length];
            }

            var results = new List<string>();

            var length = Math.Min(s.Length, maxLength);

            for (int i = 1; i <= length; i++)
            {
                var word = s.Substring(0, i);

                if (words.Contains(word) == false)
                {
                    continue;
                }

                if (i == s.Length)
                {
                    results.Add(word); 
                }

                var sentences = WordBreak(s.Substring(i), words, memory, minLength, maxLength);

                foreach (var sentence in sentences)
                {
                    results.Add($"{word} {sentence}");
                }
            }

            memory.Add(s.Length, results);

            return results;
        }
    }
}
