using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class RotateImage
    {
        public static void Run()
        {
            var matrix2 = new[] 
            {
              new [] {1, 2 },
              new [] {3, 4 }
            };
            var matrix3 = new[]
            {
              new [] {1, 2, 3 },
              new [] {4, 5, 6 },
              new [] {7, 8, 9 }
            };

            var matrix4 = new[]
            {
              new [] {1, 2, 3, 4 },
              new [] {5, 6, 7, 8 },
              new [] {9, 10, 11, 12 },
              new [] {13, 14, 15, 16 }
            };

            var exercise = new RotateImage();

            exercise.Rotate(matrix2);
            exercise.Rotate(matrix3);
            exercise.Rotate(matrix4);
        }

        public void Rotate(int[][] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            var len = matrix.Length;

            for (int i = 0; i < len; i++)
            {
                if (matrix[i].Length != len)
                {
                    throw new ArgumentOutOfRangeException($"matrix[{i}]");
                }
            }

            var count = len / 2;

            for (int i = 0; i < count; i++)
            {
                var first = i;
                var last = len - first - 1;

                for (int j = first; j < last; j++)
                {
                    var offset = j - first;

                    var n = matrix[first][j];

                    matrix[first][j] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[j][last];
                    matrix[j][last] = n;
                }
            }
        }
    }
}
