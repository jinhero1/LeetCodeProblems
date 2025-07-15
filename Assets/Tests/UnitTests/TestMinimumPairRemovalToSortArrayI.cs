using NUnit.Framework;
using System.Collections;
using MinimumPairRemovalToSortArrayI;

public class TestMinimumPairRemovalToSortArrayI
{
    public static IEnumerable MinimumPairRemovalTestCases
    {
        get
        {
            yield return new TestCaseData(new int[] { 3, 6, 4, -6, 2, -4, 5, -7, -3, 6, 3, -4 }).Returns(10);
            yield return new TestCaseData(new int[] { 2, 2, -1, 3, -2, 2, 1, 1, 1, 0, -1 }).Returns(9);
            yield return new TestCaseData(new int[] { 2, 1, 3, 2 }).Returns(2);
            yield return new TestCaseData(new int[] { 5, 2, 3, 1 }).Returns(2);
            yield return new TestCaseData(new int[] { 1, 2, 2 }).Returns(0);
        }
    }

    [TestCaseSource(nameof(MinimumPairRemovalTestCases))]
    public int Test_MinimumPairRemoval(int[] nums)
        => new Solution().MinimumPairRemoval(nums);
}
