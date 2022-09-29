using NUnit.Framework;
using FindtheTownJudge;
using System.Collections.Generic;

public class TestFindtheTownJudge
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(2,
                new int[][] { new int[] { 1, 2 } },
                2)
                .SetName("Example 1");

            yield return new TestCaseData(3,
                new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } },
                3)
                .SetName("Example 2");

            yield return new TestCaseData(3,
                new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 1 } },
                -1)
                .SetName("Example 3");

            yield return new TestCaseData(1,
                new int[][] { },
                1)
                .SetName("Example 4");

            yield return new TestCaseData(3,
                new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } },
                -1)
                .SetName("Example 5");

            yield return new TestCaseData(4,
                new int[][] { new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 4, 3 } },
                3)
                .SetName("Example 6");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_FindtheTownJudge(int n, int[][] trust, int result)
    {
        Solution solution = new Solution();
        int output = solution.FindJudge(n, trust);

        Assert.AreEqual(result, output);
    }
}
