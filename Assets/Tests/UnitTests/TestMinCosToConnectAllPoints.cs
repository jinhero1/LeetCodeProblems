using NUnit.Framework;
using System.Collections;
using MinCosToConnectAllPoints;

public class TestMinCosToConnectAllPoints
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                (object)new int[][] {
                    new[] { 0, 0 },
                    new[] { 2, 2 },
                    new[] { 3, 10 },
                    new[] { 5, 2 },
                    new[] { 7, 0 }
                }
            ).Returns(20);

            // Example 2
            yield return new TestCaseData(
                (object)new int[][] {
                    new[] { 3, 12 },
                    new[] { -2, 5 },
                    new[] { -4, 1 }
                }
            ).Returns(18);

            // Example 3
            yield return new TestCaseData(
                (object)new int[][] {
                    new[] { 0, 0 },
                    new[] { 100, 100 },
                    new[] { 1, 100 },
                    new[] { 100, 1 }
                }
            ).Returns(299);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_MinCostConnectPoints(int[][] points)
        => new Solution().MinCostConnectPoints(points);
}
