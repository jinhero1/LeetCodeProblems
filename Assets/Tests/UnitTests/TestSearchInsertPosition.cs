using NUnit.Framework;
using SearchInsertPosition;

public class TestSearchInsertPosition
{
    [Test]
    [TestCase(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 7, 4)]
    [TestCase(new int[] { 1, 3, 5, 6 }, 4, 2)]
    public void Calculate_SearchInsertPosition(int[] nums, int target, int result)
    {
        Solution solution = new Solution();
        int output = solution.SearchInsert(nums, target);

        Assert.AreEqual(result, output);
    }
}
