using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCode
{
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals == null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            if (newInterval == null)
            {
                throw new ArgumentNullException(nameof(newInterval));
            }

            var x = newInterval[0];
            var y = newInterval[1];

            var list = new List<int[]>();

            for (int i = 0; i < intervals.Length; )
            {
                var interval = intervals[i];
                
                if (newInterval == null)
                {
                    list.Add(interval);
                }
                else if (interval[1] < x)
                {
                    list.Add(interval);
                }
                else if (y < interval[0])
                {
                    list.Add(newInterval);
                    list.Add(interval);
                    newInterval = null;
                }
                else if (interval[0] <= x && y <= interval[1])
                {
                    list.Add(interval);
                    newInterval = null;
                }
                else if (x < interval[0] && y <= interval[1])
                {
                    list.Add(new[] { x, interval[1] });
                    newInterval = null;
                }
                else if (interval[0] <= x && interval[1] < y)
                {
                    var found = false;

                    for (int j = i + 1; j < intervals.Length; j++)
                    {
                        var next = intervals[j];

                        if (y < next[0])
                        {
                            found = true;

                            list.Add(new[] { interval[0], y });
                            newInterval = null;

                            i = j;

                            break;
                        }
                        
                        if (y <= next[1])
                        {
                            found = true;

                            list.Add(new[] { interval[0], next[1] });
                            newInterval = null;

                            i = j + 1;

                            break;
                        }
                    }

                    if (found == false)
                    {
                        list.Add(new[] { interval[0], y });
                        newInterval = null;
                        i = intervals.Length;
                    }

                    continue;
                }

                i++;
            }

            if (newInterval != null)
            {
                list.Add(newInterval);
            }

            return list.ToArray();
        }
    }
}
