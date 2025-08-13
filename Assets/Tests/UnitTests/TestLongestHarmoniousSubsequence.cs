using NUnit.Framework;
using System.Collections;
using LongestHarmoniousSubsequence;

public class TestLongestHarmoniousSubsequence
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData((object)new int[] { 1, 3, 2, 2, 5, 2, 3, 7 }).Returns(5);
            yield return new TestCaseData((object)new int[] { 1, 2, 3, 4 }).Returns(2);
            yield return new TestCaseData((object)new int[] { 1, 1, 1, 1 }).Returns(0);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_FindLHS(int[] nums)
        => new Solution().FindLHS(nums);
}
