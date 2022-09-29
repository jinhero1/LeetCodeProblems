namespace PalindromeLinkedList
{
    // O(n) time and O(1) space
    // Memory Usage: 52 MB, less than 80.88% of C# online submissions for Palindrome Linked List.
    public class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            ListNode currentNode = head;
            ListNode previousNode = null;
            int listLength = GetLength(head);

            ListNode _originalNext;
            // Reverse the half
            for (int i = 0; i < listLength / 2; i++)
            {
                _originalNext = currentNode.next;
                // Reverse the direction of next
                currentNode.next = previousNode;
                // (prev, curr) go to next group 
                previousNode = currentNode;
                currentNode = _originalNext;
            }

            // If it is odd length, skip the middle node
            if (listLength % 2 != 0)
            {
                currentNode = currentNode.next;
            }

            while (currentNode != null && previousNode != null)
            {
                if (currentNode.val != previousNode.val)
                {
                    return false;
                }

                currentNode = currentNode.next;
                previousNode = previousNode.next;
            }

            return true;
        }

        private int GetLength(ListNode root)
        {
            int result = 0;
            ListNode head = root;

            while (head != null)
            {
                result++;

                head = head.next;
            }

            return result;
        }
    }
}