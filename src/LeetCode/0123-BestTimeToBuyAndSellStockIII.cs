using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BestTimeToBuyAndSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int k = 2;
            int[,] profitMatrix = new int[k + 1, n + 1];

            for (int i = 1; i <= k; i++)
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

            return profitMatrix[k, n - 1];
        }
    }
}
