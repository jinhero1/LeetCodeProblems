namespace ConvertSortedArraytoBinarySearchTree
{
    public class Solution
    {
        private const int TWO = 2;
        private const int ONE = 1;

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return CreateSubtree(nums, 0, nums.Length - ONE);
        }

        private TreeNode CreateSubtree(int[] arr, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int _midddle = (left + right) / TWO;

            TreeNode root = new TreeNode(arr[_midddle]);

            root.left = CreateSubtree(arr, left, _midddle - ONE);

            root.right = CreateSubtree(arr, _midddle + ONE, right);

            return root;
        }
    }
}