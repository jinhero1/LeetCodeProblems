using NUnit.Framework;
using FirstBadVersion;

public class TestFirstBadVersion
{
    [Test]
    [TestCase(5, 4, 4)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 1)]
    [TestCase(2126753390, 1702766719, 1702766719)]
    public void Calculate_FirstBadVersion(int n, int bad, int result)
    {
        Solution solution = new Solution();
        solution.CommitBadVersion(bad);
        int output = solution.FirstBadVersion(n);

        Assert.AreEqual(result, output);
    }
}
