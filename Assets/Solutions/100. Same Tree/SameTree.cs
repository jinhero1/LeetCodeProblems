using System.Collections.Generic;

namespace SameTree
{
    // Runtime: 106 ms, faster than 86.85% of C# online submissions for Same Tree
    public class Solution
    {
        private const int ZERO = 0;
        private const int MAX_SIZE = 100;

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> pNodeQueue = new Queue<TreeNode>(MAX_SIZE);
            Queue<TreeNode> qNodeQueue = new Queue<TreeNode>(MAX_SIZE);
            pNodeQueue.Enqueue(p);
            qNodeQueue.Enqueue(q);

            TreeNode pHead = null;
            TreeNode qHead = null;
            while (pNodeQueue.Count > ZERO)
            {
                pHead = pNodeQueue.Dequeue();
                qHead = qNodeQueue.Dequeue();
                if (!IsSameValue(pHead, qHead)) return false;

                if (pHead == null)
                {
                    continue;
                }

                pNodeQueue.Enqueue(pHead.left);
                qNodeQueue.Enqueue(qHead.left);

                pNodeQueue.Enqueue(pHead.right);
                qNodeQueue.Enqueue(qHead.right);
            }

            return true;
        }

        private bool IsSameValue(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;

            return true;
        }
    }
}

