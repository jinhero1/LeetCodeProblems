using NUnit.Framework;
using SumofAllSubsetXORTotals;

public class TestSumofAllSubsetXORTotals
{
    [Test]
    [TestCase(new int[] { 1, 3 }, 6, TestName = "Example 1")]
    [TestCase(new int[] { 5, 1, 6 }, 28, TestName = "Example 2")]
    [TestCase(new int[] { 3, 4, 5, 6, 7, 8 }, 480, TestName = "Example 3")]
    public void Calculate_SumofAllSubsetXORTotals(int[] nums, int result)
    {
        Solution solution = new Solution();
        int output = solution.SubsetXORSum(nums);

        Assert.AreEqual(result, output);
    }
}
