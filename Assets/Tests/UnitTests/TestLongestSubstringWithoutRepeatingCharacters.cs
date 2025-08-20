using NUnit.Framework;
using System.Collections;
using LongestSubstringWithoutRepeatingCharacters;

public class TestLongestSubstringWithoutRepeatingCharacters
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData("abcabcbb").Returns(3);
            yield return new TestCaseData("bbbbb").Returns(1);
            yield return new TestCaseData("pwwkew").Returns(3);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public int Test_LengthOfLongestSubstring(string s)
        => new Solution().LengthOfLongestSubstring(s);
}
