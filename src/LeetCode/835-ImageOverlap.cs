using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode
{
    public class ImageOverlap
    {
        public int LargestOverlap(int[][] a, int[][] b)
        {
            if (a == null || b == null)
            {
                return 0;
            }

            if (a.Length != b.Length)
            {
                return 0;
            }

            if (a.Length == 0 || a[0].Length == 0)
            {
                return 0;
            }

            if (a[0].Length != b[0].Length)
            {
                return 0;
            }

            var aPairs = FindPairs(a).ToArray();

            var bPairs = FindPairs(b).ToArray();

            var n = a.Length;
            var nn = n * n;

            if (aPairs.Length == 0 || bPairs.Length == 0)
            {
                return 0;
            }

            if (aPairs.Length == nn && bPairs.Length == nn)
            {
                return nn;
            }

            if (aPairs.Length >= bPairs.Length)
            {
                return LargestOverlap(
                    n,
                    bPairs,
                    aPairs);
            }

            return LargestOverlap(
                n,
                aPairs,
                bPairs);
        }

        private int LargestOverlap(
            int n,
            Pair[] aPairs,
            Pair[] bPairs)
        {
            var max = Math.Max(aPairs.Length, bPairs.Length);
            var maxOverlap = 0;

            var arect = new
            {
                right = aPairs.Select(o => o.x).Max(),
                left = aPairs.Select(o => o.x).Min(),
                bottom = aPairs.Select(o => o.y).Max(),
                top = aPairs.Select(o => o.y).Min()
            };

            var brect = new
            {
                right = bPairs.Select(o => o.x).Max(),
                left = bPairs.Select(o => o.x).Min(),
                bottom = bPairs.Select(o => o.y).Max(),
                top = bPairs.Select(o => o.y).Min()
            };

            var dx = Math.Max(
                Math.Abs(arect.left - brect.right),
                Math.Abs(arect.right - brect.left));
            var dy = Math.Max(
                Math.Abs(arect.bottom - brect.top),
                Math.Abs(arect.top - brect.bottom));

            var directions = new[]
             {
                new Pair { x = 1, y = 1 },
                new Pair { x = -1, y = -1 }
            };

            for (int i = 0; i <= dx; i++)
            {
                for (int j = 0; j <= dy; j++)
                {
                    foreach (var dir in directions)
                    {
                        var overlap = aPairs
                            .Select(o => o.Translate(i * dir.x, j * dir.y))
                            .Where(o => o.IsValid(n))
                            .Where(o => bPairs.Contains(o))
                            .Count();

                        if (overlap > maxOverlap)
                        {
                            maxOverlap = overlap;
                        }

                        if (maxOverlap == max)
                        {
                            return max;
                        }
                    }
                }
            }

            return maxOverlap;
        }

        private IEnumerable<Pair> FindPairs(int[][] img)
        {
            var n = img.Length;

            for (int i = 0; i < n; i++)
            {
                var m = img[i].Length;

                if (m != n)
                {
                    throw new ArgumentException($"img[{i}].Length={m}");
                }

                for (int j = 0; j < n; j++)
                {
                    var x = img[i][j];

                    if (x == 1)
                    {
                        yield return new Pair
                        {
                            y = i,
                            x = j
                        };
                    }

                    else if (x != 0)
                    {
                        throw new ArgumentException($"img[{i}][{j}]={x}");
                    }
                }
            }

            yield break;
        }

        [DebuggerDisplay("{x}, {y}")]
        class Pair
        {
            public int x;

            public int y;

            public override bool Equals(object obj)
            {
                return obj is Pair p && p.x == x && p.y == y;
            }

            public override int GetHashCode()
            {
                return $"{x},{y}".GetHashCode();
            }

            public virtual Pair Translate(int dx, int dy)
            {
                return new Pair
                {
                    x = x + dx,
                    y = y + dy,
                };
            }

            public virtual Boolean IsValid(int n)
            {
                return x >= 0
                    && y >= 0
                    && x < n
                    && y < n;
            }
        }
    }
}
