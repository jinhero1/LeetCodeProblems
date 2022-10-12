using NUnit.Framework;
using SubtreeofAnotherTree;

public class TestSubtreeofAnotherTree
{
    [Test]
    [TestCase(new object[] { 3, 4, 5, 1, 2 }, new object[] { 4, 1, 2 }, true, TestName = "Example 1")]
    [TestCase(new object[] { 3, 4, 5, 1, 2, null, null, null, null, 0 }, new object[] { 4, 1, 2 }, false, TestName = "Example 2")]
    public void Calculate_SubtreeofAnotherTree(object[] rootObjects, object[] subRootObjects, bool result)
    {
        int?[] rootValues = IntArrayUtility.ToIntNullableArray(rootObjects);
        int?[] subRootValues = IntArrayUtility.ToIntNullableArray(subRootObjects);
        TreeNode root = BinaryTreeUtility.InsertLevelOrder(rootValues, 0);
        TreeNode subRoot = BinaryTreeUtility.InsertLevelOrder(subRootValues, 0);

        Solution solution = new Solution();
        bool output = solution.IsSubtree(root, subRoot);

        Assert.AreEqual(result, output);
    }
}