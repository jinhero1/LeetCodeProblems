using System;

namespace LinkedListRandomNode
{
    public class Solution
    {
        private readonly ListNode head;
        private readonly Random rnd = new();
        private int result, count, r;
        private ListNode node;

        public Solution(ListNode head)
        {
            this.head = head;
        }

        public int GetRandom()
        {
            result = 0;
            count = 0;
            node = head;

            while (node != null)
            {
                count++;
                // pick a random index in [1..count]
                r = rnd.Next(1, count + 1);
                if (r == count)
                {
                    // replace reservoir with current node
                    result = node.val;
                }
                node = node.next;
            }

            return result;
        }
    }
}
