using System;
using System.Collections.Generic;
using System.Threading;

namespace LeetCode
{
    public class ZeroEvenOdd
    {
        private int _current;
        private bool _flag;

        private readonly int _n;
        
        private readonly SemaphoreSlim zero = new SemaphoreSlim(0, 1);
        private readonly SemaphoreSlim even = new SemaphoreSlim(0, 1);
        private readonly SemaphoreSlim odd = new SemaphoreSlim(0, 1);

        public ZeroEvenOdd(int n)
        {
            _n = n;
            _current = 0;
            _flag = true;

            zero.Release();
        }

        public void Zero(Action<int> printNumber)
        {
            do
            {
                if (zero.Wait(100))
                {
                    if (_flag && _current < _n)
                    {
                        printNumber(0);

                        _flag = false;
                    }

                    _current++;

                    ReleaseSemaphore();
                }

            } while (_current <= _n);
        }

        public void Even(Action<int> printNumber)
        {
            do
            {
                if (even.Wait(100))
                {
                    if (_current <= _n && _current % 2 == 0)
                    {
                        printNumber(_current);

                        _flag = true;
                    }

                    ReleaseSemaphore();
                }

            } while (_current <= _n);
        }

        public void Odd(Action<int> printNumber)
        {
            do
            {
                if (odd.Wait(100))
                {
                    if (_current <= _n && _current % 2 == 1)
                    {
                        printNumber(_current);

                        _flag = true;
                    }

                    ReleaseSemaphore();
                }

            } while (_current <= _n);
        }

        private void ReleaseSemaphore()
        {
            if (_current > _n)
            {
                ReleaseAll();
            }
            else if (_flag)
            {
                zero.Release();
            }
            else if (_current % 2 == 0)
            {
                even.Release();
            }
            else
            {
                odd.Release();
            }
        }

        private void ReleaseAll()
        {
            new List<SemaphoreSlim>
            {
                zero,
                even,
                odd
            }
            .ForEach(s =>
            {
                if (s.CurrentCount == 0)
                {
                    s.Release();
                }
            });
        }
    }
}
