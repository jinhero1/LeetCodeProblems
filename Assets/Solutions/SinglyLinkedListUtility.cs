using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class SinglyLinkedListUtility
{
    public static ListNode InsertLevelOrder(int[] arr, int i)
    {
        ListNode root = null;

        if (i < arr.Length)
        {
            root = new ListNode(arr[i]);

            root.next = InsertLevelOrder(arr, i + 1);
        }

        return root;
    }
}