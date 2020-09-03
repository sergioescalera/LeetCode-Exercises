using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MakeTwoArraysEqualByReversingSubArrays
    {
        public bool CanBeEqual(int[] arr_a, int[] arr_b)
        {
            if (arr_a == null || arr_b == null)
            {
                return false;
            }

            if (arr_a.Length == 0|| arr_b.Length == 0)
            {
                return false;
            }

            if (arr_a.Length != arr_b.Length)
            {
                return false;
            }

            var dict_b = ToDictionary(arr_b, (i) => false);
            var dict_a = ToDictionary(arr_a, (i) => dict_b.ContainsKey(i) == false);

            if (dict_b.Keys.Count != dict_a.Keys.Count)
            {
                return false;
            }

            foreach (var key in dict_b.Keys)
            {
                if (dict_a.ContainsKey(key) == false)
                {
                    return false;
                }

                if (dict_b[key] != dict_a[key])
                {
                    return false;
                }
            }

            return true;
        }

        private IDictionary<int, int> ToDictionary(int[] array, Func<int, bool> stop)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in array)
            {
                if (stop(item))
                {
                    break;
                }

                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            return dict;
        }
    }
}
