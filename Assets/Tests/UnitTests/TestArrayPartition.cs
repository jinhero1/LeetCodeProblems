using NUnit.Framework;
using System.Collections;
using ArrayPartition;

public class TestArrayPartition
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData((object)new int[] { 1, 4, 3, 2 }).Returns(4);
            yield return new TestCaseData((object)new int[] { 6, 2, 6, 5, 1, 2 }).Returns(9);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_ArrayPairSum(int[] nums)
        => new Solution().ArrayPairSum(nums);
}
