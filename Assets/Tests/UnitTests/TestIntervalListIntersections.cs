using NUnit.Framework;
using System.Collections;
using IntervalListIntersections;

public class TestIntervalListIntersections
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                (object)new int[][] {
                    new[] { 0, 2 },
                    new[] { 5, 10 },
                    new[] { 13, 23 },
                    new[] { 24, 25 }
                },
                (object)new int[][] {
                    new[] { 1, 5 },
                    new[] { 8, 12 },
                    new[] { 15, 24 },
                    new[] { 25, 26 }
                },
                (object)new int[][] {
                    new[] { 1, 2 },
                    new[] { 5, 5 },
                    new[] { 8, 10 },
                    new[] { 15, 23 },
                    new[] { 24, 24 },
                    new[] { 25, 25 }
                }
            );

            // Example 2
            yield return new TestCaseData(
                (object)new int[][] {
                    new[] { 1, 3 },
                    new[] { 5, 9 }
                },
                (object)new int[][] { },
                (object)new int[][] { }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_IntervalIntersection(int[][] firstList, int[][] secondList, int[][] expected)
    {
        var result = new Solution().IntervalIntersection(firstList, secondList);
        Assert.AreEqual(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
            CollectionAssert.AreEqual(expected[i], result[i]);
    }
}
