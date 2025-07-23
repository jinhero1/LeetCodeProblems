using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using SortList;

public class TestSortList
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                (object)new int[] { 4, 2, 1, 3 },
                (object)new int[] { 1, 2, 3, 4 }
            );
            // Example 2
            yield return new TestCaseData(
                (object)new int[] { -1, 5, 3, 4, 0 },
                (object)new int[] { -1, 0, 3, 4, 5 }
            );
            // Example 3
            yield return new TestCaseData(
                (object)new int[] { },
                (object)new int[] { }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_SortList(int[] input, int[] expected)
    {
        // arrange
        var head = BuildList(input);
        // act
        var sortedHead = new Solution().SortList(head);
        // assert
        var result = ToArray(sortedHead);
        CollectionAssert.AreEqual(expected, result);
    }

    private ListNode BuildList(int[] arr)
    {
        var dummy = new ListNode(0);
        var curr = dummy;
        foreach (var v in arr)
        {
            curr.next = new ListNode(v);
            curr = curr.next;
        }
        return dummy.next;
    }

    private int[] ToArray(ListNode head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        return list.ToArray();
    }
}
