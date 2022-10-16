using NUnit.Framework;
using DiameterofBinaryTree;

public class TestDiameterofBinaryTree
{
    [Test]
    [TestCase(new object[] { 1, 2, 3, 4, 5 }, 3, TestName = "Example 1")]
    [TestCase(new object[] { 1, 2 }, 1, TestName = "Example 2")]
    public void Calculate_DiameterofBinaryTree(object[] objects, int result)
    {
        int?[] values = IntArrayUtility.ToIntNullableArray(objects);
        TreeNode root = BinaryTreeUtility.InsertLevelOrder(values, 0);

        Solution solution = new Solution();
        int output = solution.DiameterOfBinaryTree(root);

        Assert.AreEqual(result, output);
    }
}
