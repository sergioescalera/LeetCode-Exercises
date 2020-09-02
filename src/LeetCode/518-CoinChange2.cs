using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeetCode
{
    public class CoinChange2
    {
        public int Change(int amount, int[] coins)
        {
            if (amount < 0)
            {
                return 0;
            }

            if (amount == 0)
            {
                return 1;
            }

            if (coins == null || coins.Length == 0)
            {
                return 0;
            }

            var mem = new int[amount + 1, coins.Length];

            for (int i = 0; i < mem.GetLength(0); i++)
            {
                for (int j = 0; j < mem.GetLength(1); j++)
                {
                    mem[i, j] = -1;
                }
            }

            return Change(
                amount,
                coins.Where(x => x <= amount).OrderBy(x => x).ToArray(),
                0,
                mem);
        }

        private int Change(int amount, int[] coins, int index, int[,] memory)
        {
            if (amount == 0)
            {
                return 1;
            }

            if (index >= coins.Length)
            {
                return 0;
            }

            var value = coins[index];

            if (value > amount)
            {
                return 0;
            }

            if (memory[amount, index] >= 0)
            {
                return memory[amount, index];
            }

            var i = 0;
            var count = 0;

            while (i * value <= amount)
            {
                count += Change(amount - i * value, coins, index + 1, memory);

                i++;
            }

            memory[amount, index] = count;

            return count;
        }
    }
}
