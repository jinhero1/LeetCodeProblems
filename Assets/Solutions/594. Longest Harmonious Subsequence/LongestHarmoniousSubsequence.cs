using System;
using System.Collections.Generic;

namespace LongestHarmoniousSubsequence
{
    public class Solution
    {
        private readonly Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        private int maxLength = 0;
        private int nextNum, nextCount;

        public int FindLHS(int[] nums)
        {
            frequencyMap.Clear();
            // Count the frequency of each number
            foreach (int num in nums)
            {
                if (frequencyMap.TryGetValue(num, out int count)) frequencyMap[num] = count + 1;
                else frequencyMap[num] = 1;
            }

            // Reset maxLength for each new call
            maxLength = 0;
            // Iterate through the frequency map to find the longest harmonious subsequence
            foreach (var kvp in frequencyMap)
            {
                nextNum = kvp.Key + 1;
                // Check if the next consecutive number exists
                if (frequencyMap.ContainsKey(nextNum))
                {
                    nextCount = frequencyMap[nextNum];
                    maxLength = Math.Max(maxLength, kvp.Value + nextCount);
                }
            }
            return maxLength;
        }
    }
}
