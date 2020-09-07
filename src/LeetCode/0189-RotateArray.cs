namespace LeetCode
{
    public class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            if (nums == null)
            {
                return;
            }

            if (nums.Length == 0)
            {
                return;
            }

            if (k <= 0)
            {
                return;
            }

            var right = k % nums.Length;

            if (right == 0)
            {
                return;
            }

            var count = 0;
            var cicle = 0;

            while (count < nums.Length)
            {
                var i = (cicle + right) % nums.Length;
                var prev = nums[cicle];

                while (i != cicle)
                {
                    var next = nums[i];

                    nums[i] = prev;

                    prev = next;

                    count++;

                    i += right;

                    i %= nums.Length;
                }

                nums[cicle] = prev;

                cicle++;
                count++;
            }
        }
    }
}
