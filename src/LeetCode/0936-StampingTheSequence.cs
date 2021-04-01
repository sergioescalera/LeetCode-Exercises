using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class StampingTheSequence
    {
        public int[] MovesToStamp(string stamp, string target)
        {

            if (string.IsNullOrEmpty(stamp) ||
                string.IsNullOrEmpty(target))
            {
                return Array.Empty<int>();
            }

            var result = new List<int>();

            var replace = new string(Enumerable.Repeat('?', stamp.Length).ToArray());

            var total = 0;

            var index = -1;

            while (total < target.Length)
            {
                var count = 0;

                for (int n = stamp.Length; n > 0; n--)
                {
                    var temp1 = stamp.Substring(0, n).PadRight(stamp.Length, '?');
                    var temp2 = stamp.Substring(stamp.Length - n, n).PadLeft(stamp.Length, '?');

                    index = target.IndexOf(temp1);

                    while (index >= 0)
                    {
                        target = target.Substring(0, index) + replace + target.Substring(index + replace.Length);

                        result.Add(index);

                        count += n;

                        index = target.IndexOf(temp1);
                    }

                    index = target.IndexOf(temp2);

                    while (index >= 0)
                    {
                        target = target.Substring(0, index) + replace + target.Substring(index + replace.Length);

                        result.Add(index);

                        count += n;

                        index = target.IndexOf(temp2);
                    }
                }

                if (count == 0)
                {
                    break;
                }

                total += count;
            }

            if (total < target.Length)
            {
                return Array.Empty<int>();
            }

            result.Reverse();

            return result.ToArray();
        }
    }
}
