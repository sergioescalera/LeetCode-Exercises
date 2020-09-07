using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class PermutationInString
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (String.IsNullOrEmpty(s1))
                return true;

            if (String.IsNullOrEmpty(s2))
                return false;

            if (s1.Length > s2.Length)
                return false;

            var dict1 = ProcessStr(s1);
            var dict2 = default(IDictionary<char, int>);

            for (int i = 0; i <= s2.Length - s1.Length; i++)
            {
                if (i == 0)
                {
                    dict2 = ProcessStr(s2.Substring(0, s1.Length));
                }
                else
                {
                    var prev = s2[i - 1];
                    var next = s2[i + s1.Length - 1];

                    if (dict2[prev] == 1)
                    {
                        dict2.Remove(prev);
                    }
                    else
                    {
                        dict2[prev]--;
                    }

                    if (dict2.ContainsKey(next))
                    {
                        dict2[next]++;
                    }
                    else
                    {
                        dict2.Add(next, 1);
                    }
                }

                if (Check(dict1, dict2))
                {
                    return true;
                }
            }

            return false;
        }

        private bool Check(
            IDictionary<char, int> dict1, 
            IDictionary<char, int> dict2)
        {
            if (dict1.Keys.Count != dict2.Keys.Count)
            {
                return false;
            }

            foreach (var key in dict1.Keys)
            {
                if (dict2.ContainsKey(key) == false)
                {
                    return false;
                }

                if (dict1[key] != dict2[key])
                {
                    return false;
                }
            }

            return true;
        }

        private IDictionary<char, int> ProcessStr(string str)
        {
            return str
                .GroupBy(c => c)
                .ToDictionary(c => c.Key, c => c.Count());
        }
    }
}
