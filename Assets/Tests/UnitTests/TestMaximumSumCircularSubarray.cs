using NUnit.Framework;
using System.Collections;
using MaximumSumCircularSubarray;

public class TestMaximumSumCircularSubarray
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData((object)new int[] { 1, -2, 3, -2 }).Returns(3);
            // Example 2
            yield return new TestCaseData((object)new int[] { 5, -3, 5 }).Returns(10);
            // Example 3
            yield return new TestCaseData((object)new int[] { -3, -2, -3 }).Returns(-2);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_MaxSubarraySumCircular(int[] nums)
        => new Solution().MaxSubarraySumCircular(nums);
}
