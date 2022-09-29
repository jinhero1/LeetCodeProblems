using NUnit.Framework;
using ClimbingStairs;

public class TestClimbingStairs
{
    [Test]
    [TestCase(8, 34)]
    [TestCase(35, 14930352)]
    public void Calculate_ClimbingStairs(int n, int result)
    {
        Solution solution = new Solution();
        int output = solution.ClimbStairs(n);

        Assert.AreEqual(result, output);
    }
}
