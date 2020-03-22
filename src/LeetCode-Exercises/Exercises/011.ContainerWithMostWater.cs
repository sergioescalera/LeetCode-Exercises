using LeetCode.Attributes;
using LeetCode.Extensions;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ContainerWithMostWater
    {
        public static void Run()
        {
            var ex = new ContainerWithMostWater();

            do
            {
                var h = ex.ReadNums();

                if (h == null)
                    break;

                Console.WriteLine("[{0}]={1}", String.Join(", ", h), ex.MaxArea(h));

            } while (true);
        }

        public int MaxArea(int[] height)
        {
            if (height.Length < 2)
                return 0;

            var area = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var x = height[i];
                    var y = height[j];

                    var a = (int)Math.Min(x, y) * (j - i);

                    if (a > area)
                        area = a;
                }
            }

            return area;
        }
    }
}
