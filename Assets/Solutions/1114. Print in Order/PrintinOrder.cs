using System;
using System.Threading;

namespace PrintinOrder
{
    public class Foo
    {
        private const int ZERO = 0;
        private const int ONE = 1;

        private readonly Semaphore first = new Semaphore(ONE, ONE);
        private readonly Semaphore second = new Semaphore(ZERO, ONE);
        private readonly Semaphore third = new Semaphore(ZERO, ONE);

        public void First(Action printFirst)
        {
            first.WaitOne();
            printFirst();
            second.Release();
        }

        public void Second(Action printSecond)
        {
            second.WaitOne();
            printSecond();
            third.Release();
        }

        public void Third(Action printThird)
        {
            third.WaitOne();
            printThird();
            // Allow the waiting threads to enter the semaphore 
            first.Release();
        }
    }
}