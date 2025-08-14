using NUnit.Framework;
using System.Collections;
using MaximumAverageSubarrayI;

public class TestMaximumAverageSubarrayI
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData((object)new int[] { 1, 12, -5, -6, 50, 3 }, 4, 12.75);
            yield return new TestCaseData((object)new int[] { 5 }, 1, 5.0);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_FindMaxAverage(int[] nums, int k, double expected)
    {
        var result = new Solution().FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result, 1e-5);
    }
}
