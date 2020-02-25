using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class LengthofLastWordExercise
    {
        public static void Run()
        {
            var exercise = new LengthofLastWordExercise();

        }

        public int LengthOfLastWord(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return 0;

            var nonEmpty = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                var c = s[i];

                if (nonEmpty > 0 && c == ' ')
                {
                    return nonEmpty - i;
                }

                if (nonEmpty == 0 && c != ' ')
                {
                    nonEmpty = i;
                }
            }

            return nonEmpty > 0 ? nonEmpty + 1 : 0;
        }
    }
}
