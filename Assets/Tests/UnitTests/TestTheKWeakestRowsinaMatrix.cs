using System.Collections.Generic;
using NUnit.Framework;
using TheKWeakestRowsinaMatrix;

public class TestTheKWeakestRowsinaMatrix
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[][] {
                new int[] { 1,1,0,0,0 },
                new int[] { 1,1,1,1,0 },
                new int[] { 1,0,0,0,0 },
                new int[] { 1,1,0,0,0 },
                new int[] { 1,1,1,1,1 } },
                3,
                new int[] { 2, 0, 3 } )
                .SetName("Example 1");

            yield return new TestCaseData(new int[][] {
                new int[] { 1,0,0,0 },
                new int[] { 1,1,1,1 },
                new int[] { 1,0,0,0 },
                new int[] { 1,0,0,0 } },
                2,
                new int[] { 0, 2 })
                .SetName("Example 2");

            yield return new TestCaseData(new int[][] {
                new int[] { 1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
                new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 } },
                17,
                new int[] { 10, 12, 15, 4, 14, 16, 2, 7, 11, 3, 5, 0, 13, 1, 9, 17, 6 })
                .SetName("Example 3");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_TheKWeakestRowsinaMatrix(int[][] mat, int k, int[] result)
    {
        Solution solution = new Solution();
        int[] output = solution.KWeakestRows(mat, k);

        CollectionAssert.AreEqual(result, output);
    }
}
