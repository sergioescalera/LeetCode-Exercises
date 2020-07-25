using LeetCode.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class AllPathsFromSourceTarget
    {
        public static void Run()
        {
            var input = new[] 
            {
                new [] { 1, 2 },
                new [] { 3 },
                new [] { 3 },
                new int[0]
            };

            var ex = new AllPathsFromSourceTarget();

            var output = ex.AllPathsSourceTarget(input);
        }

        /// <summary>
        /// Input: 
        /// Output: [[0,1,3],[0,2,3]] 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            if (graph == null)
                throw new ArgumentNullException();

            if (graph.Length == 0)
                return new IList<int>[0];

            if (graph.Length == 1)
                return new IList<int>[] { new[] { graph[0][0] } };

            return AllPathsSourceTarget(graph, 0, new HashSet<int> { });
        }

        private IList<IList<int>> AllPathsSourceTarget(
            int[][] graph, 
            int index,
            HashSet<int> visited)
        {
            var nodes = graph[index];

            if (index == graph.Length - 1)
            {
                return new[] { new List<int> { index } };
            }

            if (visited.Contains(index))
            {
                return null;
            }

            visited.Add(index);

            var list = new List<IList<int>>();

            foreach (var node in nodes)
            {
                var paths = AllPathsSourceTarget(graph, node, visited);

                if (paths == null)
                {
                    continue;
                }

                foreach (var path in paths)
                {
                    path.Insert(0, index);

                    list.Add(path);
                }
            }

            visited.Remove(index);

            return list;
        }
    }
}
