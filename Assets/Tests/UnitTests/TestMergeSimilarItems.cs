using NUnit.Framework;
using MergeSimilarItems;
using System.Collections.Generic;

public class TestMergeSimilarItems
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new int[][] {
                new int[] { 1, 1 },
                new int[] { 4, 5 },
                new int[] { 3, 8 } }, new int[][] {
                    new int[] { 3, 1 },
                    new int[] { 1, 5 } }, new List<List<int>> {
                        new List<int> { 1, 6 },
                        new List<int> { 3, 9 },
                        new List<int> { 4, 5 } })
                .SetName("Example 1");

            yield return new TestCaseData(new int[][] {
                new int[] { 1, 1 },
                new int[] { 3, 2 },
                new int[] { 2, 3 } }, new int[][] {
                    new int[] { 2, 1 },
                    new int[] { 3, 2 },
                    new int[] { 1, 3 }}, new List<List<int>> {
                        new List<int> { 1, 4 },
                        new List<int> { 2, 4 },
                        new List<int> { 3, 4 } })
                .SetName("Example 2");

            yield return new TestCaseData(new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 2 } }, new int[][] {
                    new int[] { 7, 1 },
                    new int[] { 2, 2 },
                    new int[] { 1, 4 }}, new List<List<int>> {
                        new List<int> { 1, 7 },
                        new List<int> { 2, 4 },
                        new List<int> { 7, 1 } })
                .SetName("Example 3");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_MergeSimilarItems(int[][] items1, int[][] item2, List<List<int>> result)
    {
        Solution solution = new Solution();
        IList<IList<int>> output = solution.MergeSimilarItems(items1, item2);

        CollectionAssert.AreEqual(result, output);
    }
}
