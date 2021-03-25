using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class PacificAtlanticWaterFlow
    {
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {

            if (matrix == null || matrix.Length == 0)
            {
                return Array.Empty<IList<int>>();
            }

            var list = new List<IList<int>>();

            var n = matrix.Length;

            var m = matrix[0].Length;

            var canReachAtlantic = new bool[n, m];
            var canReachPacific = new bool[n, m];

            for (var i = 0; i < n; i++)
            {

                for (var j = 0; j < m; j++)
                {

                    if (canReachAtlantic[i, j] == false)
                    {

                        ReachOcean(n, m, matrix, canReachAtlantic, new bool[n, m], n - 1, m - 1, i, j);
                    }

                    if (canReachPacific[i, j] == false)
                    {

                        ReachOcean(n, m, matrix, canReachPacific, new bool[n, m], 0, 0, i, j);
                    }

                    if (canReachAtlantic[i, j] && canReachPacific[i, j])
                    {

                        list.Add(new[] { i, j });
                    }
                }
            }

            return list;
        }

        bool ReachOcean(
            int n, int m,
            int[][] matrix,
            bool[,] canReachOcean,
            bool[,] visiting,
            int iTarget,
            int jTarget,
            int i,
            int j)
        {

            if (canReachOcean[i, j])
            {

                return canReachOcean[i, j];
            }

            if (i == iTarget || j == jTarget)
            {

                canReachOcean[i, j] = true;

                return canReachOcean[i, j];
            }

            visiting[i, j] = true;

            foreach (var item in GetNeighbors(n, m, i, j))
            {

                if (matrix[i][j] >= matrix[item.i][item.j] &&
                    visiting[item.i, item.j] == false &&
                    ReachOcean(n, m, matrix, canReachOcean, visiting, iTarget, jTarget, item.i, item.j))
                {

                    canReachOcean[i, j] = true;

                    visiting[i, j] = false;

                    return canReachOcean[i, j];
                }
            }

            visiting[i, j] = false;

            return canReachOcean[i, j];
        }

        IEnumerable<(int i, int j)> GetNeighbors(int n, int m, int i, int j)
        {

            if (i > 0)
            {
                yield return (i - 1, j);
            }

            if (i < n - 1)
            {
                yield return (i + 1, j);
            }

            if (j > 0)
            {
                yield return (i, j - 1);
            }

            if (j < m - 1)
            {
                yield return (i, j + 1);
            }

            yield break;
        }
    }
}
