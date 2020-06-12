using LeetCode.Attributes;
using System;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            var min = 1;
            var max = 30000;

            if (nums.Length < min || nums.Length > max)
            {
                throw new ArgumentOutOfRangeException(nameof(nums.Length));
            }

            return CanJump(nums, 0, new bool[nums.Length]);
        }

        private bool CanJump(int[] nums, int index, bool[] visited)
        {
            var stepMin = 0;
            var stepMax = 100000;

            if (index >= nums.Length - 1)
            {
                return true;
            }

            var maxStep = nums[index];

            if (maxStep < stepMin || maxStep > stepMax)
            {
                throw new ArgumentOutOfRangeException($"nums[{index}]");
            }

            for (int step = maxStep; step > 0; step--)
            {
                var current = index + step;

                if (current >= nums.Length - 1)
                {
                    return true;
                }

                if (visited[current])
                {
                    continue;
                }

                var canJump = CanJump(nums, current, visited);

                if (canJump)
                {
                    return true;
                }
            }

            visited[index] = true;

            return false;
        }
    }
}
