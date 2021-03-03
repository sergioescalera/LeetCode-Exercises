using System.Collections.Generic;

namespace LeetCode
{
    public class MaximumNumberEatenApples
    {
        public int EatenApples(int[] apples, int[] days)
        {

            if (apples == null || days == null)
            {
                return 0;
            }

            var n = apples.Length;
            var eaten = 0;
            var set = new SortedSet<Apples>(new MyComparer());
            var day = 0;

            for (; day < n; day++)
            {

                if (set.Count == 0)
                {

                    if (apples[day] == 0)
                    {
                        continue;
                    }

                    eaten++;

                    StoreApples(set, apples, days, day, eatenThisDay: 1);
                }
                else
                {

                    RemoveExpired(set, day);

                    StoreApples(set, apples, days, day);

                    EatApple(set, ref eaten);
                }
            }

            while (set.Count > 0)
            {

                RemoveExpired(set, day);

                EatApple(set, ref eaten);

                day++;
            }

            return eaten;
        }

        private void StoreApples(
            SortedSet<Apples> set, 
            int[] apples,
            int[] days, 
            int day,
            int eatenThisDay = 0)
        {
            if (apples[day] > eatenThisDay)
            {
                set.Add(new Apples
                {
                    day = day,
                    count = apples[day] - eatenThisDay,
                    expire = day + days[day]
                });
            }
        }

        private void EatApple(SortedSet<Apples> set, ref int eaten)
        {
            if (set.Count == 0)
            {
                return;
            }

            eaten++;

            set.Min.count--;

            if (set.Min.count == 0)
            {
                set.Remove(set.Min);
            }
        }

        private void RemoveExpired(SortedSet<Apples> set, int day)
        {
            while (set.Count > 0 && set.Min.expire <= day)
            {
                set.Remove(set.Min);
            }
        }

        class Apples
        {

            public int day;
            public int count;
            public int expire;
        }

        class MyComparer : IComparer<Apples>
        {

            public int Compare(Apples a, Apples b)
            {

                if (a.day == b.day)
                {
                    return 0;
                }

                return a.expire > b.expire ? 1 : -1;
            }
        }
    }
}
