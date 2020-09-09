using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class CompareVersionNumbers
    {
        public int CompareVersion(string version1, string version2)
        {
            if (string.IsNullOrEmpty(version1))
            {
                return 1;
            }

            if (string.IsNullOrEmpty(version2))
            {
                return -1;
            }

            var numbers1 = version1.Split('.');
            var numbers2 = version2.Split('.');
            var len = Math.Max(numbers1.Length, numbers2.Length);

            for (int i = 0; i < len; i++)
            {
                var str1 = i < numbers1.Length ? numbers1[i] : "0";
                var str2 = i < numbers2.Length ? numbers2[i] : "0";
                
                if (str1 == str2)
                {
                    continue;
                }

                var num1 = int.Parse(str1);
                var num2 = int.Parse(str2);

                if (num1 < num2)
                {
                    return -1;
                }

                if (num1 > num2)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
