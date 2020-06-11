using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SpiralMatrix
    {
        public static void Run()
        {
            var _1x1 = new[] { new[] { 1 } };
            var _1x2 = new[] { new[] { 1, 2 } };
            var _2x1 = new[] { new[] { 1 }, new[] { 2 } };
            var _3x3 = new[]
            {
                 new [] { 1, 2, 3},
                 new [] { 4, 5, 6},
                 new [] { 7, 8, 9 }
            };
            var _3x4 = new[]
            {
                new [] { 1, 2, 3, 4 },
                new [] { 5, 6, 7, 8 },
                new [] { 9, 10, 11, 12 }
            };
            var _4x4 = new[]
           {
                new [] { 1, 2, 3, 4 },
                new [] { 5, 6, 7, 8 },
                new [] { 9, 10, 11, 12 },
                new [] { 13, 14, 15, 16 }
            };

            var exerise = new SpiralMatrix();

            var _r1x1 = exerise.SpiralOrder(_1x1);
            var _r1x2 = exerise.SpiralOrder(_1x2);
            var _r2x1 = exerise.SpiralOrder(_2x1);
            var _r3x3 = exerise.SpiralOrder(_3x3);
            var _r3x4 = exerise.SpiralOrder(_3x4);
            var _r4x4 = exerise.SpiralOrder(_4x4);
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var result = new List<int>();

            if (matrix.Length == 0)
            {
                return result;
            }

            CheckLength(matrix);

            var top = 0;
            var left = 0;
            var right = matrix[0].Length - 1;
            var bottom = matrix.Length - 1;

            do
            {
                CopyTop(matrix, result, top, left, right);

                CopyRight(matrix, result, right, top, bottom);

                if (bottom > top)
                {
                    CopyBottom(matrix, result, bottom, right, left);
                }

                if (left < right)
                {
                    CopyLeft(matrix, result, left, bottom, top);
                }

                left++;
                right--;
                top++;
                bottom--;
            }
            while (left <= right && top <= bottom);

            return result;
        }

        private void CopyTop(
            int[][] matrix, 
            List<int> result,
            int index,
            int start,
            int end)
        {
            if (index < 0 || index >= matrix.Length)
            {
                return;
            }

            if (start < 0 || start >= matrix[index].Length)
            {
                return;
            }

            if (end < 0 || end >= matrix[index].Length)
            {
                return;
            }

            for (int i = start; i <= end; i++)
            {
                result.Add(matrix[index][i]);
            }
        }

        private void CopyRight(
            int[][] matrix,
            List<int> result,
            int index,
            int start,
            int end)
        {
            if (start < 0 || start >= matrix.Length)
            {
                return;
            }

            if (end < 0 || end >= matrix.Length)
            {
                return;
            }

            if (index < 0 || index >= matrix[start].Length)
            {
                return;
            }

            for (int i = start + 1; i <= end; i++)
            {
                result.Add(matrix[i][index]);
            }
        }

        private void CopyBottom(
            int[][] matrix,
            List<int> result,
            int index,
            int start,
            int end)
        {
            if (index < 0 || index >= matrix.Length)
            {
                return;
            }

            if (start < 0 || start >= matrix[index].Length)
            {
                return;
            }

            if (end < 0 || end >= matrix[index].Length)
            {
                return;
            }

            for (int i = start - 1; i >= end; i--)
            {
                result.Add(matrix[index][i]);
            }
        }

        private void CopyLeft(
            int[][] matrix,
            List<int> result,
            int index,
            int start,
            int end)
        {
            if (start < 0 || start >= matrix.Length)
            {
                return;
            }

            if (end < 0 || end >= matrix.Length)
            {
                return;
            }

            if (index < 0 || index >= matrix[start].Length)
            {
                return;
            }

            for (int i = start - 1; i >= end + 1; i--)
            {
                result.Add(matrix[i][index]);
            }
        }

        private void CheckLength(int[][] matrix)
        {
            var len = matrix[0].Length;

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i].Length != len)
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
