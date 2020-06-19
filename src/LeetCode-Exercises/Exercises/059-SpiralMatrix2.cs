using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class SpiralMatrix2
    {
        public static void Run()
        {
            var exercise = new SpiralMatrix2();

            exercise.GenerateMatrix(1);
            exercise.GenerateMatrix(11);
            exercise.GenerateMatrix(22);
        }

        public int[][] GenerateMatrix(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (n == 0)
            {
                return new int[0][];
            }

            var m = new int[n][];
            
            for (int i = 0; i < n; i++)
            {
                m[i] = new int[n];
            }

            var layers = n / 2;
            var counter = 1;

            for (int start = 0; start < layers; start++)
            {
                var end = n - start;

                // top
                for (int i = start; i < end; i++)
                {
                    m[start][i] = counter;

                    counter++;
                }

                // right
                for (int i = start + 1; i < end; i++)
                {
                    m[i][end - 1] = counter;

                    counter++;
                }

                // bottom
                for (int i = end - 2; i >= start; i--)
                {
                    m[end - 1][i] = counter;

                    counter++;
                }

                // left
                for (int i = end - 2; i >= start + 1; i--)
                {
                    m[i][start] = counter;

                    counter++;
                }
            }

            if (n % 2 == 1)
            {
                m[layers][layers] = counter;
            }

            return m;
        }
    }
}
