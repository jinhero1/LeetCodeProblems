using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CriticalConnectionsInANetwork;

public class TestCriticalConnectionsInANetwork
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                4,
                (object)new List<IList<int>>
                {
                    new List<int>{0,1},
                    new List<int>{1,2},
                    new List<int>{2,0},
                    new List<int>{1,3}
                },
                (object)new int[][]
                {
                    new[]{1,3}
                }
            );

            // Example 2
            yield return new TestCaseData(
                2,
                (object)new List<IList<int>>
                {
                    new List<int>{0,1}
                },
                (object)new int[][]
                {
                    new[]{0,1}
                }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_CriticalConnections(int n, IList<IList<int>> connections, int[][] expected)
    {
        var result = new Solution().CriticalConnections(n, connections);
        var actual = result.Select(p => p.ToArray()).ToArray();

        var expectedNorm = Normalize(expected);
        var actualNorm = Normalize(actual);

        Assert.AreEqual(expectedNorm.Length, actualNorm.Length);
        for (int i = 0; i < expectedNorm.Length; i++)
            CollectionAssert.AreEqual(expectedNorm[i], actualNorm[i]);
    }

    private static int[][] Normalize(int[][] pairs)
    {
        // sort each pair, then sort all pairs lexicographically
        foreach (var p in pairs)
        {
            if (p[0] > p[1]) { var t = p[0]; p[0] = p[1]; p[1] = t; }
        }
        return pairs.OrderBy(p => p[0]).ThenBy(p => p[1]).ToArray();
    }
}
