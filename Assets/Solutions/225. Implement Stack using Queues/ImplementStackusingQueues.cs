using System.Collections.Generic;
using UnityEngine;

namespace ImplementStackusingQueues
{
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

    /*
    public class MyStack
    {
        private const int ZERO = 0;
        private const int ONE = 1;
        private Queue<int> queue1, queue2;
        private int? lastElement;

        public MyStack()
        {
            queue1 = new Queue<int>();
            queue2 = new Queue<int>();
        }

        public void Push(int x)
        {
            queue1.Enqueue(x);
            lastElement = x;
        }

        public int Pop()
        {
            // Other elements give to second Queue
            while (queue1.Count > ONE)
            {
                queue2.Enqueue(queue1.Dequeue());
            }

            // The last element
            int x = queue1.Dequeue();

            // Swap all elements
            while (queue2.Count > ONE)
            {
                queue1.Enqueue(queue2.Dequeue());
            }

            if (queue2.Count == 0)
            {
                lastElement = null;
            }
            else
            {
                // Save the last element
                lastElement = queue2.Dequeue();
                queue1.Enqueue(lastElement.Value);
            }            

            return x;
        }

        public int Top()
        {
            return lastElement.Value;
        }

        public bool Empty()
        {
            return queue1.Count == ZERO;
        }
    }
    */

    public class ImplementStackusingQueues : MonoBehaviour
    {
        void Start()
        {
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            int output = myStack.Top();
            Debug.Log($"Output: {output}");
            output = myStack.Pop();
            Debug.Log($"Output: {output}");
            /*
            myStack.Push(1);
            int output = myStack.Pop();
            Debug.Log($"Output: {output}");
            */
            bool isEmpty = myStack.Empty();
            Debug.Log($"isEmpty: {isEmpty}");
        }
    }
}