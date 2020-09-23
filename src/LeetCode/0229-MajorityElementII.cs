using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class MajorityElementII
    {
        public IList<int> MajorityElement(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }

            if (nums.Length == 1)
            {
                return new[] { nums[0] };
            }

            int x = MajorityElement(nums, null);
            int y = MajorityElement(nums, x);

            double count = nums.Length / 3.0;
            int xCount = nums.Count(n => n == x);
            int yCount = nums.Count(n => n == y);

            var list = new List<int>();

            if (yCount > count && x != y)
                list.Add(y);

            if (xCount > count)
                list.Add(x);

            return list;
        }

        public int MajorityElement(int[] nums, int? ignore)
        {
            int counter = 0;
            int elem = 0;
            int maxCounter = 0;
            int maxElem = 0;

            foreach (int n in nums)
            {
                if (n == ignore)
                {
                    continue;
                }

                if (counter == 0)
                {
                    elem = n;
                    counter = 1;
                }
                else if (elem == n)
                {
                    counter++;
                }
                else
                {
                    counter--;
                }

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    maxElem = elem;
                }
            }

            if (maxCounter > nums.Length / 3.0)
            {
                return maxElem;
            }

            return elem;
        }
    }
}
