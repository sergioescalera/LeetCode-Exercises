using LeetCode.Attributes;

namespace LeetCode.Exercises
{
    [Exercise]
    public class PlusOneExercise
    {
        public static void Run()
        {

        }

        public int[] PlusOne(int[] digits)
        {
            if (digits == null)
            {
                return digits;
            }

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var d = digits[i];

                if (d < 9)
                {
                    digits[i] = d + 1;

                    return digits;
                }

                digits[i] = 0;
            }

            var array = new int[digits.Length + 1];

            array[0] = 1;

            return array;
        }
    }
}
