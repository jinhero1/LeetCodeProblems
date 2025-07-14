using NUnit.Framework;
using System.Collections;
using LongestCommonPrefix;

public class TestLongestCommonPrefix
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData((object)new string[] { "flower", "flow", "flight" }).Returns("fl");
            yield return new TestCaseData((object)new string[] { "dog", "racecar", "car" }).Returns("");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public string Test_LongestCommonPrefix(string[] strs)
        => new Solution().LongestCommonPrefix(strs);
}
