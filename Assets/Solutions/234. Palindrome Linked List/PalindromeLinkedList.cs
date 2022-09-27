using UnityEngine;

namespace PalindromeLinkedList
{
    public class Solution
    {
        #region O(n) time and O(1) space
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
        #endregion

        #region O(n) time and O(n) space
        /*
        public bool IsPalindrome(ListNode head)
        {
            IList<int> nodeList = Traversal(head);

            int headIndex = 0;
            int tailIndex = nodeList.Count - 1;

            while (headIndex < tailIndex)
            {
                if (nodeList[headIndex] != nodeList[tailIndex])
                {
                    return false;
                }

                headIndex++;
                tailIndex--;
            }

            return true;
        }

        private IList<int> Traversal(ListNode root)
        {
            List<int> output = new List<int>();
            ListNode head = root;

            while (head != null)
            {
                output.Add(head.val);

                head = head.next;
            }

            return output;
        }
        */
        #endregion
    }

    public class PalindromeLinkedList : MonoBehaviour
    {
        void Start()
        {
            //int[] values = { 1, 2, 2, 1 };
            //int[] values = { 1, 2 };
            int[] values = { 1, 0, 1 }; // true;
            //int[] values = { 1 }; // true;
            ListNode root = SinglyLinkedListUtility.InsertLevelOrder(values, 0);

            Solution solution = new Solution();
            bool output = solution.IsPalindrome(root);
            Debug.Log($"Output: {output}");
        }
    }
}