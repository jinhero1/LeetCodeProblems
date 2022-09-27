using System.Collections.Generic;
using UnityEngine;

namespace TheKWeakestRowsinaMatrix
{
    internal class Solution
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

    public class TheKWeakestRowsinaMatrix : MonoBehaviour
    {
        void Start()
        {
            /*
            int[][] mat = new int[][]
            {
                new int[] { 1,1,0,0,0 },
                new int[] { 1,1,1,1,0 },
                new int[] { 1,0,0,0,0 },
                new int[] { 1,1,0,0,0 },
                new int[] { 1,1,1,1,1 }
            };
            int k = 3;
            */
            /*
            int[][] mat = new int[][]
            {
                new int[] { 1,0,0,0 },
                new int[] { 1,1,1,1 },
                new int[] { 1,0,0,0 },
                new int[] { 1,0,0,0 },
            };
            int k = 2;
            */
            int[][] mat = new int[][]
            {
                new int[] { 1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 },
                new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            int k = 17;
            Solution solution = new Solution();
            int[] output = solution.KWeakestRows(mat, k);
            DebugUtility.Log(output);
        }
    }
}