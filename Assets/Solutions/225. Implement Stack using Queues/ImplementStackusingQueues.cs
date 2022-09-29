using System.Collections.Generic;

namespace ImplementStackusingQueues
{
    // Memory Usage: 38.7 MB, less than 99.29% of C# online submissions for Implement Stack using Queues.
    public class MyStack
    {
        private const int ZERO = 0;
        private Queue<int> queue;
        private int previousSize;

        public MyStack()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            previousSize = queue.Count;

            queue.Enqueue(x);

            for (int i = 0; i < previousSize; i++)
            {
                // Move the first-in element to last position
                queue.Enqueue(queue.Dequeue());
            }
        }

        public int Pop()
        {
            return queue.Dequeue();
        }

        public int Top()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == ZERO;
        }
    }
}