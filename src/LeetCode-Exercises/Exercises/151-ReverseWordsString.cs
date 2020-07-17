using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ReverseWordsString
    {
        public static void Run()
        {
            var ex = new ReverseWordsString();

            do
            {
                Console.WriteLine("Enter words");

                var words = Console.ReadLine();

                if (String.IsNullOrEmpty(words))
                    break;

                var reverse = ex.ReverseWords(words);

                Console.WriteLine(reverse);
                Console.WriteLine();

            } while (true);
        }

        public string ReverseWords(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return String.Empty;

            var words = FindWords(s).Reverse();

            var sb = new StringBuilder();

            foreach (var word in words)
            {
                sb.Append(s.Substring(word.index, word.length));
                sb.Append(' ');
            }
            
            return sb.ToString().TrimEnd();
        }

        private IEnumerable<Word> FindWords(string s)
        {
            var index = 0;

            do
            {
                var word = FindWord(s, index);

                if (word == null)
                {
                    break;
                }

                yield return word;

                index = word.index + word.length;

            } while (true);

            yield break;
        }

        private Word FindWord(string s, int index)
        {
            while (index < s.Length && s[index] == ' ')
            {
                index++;
            }

            if (index < s.Length)
            {
                return new Word
                {
                    index = index,
                    length = FindWordEnd(s, index) - index
                };
            }

            return null;
        }

        private int FindWordEnd(string s, int index)
        {
            while (index < s.Length && s[index] != ' ')
            {
                index++;
            }

            return index;
        }

        class Word
        {
            public int index;

            public int length;
        }
    }
}
