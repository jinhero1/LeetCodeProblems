using NUnit.Framework;
using RansomNote;

public class TestRansomNote
{
    [Test]
    [TestCase("a", "b", false)]
    [TestCase("aa", "ab", false)]
    [TestCase("aa", "aab", true)]
    [TestCase("aab", "baa", true)]
    [TestCase("fffbfg", "effjfggbffjdgbjjhhdegh", true)]
    public void Calculate_RansomNote(string ransomNote, string magazine, bool result)
    {
        Solution solution = new Solution();
        bool output = solution.CanConstruct(ransomNote, magazine);

        Assert.AreEqual(result, output);
    }
}
