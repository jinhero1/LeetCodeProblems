using NUnit.Framework;
using System.Collections;
using System.Linq;
using FindCriticaAndPseudoCriticalEdgesInMinimumSpanningTree;

public class TestFindCriticaAndPseudoCriticalEdgesInMinimumSpanningTree
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                5,
                (object)new int[][] {
                    new[] { 0, 1, 1 },
                    new[] { 1, 2, 1 },
                    new[] { 2, 3, 2 },
                    new[] { 0, 3, 2 },
                    new[] { 0, 4, 3 },
                    new[] { 3, 4, 3 },
                    new[] { 1, 4, 6 }
                },
                (object)new int[][] {
                    new[] { 0, 1 },
                    new[] { 2, 3, 4, 5 }
                }
            );

            // Example 2
            yield return new TestCaseData(
                4,
                (object)new int[][] {
                    new[] { 0, 1, 1 },
                    new[] { 1, 2, 1 },
                    new[] { 2, 3, 1 },
                    new[] { 0, 3, 1 }
                },
                (object)new int[][] {
                    new int[] { },
                    new[] { 0, 1, 2, 3 }
                }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_FindCriticalAndPseudoCriticalEdges(int n, int[][] edges, int[][] expected)
    {
        // Act
        var result = new Solution().FindCriticalAndPseudoCriticalEdges(n, edges);
        // Convert IList<IList<int>> to int[][]
        var actual = result.Select(group => group.ToArray()).ToArray();

        // Assert lengths match
        Assert.AreEqual(expected.Length, actual.Length);
        // Assert each subgroup
        for (int i = 0; i < expected.Length; i++)
            CollectionAssert.AreEqual(expected[i], actual[i]);
    }
}
