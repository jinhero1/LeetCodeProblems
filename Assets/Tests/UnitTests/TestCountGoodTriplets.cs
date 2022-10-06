using NUnit.Framework;
using CountGoodTriplets;

public class TestCountGoodTriplets
{
    [Test]
    [TestCase(new int[] { 3, 0, 1, 1, 9, 7 }, 7, 2, 3, 4, TestName = "Example 1")]
    [TestCase(new int[] { 1, 1, 2, 2, 3 }, 0, 0, 1, 0, TestName = "Example 2")]
    public void Calculate_CountGoodTriplets(int[] arr, int a, int b, int c, int result)
    {
        Solution solution = new Solution();
        int output = solution.CountGoodTriplets(arr, a, b, c);

        Assert.AreEqual(result, output);
    }
}
