using NUnit.Framework;
using BinaryTreePaths;
using System.Collections.Generic;

public class TestBinaryTreePaths
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new object[] { 1, 2, 3, null, 5 }, new List<string> { "1->2->5", "1->3" })
                .SetName("Example 1");

            yield return new TestCaseData(new object[] { 1 }, new List<string> { "1" })
                .SetName("Example 2");

            yield return new TestCaseData(new object[] { 1, null, 3 }, new List<string> { "1->3" })
                .SetName("Example 3");

            yield return new TestCaseData(new object[] { 1, 2, 3 }, new List<string> { "1->2", "1->3" })
                .SetName("Example 4");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_BinaryTreePaths(object[] objects, List<string> result)
    {
        int?[] values = IntArrayUtility.ToIntNullableArray(objects);
        TreeNode root = BinaryTreeUtility.InsertLevelOrder(values, 0);

        Solution solution = new Solution();
        IList<string> output = solution.BinaryTreePaths(root);

        CollectionAssert.AreEqual(result, output);
    }
}
