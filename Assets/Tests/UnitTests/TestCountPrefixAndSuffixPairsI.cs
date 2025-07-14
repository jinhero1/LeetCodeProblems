using NUnit.Framework;
using System.Collections;
using CountPrefixAndSuffixPairsI;

public class TestCountPrefixAndSuffixPairsI
{
    public static IEnumerable PrefixSuffixTestCases
    {
        get
        {
            yield return new TestCaseData((object)new string[] { "a", "aba", "ababa", "aa" }).Returns(4);
            yield return new TestCaseData((object)new string[] { "pa", "papa", "ma", "mama" }).Returns(2);
            yield return new TestCaseData((object)new string[] { "abab", "ab" }).Returns(0);
        }
    }

    [TestCaseSource(nameof(PrefixSuffixTestCases))]
    public int Test_CountPrefixSuffixPairs(string[] words)
        => new Solution().CountPrefixSuffixPairs(words);
}
