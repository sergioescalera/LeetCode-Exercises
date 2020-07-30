using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class BestTimeBuySellStockCooldown
    {
        public static void Run()
        {
            var ex = new BestTimeBuySellStockCooldown();
            var stopwatch = new Stopwatch();

            do
            {
                var prices = ex.ReadNums("Enter prices");

                if (prices == null)
                {
                    break;
                }

                stopwatch.Start();

                var max = ex.MaxProfit(prices);

                stopwatch.Stop();

                Console.WriteLine("Max profit: {0}", max);
                Console.WriteLine(stopwatch.Elapsed);
                Console.WriteLine("");

            } while (true);
        }

        /// <summary>
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        /// Design an algorithm to find the maximum profit.You may complete as many transactions 
        /// as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
        /// You may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        /// After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
        /// 
        /// Input: [1,2,3,0,2]
        /// Output: 3 
        /// Explanation: transactions = [buy, sell, cooldown, buy, sell]
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices == null)
                throw new ArgumentNullException();

            if (prices.Length == 0)
                return 0;

            if (prices.Length == 1)
                return 0;

            return MaxProfit(
                prices, 
                0, 
                canBuy: true,
                canSell: false,
                entries: new Entry[prices.Length]);
        }

        private int MaxProfit(
            int[] prices,
            int index, 
            bool canSell,
            bool canBuy,
            Entry[] entries)
        {
            if (index >= prices.Length)
            {
                return 0;
            }

            if (canSell && canBuy)
            {
                throw new InvalidOperationException();
            }

            entries[index] = entries[index] ?? new Entry { };

            if (!canSell && !canBuy)
            {
                if (entries[index].cannotSellOrBuy.HasValue)
                {
                    return entries[index].cannotSellOrBuy.Value;
                }

                entries[index].cannotSellOrBuy = MaxProfit(
                    prices, 
                    index + 1, 
                    canBuy: true,
                    canSell: false, 
                    entries: entries);

                return entries[index].cannotSellOrBuy.Value;
            }

            if (canBuy)
            {
                if (entries[index].canBuy.HasValue)
                {
                    return entries[index].canBuy.Value;
                }

                var buying = -prices[index] + MaxProfit(prices, index + 1, canBuy: false, canSell: true, entries: entries);

                var cooling = MaxProfit(prices, index + 1, canBuy: true, canSell: false, entries: entries);

                entries[index].canBuy = Math.Max(buying, cooling);

                return entries[index].canBuy.Value;
            }
            else // canSell = true
            {
                if (entries[index].canSell.HasValue)
                {
                    return entries[index].canSell.Value;
                }

                var selling = prices[index] + MaxProfit(prices, index + 1, canBuy: false, canSell: false, entries: entries);

                var cooling = MaxProfit(prices, index + 1, canBuy: false, canSell: true, entries: entries);

                entries[index].canSell = Math.Max(selling, cooling);

                return entries[index].canSell.Value;
            }
        }

        class Entry
        {
            public int? canSell;

            public int? canBuy;

            public int? cannotSellOrBuy;
        }
    }
}
