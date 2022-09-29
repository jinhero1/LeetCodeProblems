using NUnit.Framework;
using RomantoInteger;

public class TestRomantoInteger
{
    [Test]
    [TestCase("III", 3)]
    [TestCase("LVIII", 58)]
    [TestCase("MCMXCIV", 1994)]
    public void Calculate_RomantoInteger(string s, int result)
    {
        Solution solution = new Solution();
        int output = solution.RomanToInt(s);

        Assert.AreEqual(result, output);
    }
}
