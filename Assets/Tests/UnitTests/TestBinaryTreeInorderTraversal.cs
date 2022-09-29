using NUnit.Framework;
using BinaryTreeInorderTraversal;
using System.Collections.Generic;

public class TestBinaryTreeInorderTraversal
{
    [Test]
    [TestCase(new object[] { 1, null, 2, null, null, 3 }, new int[] { 1, 3, 2 }, TestName = "Example 1")]
    [TestCase(new object[] { }, new int[] { }, TestName = "Example 2")]
    [TestCase(new object[] { 1 }, new int[] { 1 }, TestName = "Example 3")]
    [TestCase(new object[] { 3, 1, 2 }, new int[] { 1, 3, 2 }, TestName = "Example 4")]
    [TestCase(new object[] { 3, 1, null, null, 2 }, new int[] { 1, 2, 3 }, TestName = "Example 5")]
    public void Calculate_BinaryTreeInorderTraversal(object[] objects, int[] result)
    {
        int?[] values = IntArrayUtility.ToIntNullableArray(objects);
        TreeNode root = BinaryTreeUtility.InsertLevelOrder(values, 0);

        Solution solution = new Solution();
        IList<int> output = solution.InorderTraversal(root);

        CollectionAssert.AreEqual(result, output);
    }
}
