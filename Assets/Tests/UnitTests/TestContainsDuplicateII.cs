using NUnit.Framework;
using ContainsDuplicateII;

public class TestContainsDuplicateII
{
    [Test]
    [TestCase(new int[] { 1, 2, 3, 1 }, 3, true, TestName = "Example 1")]
    [TestCase(new int[] { 1, 0, 1, 1 }, 1, true, TestName = "Example 2")]
    [TestCase(new int[] { 1, 2, 3, 1, 2, 3 }, 2, false, TestName = "Example 3")]
    public void Calculate_ContainsDuplicateII(int[] nums, int k, bool result)
    {
        Solution solution = new Solution();
        bool output = solution.ContainsNearbyDuplicate(nums, k);

        Assert.AreEqual(result, output);
    }
}
