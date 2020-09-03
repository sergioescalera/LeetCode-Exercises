namespace LeetCode
{
    public class ToeplitzMatrix
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            if (matrix.Length == 1)
            {
                return true;
            }

            var n = matrix.Length;
            var m = matrix[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n - 1 && j + i < m - 1; j++)
                {
                    var x = matrix[j][j + i];
                    var y = matrix[j + 1][j + i + 1];

                    if (x != y)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1 && i + j < n - 1; j++)
                {
                    var x = matrix[j + i][j];
                    var y = matrix[j + i + 1][j + 1];

                    if (x != y)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
