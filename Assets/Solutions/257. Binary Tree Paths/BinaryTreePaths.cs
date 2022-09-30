using System.Collections.Generic;

namespace BinaryTreePaths
{
    public class Solution
    {
        private const string PATH_FORMAT = "{0}->{1}";

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> output = new List<string>();

            BinaryTreePaths(output, root, root.val.ToString());

            return output;
        }

        private void BinaryTreePaths(List<string> output, TreeNode node, string s)
        {
            // A leaf is a node with no children
            if (node.left == null && node.right == null)
            {
                output.Add(s);
                return;
            }

            if (node.left != null)
            {
                BinaryTreePaths(output, node.left, string.Format(PATH_FORMAT, s, node.left.val));
            }

            if (node.right != null)
            {
                BinaryTreePaths(output, node.right, string.Format(PATH_FORMAT, s, node.right.val));
            }
        }
    }
}