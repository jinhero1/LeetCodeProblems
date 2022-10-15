using System.Collections.Generic;

namespace KthLargestElementinaStream
{
    public class KthLargest
    {
        private const int MINIMUM_VALUE = -10001;
        private const int ZERO = 0;
        private const int ONE = 1;

        private int minimumElement = MINIMUM_VALUE;
        private int maxCount;
        private int _index;
        private PriorityQueue<int> priorityQueue = null;

        public KthLargest(int k, int[] nums)
        {
            maxCount = k;

            priorityQueue = new PriorityQueue<int>(nums);
            int removeCount = nums.Length - maxCount;
            SortAndTrim(removeCount);
        }

        public int Add(int val)
        {
            if (val > minimumElement)
            {
                priorityQueue.Enqueue(val);
                SortAndTrim(ONE);
            }

            return minimumElement;
        }

        private void SortAndTrim(int removeCount)
        {
            if (removeCount <= ZERO) return;

            if (priorityQueue.Count() > maxCount)
            {
                for (_index = ZERO; _index < removeCount; _index++)
                {
                    priorityQueue.Dequeue();
                }
            }
            minimumElement = priorityQueue.Peek();
        }
    }

    public class PriorityQueue<T>
    {
        private const int ZERO = 0;
        private const int ONE = 1;

        private SortedList<T, int> sortedList = new SortedList<T, int>();
        private int count = ZERO;
        private T _firstElement;

        public PriorityQueue(T[] elements)
        {
            for (int i = ZERO; i < elements.Length; i++)
            {
                Enqueue(elements[i]);
            }            
        }

        public void Enqueue(T element)
        {
            if (sortedList.ContainsKey(element))
            {
                sortedList[element]++;
            }
            else
            {
                sortedList.Add(element, ONE);
            }

            count++;
        }

        public T Dequeue()
        {
            _firstElement = sortedList.Keys[ZERO];
            if (--sortedList[_firstElement] == ZERO)
            {
                sortedList.RemoveAt(ZERO);
            }
            count--;

            return _firstElement;
        }

        public T Peek()
        {
            _firstElement = sortedList.Keys[ZERO];

            return _firstElement;
        }

        public int Count()
        {
            return count;
        }
    }
}
