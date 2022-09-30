using System.Collections.Generic;
using System.Text;

namespace BinaryTreePaths
{
    public class Solution
    {
        private const int ZERO = 0;
        private readonly StringBuilder stringBuilder = new StringBuilder();
        private const string PATH_TO = "->";

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> output = new List<string>();
            Stack<(TreeNode, string)> callStack = new Stack<(TreeNode, string)>();
            callStack.Push((root, root.val.ToString()));

            (TreeNode, string) _headTuple;
            TreeNode _head;
            TreeNode _pointer;
            while (callStack.Count > ZERO)
            {
                _headTuple = callStack.Pop();
                _head = _headTuple.Item1;

                if (_head.left == null && _head.right == null)
                {
                    output.Add(_headTuple.Item2);
                    continue;
                }

                _pointer = _head.right;
                if (_pointer != null)
                {
                    callStack.Push((_pointer, ToPath(ref _headTuple.Item2, _pointer)));
                }

                _pointer = _head.left;
                if (_pointer != null)
                {
                    callStack.Push((_pointer, ToPath(ref _headTuple.Item2, _pointer)));
                }
            }

            return output;
        }

        private string ToPath(ref string originalPath, TreeNode node)
        {
            stringBuilder.Length = 0;
            stringBuilder.Append(originalPath);
            stringBuilder.Append(PATH_TO);
            stringBuilder.Append(node.val);

            return stringBuilder.ToString();
        }
    }
}