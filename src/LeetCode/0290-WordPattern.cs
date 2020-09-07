using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class WordPatternSolution
    {
        public bool WordPattern(string pattern, string str)
        {
            if (String.IsNullOrEmpty(pattern) ||
                String.IsNullOrEmpty(str))
            {
                return false;
            }

            var words = str.Split(' ');

            if (words.Length != pattern.Length)
            {
                return false;
            }

            var map1 = new Dictionary<char, String>();
            var map2 = new Dictionary<String, char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                var c = pattern[i];

                var word = words[i];

                var known1 = map1.ContainsKey(c);

                var known2 = map2.ContainsKey(word);

                if (known1 != known2)
                {
                    return false;
                }

                if (known1 && (map1[c] != word || map2[word] != c))
                {
                    return false;
                }

                if (!known1)
                {
                    map1.Add(c, word);

                    map2.Add(word, c);
                }
            }

            return true;
        }
    }
}
