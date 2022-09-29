using System.Collections.Generic;

namespace BinaryTreeInorderTraversal
{
    // Memory Usage: 40.5 MB, less than 96.36% of C# online submissions for Binary Tree Inorder Traversal.
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
}