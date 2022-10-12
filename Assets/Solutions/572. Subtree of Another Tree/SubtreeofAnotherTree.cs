namespace SubtreeofAnotherTree
{
    public class Solution
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null) return false;

            if (IsSameConstructor(root, subRoot))
            {
                return true;
            }

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        private bool IsSameConstructor(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;

            return IsSameConstructor(p.left, q.left) && IsSameConstructor(p.right, q.right);
        }
    }
}