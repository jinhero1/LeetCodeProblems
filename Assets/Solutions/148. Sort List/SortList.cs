namespace SortList
{
    public class Solution
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            // 1. Compute the length of the list
            int length = 0;
            for (var p = head; p != null; p = p.next)
                length++;

            // 2. Dummy node to simplify merges
            var dummy = new ListNode(0, head);

            // 3. Bottom-up merge sort: sublist sizes 1, 2, 4, 8, ...
            for (int size = 1; size < length; size <<= 1)
            {
                var prev = dummy;
                var curr = dummy.next;

                while (curr != null)
                {
                    // 3a. Split off the first sublist of length 'size'
                    var left = curr;
                    var right = Split(left, size);

                    // 3b. Split off the second sublist of length 'size'
                    curr = Split(right, size);

                    // 3c. Merge 'left' and 'right', attach to prev
                    prev = Merge(left, right, prev);
                }
            }

            return dummy.next;
        }

        // Split the list starting at head into two parts:
        // first 'size' nodes, and the rest. 
        // Returns the head of the rest, and terminates the first part.
        private ListNode Split(ListNode head, int size)
        {
            for (int i = 1; head != null && i < size; i++)
            {
                head = head.next;
            }
            if (head == null) return null;
            var second = head.next;
            head.next = null;
            return second;
        }

        // Merge two sorted sublists 'left' and 'right', appending them after 'prev'.
        // Returns the tail node of the merged result.
        private ListNode Merge(ListNode left, ListNode right, ListNode prev)
        {
            // 'current' tracks the last node in the merged list
            var current = prev;

            // While both sublists have nodes, attach the smaller one
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    current.next = left;
                    left = left.next;
                }
                else
                {
                    current.next = right;
                    right = right.next;
                }
                // Move current to the newly attached node
                current = current.next;
            }

            // Attach whichever sublist still has nodes remaining
            current.next = (left != null) ? left : right;

            // Advance current to the end of the merged section
            while (current.next != null)
                current = current.next;

            return current;
        }
    }
}
