using System;

namespace LeetCode.UnitTests
{
    public class BestTimeToBuyAndSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices == null || prices.Length <= 1)
            {
                return 0;
            }

            int n = prices.Length;
            int m = Math.Min(n, k);
            int[,] profitMatrix = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                int prevDiff = int.MinValue;

                for (int j = 1; j < n; j++)
                {
                    int prevProfit = profitMatrix[i - 1, j - 1];
                    int prevPrice = prices[j - 1];

                    int profit = profitMatrix[i, j - 1];
                    int price = prices[j];

                    prevDiff = Math.Max(prevDiff, prevProfit - prevPrice);

                    profitMatrix[i, j] = Math.Max(profit, price + prevDiff);
                }
            }

            return profitMatrix[m, n - 1];
        }
    }
}
