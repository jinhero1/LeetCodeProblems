using NUnit.Framework;
using LargestTriangleArea;
using System.Collections.Generic;

public class TestLargestTriangleArea
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[][] {
                new int[] { 0, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, 2 },
                new int[] { 2, 0 } },
                2)
                .SetName("Example 1");

            yield return new TestCaseData(new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 0 },
                new int[] { 0, 1 } },
                0.5)
                .SetName("Example 2");

            yield return new TestCaseData(new int[][] {
                new int[] { 4, 6 },
                new int[] { 6, 5 },
                new int[] { 3, 1 } },
                5.5)
                .SetName("Example 3");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_LargestTriangleArea(int[][] points, double result)
    {
        Solution solution = new Solution();
        double output = solution.LargestTriangleArea(points);

        Assert.AreEqual(result, output);
    }
}
