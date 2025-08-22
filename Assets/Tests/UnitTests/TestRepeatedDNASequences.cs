using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using RepeatedDNASequences;

public class TestRepeatedDNASequences
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(
                "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",
                (object)new List<string> { "AAAAACCCCC", "CCCCCAAAAA" }
            );
            yield return new TestCaseData(
                "AAAAAAAAAAAAA",
                (object)new List<string> { "AAAAAAAAAA" }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_FindRepeatedDnaSequences(string s, IList<string> expected)
    {
        var result = new Solution().FindRepeatedDnaSequences(s);
        // order-agnostic comparison (LeetCode doesn't require specific order)
        CollectionAssert.AreEquivalent(expected, result);
    }
}
