using LeetCode.Attributes;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RemoveElementExercise
    {
        public static void Run()
        {
            var exercise = new RemoveElementExercise();

            var solution = exercise.RemoveElement(
                new[] { 0, 1, 2, 2, 3, 0, 4, 2 },
                2);


        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null)
                return 0;

            if (nums.Length == 0)
                return 0;

            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    continue;
                }

                nums[count] = nums[i];

                count++;
            }

            return count;
        }
    }
}
