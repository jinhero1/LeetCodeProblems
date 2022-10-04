using NUnit.Framework;
using FindifPathExistsinGraph;
using System.Collections.Generic;

public class TestFindifPathExistsinGraph
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(3, new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 2 },
                new int[] { 2, 0 } },
                0, 2,
                true)
                .SetName("Example 1");

            yield return new TestCaseData(6, new int[][] {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 3, 5 },
                new int[] { 5, 4 },
                new int[] { 4, 3 } },
                0, 5,
                false)
                .SetName("Example 2");

            yield return new TestCaseData(10, new int[][] {
                new int[] { 4, 0 },
                new int[] { 0, 9 },
                new int[] { 5, 4 } },
                5, 9,
                true)
                .SetName("Example 3");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_FindifPathExistsinGraph(int n, int[][] edges, int source, int destination, bool result)
    {
        Solution solution = new Solution();
        bool output = solution.ValidPath(n, edges, source, destination);

        Assert.AreEqual(result, output);
    }
}
