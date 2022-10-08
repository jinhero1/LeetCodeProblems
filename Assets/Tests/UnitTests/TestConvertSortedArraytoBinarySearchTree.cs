using NUnit.Framework;
using ConvertSortedArraytoBinarySearchTree;
using System.Collections.Generic;

public class TestConvertSortedArraytoBinarySearchTree
{
    [Test]
    [TestCase(new int[] { -10, -3, 0, 5, 9 }, new object[] { 0, -10, 5, null, -3, null, 9 }, TestName = "Example 1")]
    [TestCase(new int[] { 1, 3 }, new object[] { 1, null, 3 }, TestName = "Example 2")]
    public void Calculate_ConvertSortedArraytoBinarySearchTree(int[] nums, object[] resultObjects)
    {
        int?[] result = IntArrayUtility.ToIntNullableArray(resultObjects);

        Solution solution = new Solution();
        TreeNode root = solution.SortedArrayToBST(nums);
        IList<int?> output = BinaryTreeUtility.BreadthTraversal(root);

        CollectionAssert.AreEqual(result, output);        
    }
}
