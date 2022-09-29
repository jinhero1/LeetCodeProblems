using NUnit.Framework;
using PalindromeLinkedList;

public class TestPalindromeLinkedList
{
    [Test]
    [TestCase(new int[] { 1, 2, 2, 1 }, true, TestName = "Example 1")]
    [TestCase(new int[] { 1, 2 }, false, TestName = "Example 2")]
    [TestCase(new int[] { 1, 0, 1 }, true, TestName = "Example 3")]
    [TestCase(new int[] { 1 }, true, TestName = "Example 4")]
    public void Calculate_PalindromeLinkedList(int[] values, bool result)
    {
        ListNode root = SinglyLinkedListUtility.InsertLevelOrder(values, 0);

        Solution solution = new Solution();
        bool output = solution.IsPalindrome(root);

        Assert.AreEqual(result, output);
    }
}
