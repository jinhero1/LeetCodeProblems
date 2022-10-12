using NUnit.Framework;
using NimGame;

public class TestNimGame
{
    [Test]
    [TestCase(4, false)]
    [TestCase(1, true)]
    [TestCase(2, true)]
    public void Calculate_NimGame(int n, bool result)
    {
        Solution solution = new Solution();
        bool output = solution.CanWinNim(n);

        Assert.AreEqual(result, output);
    }
}