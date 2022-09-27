using System.Collections.Generic;
using UnityEngine;

namespace BinaryTreeInorderTraversal
{
    public class Solution
    {
        private const int ZERO = 0;

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> output = new List<int>();
            Stack<TreeNode> nodeStack = new Stack<TreeNode>(100);

            TreeNode head = root;
            while (head != null || nodeStack.Count != ZERO)
            {
                // Deep search left side
                while (head != null)
                {
                    nodeStack.Push(head);
                    head = head.left;
                }

                // Deepest left side
                head = nodeStack.Pop();
                output.Add(head.val);

                // No element in left side, so change to right side
                head = head.right;
            }

            return output;
        }
    }

    public class BinaryTreeInorderTraversal : MonoBehaviour
    {
        void Start()
        {
            //int?[] values = new int?[] { 1, null, 2, null, null, 3 }; // Example Input: root = [1,null,2,3]
            //int?[] values = new int?[] { 3, 1, 2 };
            int?[] values = new int?[] { 3, 1, null, null, 2 };
            TreeNode root = BinaryTreeUtility.InsertLevelOrder(values, 0);

            Solution solution = new Solution();
            IList<int> output = solution.InorderTraversal(root);
            DebugUtility.Log(output);
        }
    }
}