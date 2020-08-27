using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class FizzBuzzMultithreaded
    {   
        public static void Run()
        {
            do
            {
                var n = 0.ReadNum("Enter n");

                if (n == null) break;

                var fb = new FizzBuzz(n.Value);

                var tasks = new Action[]
                {
                    () => fb.Buzz(() => Console.Write("Buzz ")),
                    () => fb.Fizz(() => Console.Write("Fizz ")),
                    () => fb.Fizzbuzz(() => Console.Write("Fizzbuzz ")),
                    () => fb.Number((x) => Console.Write(x + " "))
                }
                .Select(o => Task.Factory.StartNew(o))
                .ToArray();

                Task.WaitAll(tasks);

                Console.WriteLine();

            } while (true);
        }

        /// <summary>
        /// Implement a multithreaded version of FizzBuzz with four threads. 
        /// The same instance of FizzBuzz will be passed to four different threads:
        /// 
        /// Thread A will call fizz() to check for divisibility of 3 and outputs fizz.
        /// Thread B will call buzz() to check for divisibility of 5 and outputs buzz.
        /// Thread C will call fizzbuzz() to check for divisibility of 3 and 5 and outputs fizzbuzz.
        /// Thread D will call number() which should only output the numbers.
        /// </summary>
        public class FizzBuzz
        {
            private int n;
            private int current = 1;

            private SemaphoreSlim number = new SemaphoreSlim(0, 1);
            private SemaphoreSlim fizz = new SemaphoreSlim(0, 1);
            private SemaphoreSlim buzz = new SemaphoreSlim(0, 1);
            private SemaphoreSlim fizzbuzz = new SemaphoreSlim(0, 1);

            public FizzBuzz(int n)
            {
                this.n = n;

                this.number.Release();
            }

            public void Fizz(Action printFizz)
            {
                do
                {
                    if (fizz.Wait(100))
                    {
                        if (current <= n && current % 3 == 0 && current % 5 != 0)
                        {
                            printFizz();

                            current++;
                        }

                        ReleaseSemaphore();
                    }

                } while (current <= n);

            }

            public void Buzz(Action printBuzz)
            {
                do
                {
                    if (buzz.Wait(100))
                    {
                        if (current <= n && current % 5 == 0 && current % 3 != 0)
                        {
                            printBuzz();

                            current++;
                        }

                        ReleaseSemaphore();
                    }

                } while (current <= n);
            }

            public void Fizzbuzz(Action printFizzBuzz)
            {
                do
                {
                    if (fizzbuzz.Wait(100))
                    {
                        if (current <= n && current % 3 == 0 && current % 5 == 0)
                        {
                            printFizzBuzz();

                            current++;
                        }

                        ReleaseSemaphore();
                    }

                } while (current <= n);
            }

            public void Number(Action<int> printNumber)
            {
                do
                {
                    if (number.Wait(100))
                    {
                        if (current <= n && current % 3 != 0 && current % 5 != 0)
                        {
                            printNumber(current);

                            current++;
                        }

                        ReleaseSemaphore();
                    }

                } while (current <= n);
            }

            private void ReleaseSemaphore()
            {
                if (current > n)
                {
                    new List<SemaphoreSlim>
                    {
                        fizz,
                        buzz,
                        fizzbuzz,
                        number
                    }
                    .ForEach(s =>
                    {
                        if (s.CurrentCount == 0)
                        {
                            s.Release();
                        }
                    });
                }

                else if (current % 3 == 0 && current % 5 == 0)
                {
                    fizzbuzz.Release();
                }
                else if (current % 3 == 0)
                {
                    fizz.Release();
                }
                else if (current % 5 == 0)
                {
                    buzz.Release();
                }
                else
                {
                    number.Release();
                }
            }
        }
    }
}
