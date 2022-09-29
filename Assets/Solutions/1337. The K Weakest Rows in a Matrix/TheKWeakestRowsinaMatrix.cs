using System.Collections.Generic;

namespace TheKWeakestRowsinaMatrix
{
    // Runtime: 160 ms, faster than 94.51% of C# online submissions for The K Weakest Rows in a Matrix.
    public class Solution
    {
        private int MAX_MAT_LENGTH = 100;

        public int[] KWeakestRows(int[][] mat, int k)
        {
            List<int> _sortedList = new List<int>();

            int _soldiers = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                Accumulate(mat[i], ref _soldiers);
                _sortedList.Add(_soldiers * MAX_MAT_LENGTH + i);
            }

            _sortedList.Sort();

            int[] results = new int[k];
            for (int i = 0; i < k; i++)
            {
                results[i] = _sortedList[i] % MAX_MAT_LENGTH;
            }

            return results;
        }

        private void Accumulate(int[] values, ref int _rSoldiers)
        {
            _rSoldiers = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 1)
                {
                    _rSoldiers++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}