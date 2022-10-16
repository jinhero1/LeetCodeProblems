using System;

namespace DiameterofBinaryTree
{
    public class Solution
    {
        private const int ZERO = 0;
        private const int ONE = 1;

        private int diameter;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            CalculateHeight(root);

            return diameter;
        }

        private int CalculateHeight(TreeNode root)
        {
            if (root == null) return ZERO;

            int leftHeight = CalculateHeight(root.left);
            int rightHeight = CalculateHeight(root.right);
            diameter = Math.Max(diameter, leftHeight + rightHeight);

            return Math.Max(leftHeight, rightHeight) + ONE;
        }
    }
}