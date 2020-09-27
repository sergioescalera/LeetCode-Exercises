using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class EvaluateDivision
    {
        public double[] CalcEquation(
            IList<IList<string>> equations,
            double[] values,
            IList<IList<string>> queries)
        {
            if (equations == null)
            {
                throw new ArgumentNullException(nameof(equations));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            var graph = BuildGraph(equations, values);

            var results = SolveQueries(graph, queries);

            return results;
        }

        private double[] SolveQueries(
            IDictionary<string, IList<Tuple<string, double>>> graph,
            IList<IList<string>> queries)
        {
            var results = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                var x = query[0];
                var y = query[1];

                results[i] = SolveEquation(graph, x, y);
            }

            return results;
        }

        private double SolveEquation(
            IDictionary<string, IList<Tuple<string, double>>> graph,
            string x, 
            string y)
        {
            if (graph.ContainsKey(x) == false)
            {
                return -1;
            }

            if (x == y)
            {
                return 1;
            }

            var queue = new Queue<Tuple<string, double>>(graph[x].Where(o => o.Item1 != x));
            var visited = new HashSet<string>(new[] { x });

            while (queue.Count > 0)
            {
                var value = queue.Dequeue();

                if (value.Item1 == y)
                {
                    return value.Item2;
                }

                visited.Add(value.Item1);

                foreach (var item in graph[value.Item1])
                {
                    if (visited.Contains(item.Item1))
                    {
                        continue;
                    }

                    queue.Enqueue(Tuple.Create(item.Item1, item.Item2 * value.Item2));
                }
            }

            return -1;
        }

        private IDictionary<string, IList<Tuple<string, double>>> BuildGraph(
            IList<IList<string>> equations, 
            double[] values)
        {
            if (equations.Count != values.Length)
            {
                throw new ArgumentException();
            }

            var graph = new Dictionary<string, IList<Tuple<string, double>>>();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                var value = values[i];

                var x = equation[0];
                var y = equation[1];

                AddEquationToGraph(graph, x, y, value);

                if (value > 0)
                {
                    AddEquationToGraph(graph, y, x, 1 / value);
                }
            }

            return graph;
        }

        private void AddEquationToGraph(
            IDictionary<string, IList<Tuple<string, double>>> graph,
            string x, 
            string y, 
            double value)
        {
            if (graph.ContainsKey(x) == false)
            {
                graph.Add(x, new List<Tuple<string, double>>
                {
                    Tuple.Create(x, 1.0)
                });
            }

            var list = graph[x];

            list.Add(Tuple.Create(y, value));
        }
    }
}
