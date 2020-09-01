using System;

namespace LeetCode
{
    public class FloodFillSolution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            if (sr >= image.Length)
            {
                return image;
            }

            if (sc >= image[sr].Length)
            {
                return image;
            }

            if (newColor == image[sr][sc])
            {
                return image;
            }

            return FloodFill(image, sr, sc, image[sr][sc], newColor);
        }

        private int[][] FloodFill(
            int[][] image,
            int sr, 
            int sc,
            int targetColor,
            int newColor)
        {
            if (sr < 0 || sc < 0)
            {
                return image;
            }

            if (sr >= image.Length || sc >= image[sr].Length)
            {
                return image;
            }

            if (image[sr][sc] == targetColor)
            {
                image[sr][sc] = newColor;

                FloodFill(image, sr + 1, sc, targetColor, newColor);
                FloodFill(image, sr - 1, sc, targetColor, newColor);
                FloodFill(image, sr, sc + 1, targetColor, newColor);
                FloodFill(image, sr, sc - 1, targetColor, newColor);
            }

            return image;
        }
    }
}
