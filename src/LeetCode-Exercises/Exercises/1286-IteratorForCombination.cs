using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;

namespace LeetCode.Exercises
{
    [Exercise]
    public class IteratorForCombination
    {
        public static void Run()
        {
            do
            {
                Console.WriteLine("Enter text");
                var s = Console.ReadLine();

                if (String.IsNullOrEmpty(s))
                {
                    break;
                }

                var n = s.ReadNum("Enter length");

                if (n == null)
                {
                    break;
                }

                var it = new CombinationIterator(s, n.Value);

                Console.WriteLine();

                while (it.HasNext())
                {
                    Console.WriteLine(it.Next());
                }

                Console.WriteLine();

            } while (true);
        }
    }

    public class CombinationIterator
    {
        private readonly string _characters;
        private readonly int _combinationLength;
        private readonly IEnumerator<string> _enumerator;
        private bool _hasNext;

        public CombinationIterator(string characters, int combinationLength)
        {
            if (characters == null)
            {
                throw new ArgumentNullException(nameof(characters));
            }

            if (characters == String.Empty)
            {
                throw new ArgumentException($"{nameof(characters)} can't be empty string");
            }

            if (combinationLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(combinationLength));
            }

            _characters = characters ?? String.Empty;
            _combinationLength = combinationLength;

            _enumerator = GetEnumerable().GetEnumerator();
            _hasNext = _enumerator.MoveNext();
        }

        public string Next()
        {
            if (_hasNext == false)
            {
                return null;
            }

            var current = _enumerator.Current;

            _hasNext = _enumerator.MoveNext();

            return current;
        }

        public bool HasNext()
        {
            return _hasNext;
        }

        private IEnumerable<string> GetEnumerable()
        {
            var taken = new HashSet<int>();
            var order = _characters[0].CompareTo(_characters[_characters.Length - 1]);

            for (int i = 0; i < _characters.Length; i++)
            {
                var c = _characters[i];
                
                taken.Add(i);

                foreach (var combination in GetCombinations(_combinationLength - 1, taken, c, order))
                {
                    yield return c + combination;
                }

                taken.Remove(i);
            }

            yield break;
        }

        private IEnumerable<string> GetCombinations(int length, HashSet<int> taken, char prev, int order)
        {
            if (length == 0)
            {
                yield return "";
            }
            else
            {
                for (int i = 0; i < _characters.Length; i++)
                {
                    if (taken.Contains(i))
                    {
                        continue;
                    }

                    var c = _characters[i];
                    var o = prev.CompareTo(c);

                    if (o < 0 != order < 0)
                    {
                        continue;
                    }

                    if (length == 1)
                    {
                        yield return "" + c;
                    }
                    else
                    {
                        taken.Add(i);

                        foreach (var combination in GetCombinations(length - 1, taken, c, o))
                        {
                            yield return c + combination;
                        }

                        taken.Remove(i);
                    }
                }
            }

            yield break;
        }
    }
}
