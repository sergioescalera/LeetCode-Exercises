using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SimplifyPathExercise
    {
        public static void Run()
        {
            var exercise = new SimplifyPathExercise();

            do
            {
                Console.WriteLine("Enter path");

                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var path = exercise.SimplifyPath(line);

                Console.WriteLine(path);

                Console.WriteLine();

            } while (true);
        }

        public string SimplifyPath(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                return path;

            var items = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>();

            foreach (var item in items)
            {
                if (item == ".")
                {
                    continue;
                }

                if (item == ".." && stack.Count == 0)
                {
                    continue;
                }

                if (item == "..")
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(item);
                }
            }

            return "/" + String.Join("/", stack.Reverse());
        }
    }
}
