using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class TaskScheduler
    {
        public static void Run()
        {
            var ex = new TaskScheduler();

            do
            {
                Console.WriteLine("Enter tasks (letters)");

                var line = Console.ReadLine().ToUpper();

                if (String.IsNullOrWhiteSpace(line))
                    break;

                var n = ex.ReadNum("Enter cooldown period");

                if (n == null)
                    break;

                var interval = ex.LeastInterval(line.ToCharArray(), n.Value);

                Console.WriteLine(interval);

                Console.ReadLine();

            } while (true);
        }

        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks == null)
                throw new ArgumentNullException(nameof(tasks));

            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n));

            if (n == 0)
                return tasks.Length;

            if (tasks.Length == 0)
                return 0;

            if (tasks.Length == 1)
                return 1;

            var grouped = tasks
                .GroupBy(o => o)
                .Select(o => new TaskGroup
                {
                    task = o.Key,
                    count = o.Count()
                })
                .OrderByDescending(o => o.count)
                .ToArray();

            if (grouped[0].count == 1)
            {
                return grouped.Length;
            }

            var spaces = (grouped[0].count - 1) * n;
            var lastLevel = grouped.Skip(1).Where(o => o.count == grouped[0].count).Count();

            if (n >= grouped.Length)
            {
                return grouped[0].count
                    + spaces
                    + lastLevel;
            }
            else
            {
                var pending = grouped
                    .Skip(1)
                    .Sum(o => o.count);

                return pending - lastLevel > spaces ? 
                    tasks.Length : 
                    grouped[0].count + spaces + lastLevel;
            }
        }

        [DebuggerDisplay("{task}: {count}")]
        class TaskGroup
        {
            public int count;

            public char task;
        }
    }
}
