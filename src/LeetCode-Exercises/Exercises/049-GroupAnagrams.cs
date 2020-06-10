using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class GroupAnagramsExercise
    {
        public static void Run()
        {
            var exercise = new GroupAnagramsExercise();

            var input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var result = exercise.GroupAnagrams(input);
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null)
                throw new ArgumentNullException(nameof(strs));

            if (strs.Length == 0)
                return new string[0][];

            var groups = strs
                .GroupBy(str => String.Concat(str.OrderBy(c => c)))
                .Select(o => o.ToArray())
                .ToArray();

            return groups;
        }
    }
}
