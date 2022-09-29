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