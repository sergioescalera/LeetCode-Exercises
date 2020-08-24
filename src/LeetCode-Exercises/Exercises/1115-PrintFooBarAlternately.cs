using System;
using System.Threading;

namespace LeetCode.Exercises
{
    public class PrintFooBarAlternately
    {
        public class FooBar
        {
            private int n;

            private CountdownEvent cd1;
            private CountdownEvent cd2;

            public FooBar(int n)
            {
                this.n = n;

                this.cd1 = new CountdownEvent(0);
                this.cd2 = new CountdownEvent(1);
            }

            public void Foo(Action printFoo)
            {
                for (int i = 0; i < n; i++)
                {
                    cd1.Wait();

                    printFoo();

                    cd1.Dispose();
                    cd1 = new CountdownEvent(1);

                    cd2.Signal();
                }
            }

            public void Bar(Action printBar)
            {
                for (int i = 0; i < n; i++)
                {
                    cd2.Wait();

                    printBar();

                    cd2.Dispose();
                    cd2 = new CountdownEvent(1);

                    cd1.Signal();
                }
            }
        }
    }
}
