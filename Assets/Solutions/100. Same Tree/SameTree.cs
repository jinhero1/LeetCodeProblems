using System.Collections.Generic;
using UnityEngine;

namespace SameTree
{
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

    public class SameTree : MonoBehaviour
    {
        void Start()
        {
            //int?[] pValues = new int?[] { 1, 1 };
            //int?[] qValues = new int?[] { 1, null, 1 };
            //int?[] pValues = new int?[] { 1, 2, 3 };
            //int?[] qValues = new int?[] { 1, 2, 3 };
            int?[] pValues = new int?[] { 1, 2, 1 };
            int?[] qValues = new int?[] { 1, 1, 2 };
            TreeNode p = BinaryTreeUtility.InsertLevelOrder(pValues, 0);
            TreeNode q = BinaryTreeUtility.InsertLevelOrder(qValues, 0);

            Solution solution = new Solution();
            bool output = solution.IsSameTree(p, q);
            Debug.Log($"Output: {output}");
        }
    }
}

