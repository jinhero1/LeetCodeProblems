using NUnit.Framework;
using NextGreaterElementI;

public class TestNextGreaterElementI
{
    [Test]
    [TestCase(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 }, TestName = "Example 1")]
    [TestCase(new int[] { 2, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 3, -1 }, TestName = "Example 2")]
    [TestCase(new int[] { 1, 3, 5, 2, 4 }, new int[] { 6, 5, 4, 3, 2, 1, 7 }, new int[] { 7, 7, 7, 7, 7 }, TestName = "Example 3")]
    public void Calculate_NextGreaterElementI(int[] nums1, int[] nums2, int[] result)
    {
        Solution solution = new Solution();
        int[] output = solution.NextGreaterElement(nums1, nums2);

        CollectionAssert.AreEqual(result, output);
    }
}
