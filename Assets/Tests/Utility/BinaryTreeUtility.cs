using System.Collections.Generic;

public class BinaryTreeUtility
{
    private const int ZERO = 0;

    public static TreeNode InsertLevelOrder(int?[] arr, int i)
    {
        TreeNode root = null;

        if (i < arr.Length && arr[i] != null)
        {
            root = new TreeNode(arr[i].Value);

            // insert left child
            root.left = InsertLevelOrder(arr, 2 * i + 1);

            // insert right child
            root.right = InsertLevelOrder(arr, 2 * i + 2);
        }

        return root;
    }

    public static IList<int?> BreadthTraversal(TreeNode root)
    {
        List<int?> output = new List<int?>();
        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);

        TreeNode head = null;
        while (nodeQueue.Count > ZERO)
        {
            head = nodeQueue.Dequeue();
            if (head == null)
            {
                output.Add(null);
                continue;
            }
            // No subtree
            if (head.left == null && head.right == null)
            {
                output.Add(head.val);
                continue;
            }

            nodeQueue.Enqueue(head.left);
            nodeQueue.Enqueue(head.right);

            output.Add(head.val);
        }

        return output;
    }
}
