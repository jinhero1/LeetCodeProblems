using NUnit.Framework;
using System.Collections;
using LongestDuplicateSubstring;

public class TestLongestDuplicateSubstring
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData("banana").Returns("ana");
            yield return new TestCaseData("abcd").Returns("");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public string Test_LongestDupSubstring(string s)
        => new Solution().LongestDupSubstring(s);
}
