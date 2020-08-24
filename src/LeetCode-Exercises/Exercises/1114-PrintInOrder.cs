using System;
using System.Threading;

namespace LeetCode.Exercises
{
    public class PrintInOrder
    {

    }

    public class Foo
    {
        private CountdownEvent cd1;
        private CountdownEvent cd2;

        public Foo()
        {
            cd1 = new CountdownEvent(1);
            cd2 = new CountdownEvent(1);
        }

        public void First(Action printFirst)
        {
            printFirst();

            cd1.Signal();
        }

        public void Second(Action printSecond)
        {
            cd1.Wait();

            printSecond();

            cd2.Signal();
        }

        public void Third(Action printThird)
        {
            cd2.Wait();

            printThird();
        }
    }
}
