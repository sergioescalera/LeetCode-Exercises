using System;

namespace LeetCode
{
    public class MaximumProductSubarray
    {
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length <= 1)
            {
                return nums[0];
            }

            var product = 1;
            var max = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];

                product = product *= n;

                max = Math.Max(product, max);

                if (n == 0)
                {
                    product = 1;
                }
            }

            product = 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                var n = nums[i];

                product = product *= n;

                max = Math.Max(product, max);

                if (n == 0)
                {
                    product = 1;
                }
            }

            return max;
        }

        public int MaxProductNxN(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var maxProduct = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                var max = nums[i];
                var value = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    value *= nums[j];

                    if (value > max)
                    {
                        max = value;
                    }

                    Console.WriteLine($"{i}...{j}");
                }

                if (max > maxProduct)
                {
                    maxProduct = max;
                }
            }

            return maxProduct;
        }
    }
}
