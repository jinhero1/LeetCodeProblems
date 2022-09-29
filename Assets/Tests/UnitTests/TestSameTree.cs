using NUnit.Framework;
using SameTree;

public class TestSameTree
{
    [Test]
    [TestCase(new object[] { 1, 2, 3 }, new object[] { 1, 2, 3 }, true, TestName = "Example 1")]
    [TestCase(new object[] { 1, 2 }, new object[] { 1, null, 2 }, false, TestName = "Example 2")]
    [TestCase(new object[] { 1, 2, 1 }, new object[] { 1, 1, 2 }, false, TestName = "Example 3")]
    [TestCase(new object[] { 1, 1 }, new object[] { 1, null, 1 }, false, TestName = "Example 4")]
    public void Calculate_SameTree(object[] pObjects, object[] qObjects, bool result)
    {
        int?[] pValues = IntArrayUtility.ToIntNullableArray(pObjects);
        int?[] qValues = IntArrayUtility.ToIntNullableArray(qObjects);
        TreeNode p = BinaryTreeUtility.InsertLevelOrder(pValues, 0);
        TreeNode q = BinaryTreeUtility.InsertLevelOrder(qValues, 0);

        Solution solution = new Solution();
        bool output = solution.IsSameTree(p, q);

        Assert.AreEqual(result, output);
    }
}
