using LeetCode.Attributes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class TopFrequentElements
    {
        public static void Run()
        {

        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums == null)
                return null;

            if (nums.Length == 0)
                return nums;

            if (k <= 0)
                return new int[0];

            var values = (int[])nums.Clone();

            Array.Sort(values);

            var list = new List<Item>();
            var last = default(Item);

            for (int i = 0; i < values.Length; i++)
            {
                var n = values[i];

                if (last == null || last.val != n)
                {
                    last = new Item
                    {
                        val = n,
                        count = 1
                    };

                    list.Add(last);
                }
                else
                {
                    last.count++;
                }
            }

            return list
                .OrderByDescending(o => o.count)
                .Take(k)
                .Select(o => o.val)
                .ToArray();
        }

        class Item
        {
            public int val;

            public int count;
        }
    }
}
