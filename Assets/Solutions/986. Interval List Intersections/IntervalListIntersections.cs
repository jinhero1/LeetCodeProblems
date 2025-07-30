using System;
using System.Collections.Generic;

namespace IntervalListIntersections
{
    public class Solution
    {
        private readonly List<int[]> res = new();
        private int i = 0, j = 0;
        private int n, m;
        private int start1, end1, start2, end2;
        private int lo, hi;


        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            res.Clear();
            i = 0;
            j = 0;
            n = firstList.Length;
            m = secondList.Length;

            while (i < n && j < m)
            {
                start1 = firstList[i][0];
                end1 = firstList[i][1];
                start2 = secondList[j][0];
                end2 = secondList[j][1];

                // compute overlap: [lo..hi]
                lo = Math.Max(start1, start2);
                hi = Math.Min(end1, end2);

                // if valid interval, add to result
                if (lo <= hi)
                    res.Add(new int[] { lo, hi });

                // advance the list whose interval ends first
                if (end1 < end2)
                    i++;
                else
                    j++;
            }

            return res.ToArray();
        }
    }
}
