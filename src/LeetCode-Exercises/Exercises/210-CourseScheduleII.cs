using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    /// <summary>
    /// There are a total of n courses you have to take, labeled from 0 to n-1.
    /// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
    /// Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
    /// There may be multiple correct orders, you just need to return one of them.If it is impossible to finish all courses, return an empty array.
    /// 
    /// The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
    /// You may assume that there are no duplicate edges in the input prerequisites.
    /// </summary>
    [Exercise]
    public class CourseScheduleII
    {
        public static void Run()
        {
            var n = 3;
            var d = new[] { new[] { 0, 1 }, new[] { 1, 2 } };

            var ex = new CourseScheduleII();

            var s = ex.FindOrder(n, d);

            Console.WriteLine(String.Join(", ", s));
            Console.ReadLine();
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            if (numCourses <= 0)
            {
                return Enumerable.Empty<int>().ToArray();
            }

            if (prerequisites == null || prerequisites.Length == 0)
            {
                return Enumerable.Range(0, numCourses).ToArray();
            }

            var d = BuildDependencies(numCourses, prerequisites);

            var order = new List<int>(numCourses);
            var pending = Enumerable.Range(0, numCourses).ToList();

            while (d.dependencies.Any())
            {
                var ready = pending.Where(t => d.counters[t] == 0);

                if (ready.Any() == false)
                {
                    break;
                }

                foreach (var item in ready.ToList())
                {
                    order.Add(item);
                    pending.Remove(item);

                    if (d.dependencies.ContainsKey(item) == false)
                    {
                        continue;
                    }

                    var dependencies = d.dependencies[item];

                    foreach (var dependency in dependencies)
                    {
                        d.counters[dependency]--;
                    }

                    d.dependencies.Remove(item);
                }
            }

            foreach (var item in pending.Where(t => d.counters[t] == 0))
            {
                order.Add(item);
            }

            if (order.Count < numCourses)
            {
                return Enumerable.Empty<int>().ToArray();
            }

            return order.ToArray();
        }

        private Dependencies BuildDependencies(int numCourses, int[][] prerequisites)
        {
            var d = new Dependencies
            {
                dependencies = new Dictionary<int, HashSet<int>>(),
                counters = new int[numCourses]
            };

            foreach (var item in prerequisites)
            {
                var dependent = item[0];
                var required = item[1];

                if (d.dependencies.ContainsKey(required) == false)
                {
                    d.dependencies.Add(required, new HashSet<int>(new[] { dependent }));
                }
                else
                {
                    d.dependencies[required].Add(dependent);
                }

                d.counters[dependent]++;
            }

            return d;
        }

        class Dependencies
        {
            public Dictionary<int, HashSet<int>> dependencies;

            public int[] counters;
        }
    }
}
