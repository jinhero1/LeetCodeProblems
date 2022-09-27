using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

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
            nodeQueue.Enqueue(head.left);
            nodeQueue.Enqueue(head.right);

            output.Add(head.val);
        }

        return output;
    }
}
