using NUnit.Framework;
using AddDigits;

public class TestAddDigits
{
    [Test]
    [TestCase(38, 2)]
    [TestCase(0, 0)]
    public void Calculate_AddDigits(int num, int result)
    {
        Solution solution = new Solution();
        int output = solution.AddDigits(num);

        Assert.AreEqual(result, output);
    }
}
