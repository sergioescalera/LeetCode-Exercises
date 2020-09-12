using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class CoinChangeSolution
    {
        public int CoinChange(int[] coins, int targetAmount)
        {
            if (coins == null || coins.Length == 0)
            {
                return -1;
            }

            if (targetAmount < 0)
            {
                return -1;
            }

            if (targetAmount == 0)
            {
                return 0;
            }

            var amounts = Enumerable.Repeat(int.MaxValue, targetAmount + 1).ToArray();

            amounts[0] = 0;

            for (int amount = 1; amount < amounts.Length; amount++)
            {
                for (int i = 0; i < coins.Length; i++)
                {
                    var coin = coins[i];

                    if (coin > amount)
                    {
                        continue;
                    }

                    var x = amounts[amount - coin];

                    if (x == int.MaxValue)
                    {
                        continue;
                    }

                    amounts[amount] = Math.Min(x + 1, amounts[amount]);
                }
            }

            return amounts[targetAmount] == int.MaxValue ? -1 : amounts[targetAmount];
        }
        public int CoinChange2(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0)
            {
                return -1;
            }

            if (amount < 0)
            {
                return -1;
            }

            if (amount == 0)
            {
                return 0;
            }

            return CoinChange(
                new SortedSet<int>(coins.Distinct()), 
                amount, 
                new Dictionary<string, int>());
        }

        private int CoinChange(
            SortedSet<int> coins, 
            int amount, 
            Dictionary<string, int> mem)
        {
            if (coins.Count == 0)
            {
                return amount > 0 ? -1 : 0;
            }

            if (amount == 0)
            {
                return 0;
            }

            var coin = coins.Max;

            var key = $"{coin}-{amount}";

            if (mem.ContainsKey(key))
            {
                return mem[key];
            }

            coins.Remove(coin);

            var n = amount / coin;
            var min = -1;

            for (int i = n; i >= 0; i--)
            {
                var value = i * coin;

                var change = CoinChange(
                    coins,
                    amount - value,
                    mem);

                if (change < 0)
                {
                    continue;
                }

                min = min == -1 ? change + i : Math.Min(change + i, min);
            }

            coins.Add(coin);

            mem.Add(key, min);

            return min;
        }
    }
}
