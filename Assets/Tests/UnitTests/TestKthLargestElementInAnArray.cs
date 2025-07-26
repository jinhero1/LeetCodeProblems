using NUnit.Framework;
using System.Collections;
using KthLargestElementInAnArray;

public class TestKthLargestElementInAnArray
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1: nums = [3,2,1,5,6,4], k = 2 → 5
            yield return new TestCaseData(
                (object)new int[] { 3, 2, 1, 5, 6, 4 },
                2
            ).Returns(5);

            // Example 2: nums = [3,2,3,1,2,4,5,5,6], k = 4 → 4
            yield return new TestCaseData(
                (object)new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 },
                4
            ).Returns(4);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_FindKthLargest(int[] nums, int k)
        => new Solution().FindKthLargest(nums, k);
}
