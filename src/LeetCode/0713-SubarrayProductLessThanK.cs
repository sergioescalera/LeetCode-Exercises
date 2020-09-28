namespace LeetCode
{
    public class SubarrayProductLessThanK
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null)
            {
                return 0;
            }

            if (nums.Length == 0)
            {
                return 0;
            }

            if (k == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0] < k ? 1 : 0;
            }

            int n = nums.Length;
            int i = 0;
            int j = 1;
            int product = nums[0];
            int count = 0;

            while (i < n)
            {
                while (j < n && product * nums[j] < k)
                {
                    product *= nums[j];
                    j++;
                }

                if (product < k)
                {
                    count += j - i;
                }

                product /= nums[i];

                i++;

                if (i == j && i < n)
                {
                    product *= nums[i];

                    j++;
                }    
                else
                {
                    while (j > i + 1
                        && j < n
                        && product >= k)
                    {
                        product /= nums[j];
                        j--;
                    }
                }
            }

            return count;
        }
    }
}
