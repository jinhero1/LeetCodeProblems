using NUnit.Framework;
using System.Collections;
using MaximumGap;

public class TestMaximumGap
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                (object)new int[] { 3, 6, 9, 1 }
            ).Returns(3);

            // Example 2
            yield return new TestCaseData(
                (object)new int[] { 10 }
            ).Returns(0);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_MaximumGap(int[] nums)
        => new Solution().MaximumGap(nums);
}