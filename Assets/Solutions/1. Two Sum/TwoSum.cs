using System.Collections.Generic;
using UnityEngine;

namespace TwoSum
{
    public class Solution
    {
        #region MemoryMinimization
        /*
        public int[] TwoSum(int[] nums, int target)
        {
            int[] indexes = null;
            for (int i = 0; i < nums.Length; i++)
            {
                indexes = FindIndexes(nums, target, i);
                if (indexes != null)
                {
                    break;
                }
            }

            return indexes;
        }

        private int[] FindIndexes(int[] nums, int target, int start)
        {
            for (int i = start + 1; i < nums.Length; i++)
            {
                if (nums[start] + nums[i] == target)
                {
                    return new int[] { start, i };
                }
            }

            return null;
        }
        */
        #endregion
        #region RuntimeFastest
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (pairs.ContainsKey(diff))
                {
                    return new int[] { pairs[diff], i };
                }

                pairs[nums[i]] = i;
            }

            return null;
        }
        #endregion
    }

    public class TwoSum : MonoBehaviour
    {
        void Start()
        {
            Solution solution = new Solution();
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 9;
            //int[] nums = new int[] { 3, 2, 3 };
            //int target = 6;
            //int[] nums = new int[] { 3, 3 };
            //int target = 6;
            int[] nums = new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 };
            int target = 11;
            int[] output = solution.TwoSum(nums, target);
            DebugUtility.Log(output);
        }
    }
}