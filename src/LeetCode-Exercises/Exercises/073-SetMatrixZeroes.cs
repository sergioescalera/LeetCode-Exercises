using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SetMatrixZeroes
    {
        public static void Run()
        {
            var input3x4 = new[]
            {
                 new [] { 0, 1, 2, 0 },
                 new [] { 3, 4, 5, 2 },
                 new [] { 1, 3, 1, 5 }
            };

            var input1x3 = new[]
            {
                new [] { 1, 0, 3 }
            };

            var exercise = new SetMatrixZeroes();

            exercise.SetZeroes(input3x4);
            exercise.SetZeroes(input1x3);
        }

        public void SetZeroes(int[][] matrix)
        {
            if (matrix == null)
                return;

            if (matrix.Length == 0)
                return;

            var m = matrix.Length;
            var n = matrix[0].Length;

            var clearFirstRow = false;
            var clearFirstColumn = false;

            for (int y = 0; y < m; y++)
            {
                if (matrix[y][0] == 0)
                {
                    clearFirstRow = true;
                    break;
                }
            }

            for (int x = 0; x < n; x++)
            {
                if (matrix[0][x] == 0)
                {
                    clearFirstColumn = true;
                    break;
                }
            }

            for (int y = 1; y < m; y++)
            {
                for (int x = 1; x < n; x++)
                {
                    if (matrix[y][x] == 0)
                    {
                        matrix[0][x] = 0;
                        matrix[y][0] = 0;
                    }
                }
            }

            for (int x = 1; x < n; x++)
            {
                if (matrix[0][x] == 0)
                {
                    for (int y = 1; y < m; y++)
                    {
                        matrix[y][x] = 0;
                    }
                }
            }

            for (int y = 1; y < m; y++)
            {
                if (matrix[y][0] == 0)
                {
                    for (int x = 1; x < n; x++)
                    {
                        matrix[y][x] = 0;
                    }
                }
            }

            if (clearFirstRow)
            {
                for (int y = 0; y < m; y++)
                {
                    matrix[y][0] = 0;
                }
            }

            if (clearFirstColumn)
            {
                for (int x = 0; x < n; x++)
                {
                    matrix[0][x] = 0;
                }
            }
        }
    }
}
