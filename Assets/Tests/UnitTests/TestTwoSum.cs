using NUnit.Framework;
using TwoSum;

public class TestTwoSum
{
    [Test]
    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 }, TestName = "Example 1")]
    [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 }, TestName = "Example 2")]
    [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 }, TestName = "Example 3")]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 5, 11 }, TestName = "Example 4")]
    public void Calculate_TwoSum(int[] nums, int target, int[] result)
    {
        Solution solution = new Solution();
        int[] output = solution.TwoSum(nums, target);

        CollectionAssert.AreEqual(result, output);
    }
}
