using NUnit.Framework;
using System.Collections;
using CanIWin;

public class TestCanIWin
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(10, 11).Returns(false);
            yield return new TestCaseData(10, 0).Returns(true);
            yield return new TestCaseData(10, 1).Returns(true);
            yield return new TestCaseData(3, 7).Returns(false);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public bool Test_CanIWin(int maxChoosableInteger, int desiredTotal)
        => new Solution().CanIWin(maxChoosableInteger, desiredTotal);
}
