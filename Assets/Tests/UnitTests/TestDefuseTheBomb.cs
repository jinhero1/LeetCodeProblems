using NUnit.Framework;
using System.Collections;
using DefuseTheBomb;

public class TestDefuseTheBomb
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(
                (object)new int[] { 5, 7, 1, 4 }, 3,
                (object)new int[] { 12, 10, 16, 13 }
            );
            yield return new TestCaseData(
                (object)new int[] { 1, 2, 3, 4 }, 0,
                (object)new int[] { 0, 0, 0, 0 }
            );
            yield return new TestCaseData(
                (object)new int[] { 2, 4, 9, 3 }, -2,
                (object)new int[] { 12, 5, 6, 13 }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_Decrypt(int[] code, int k, int[] expected)
    {
        var result = new Solution().Decrypt(code, k);
        CollectionAssert.AreEqual(expected, result);
    }
}
