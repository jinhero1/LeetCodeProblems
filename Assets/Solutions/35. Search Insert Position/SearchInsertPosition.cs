using UnityEngine;

namespace SearchInsertPosition
{
    public class Solution
    {
        private const int NOT_FOUND = -1;

        public int SearchInsert(int[] nums, int target)
        {
            int lowerBound = 0;
            int upperBound = nums.Length - 1;
            int middleIndex;
            int middleValue;

            while (lowerBound <= upperBound)
            {
                middleIndex = (lowerBound + upperBound) / 2;
                middleValue = nums[middleIndex];

                if (target == middleValue)
                {
                    return middleIndex;
                }
                if (target < nums[lowerBound])
                {
                    return lowerBound;
                }
                if (target > nums[upperBound])
                {
                    return upperBound + 1;
                }

                if (target < middleValue)
                {
                    upperBound = middleIndex - 1;
                    continue;
                }

                if (target > middleValue)
                {
                    lowerBound = middleIndex + 1;
                    continue;
                }
            }

            return NOT_FOUND;
        }
    }

    public class SearchInsertPosition : MonoBehaviour
    {
        void Start()
        {
            int[] nums = { 1, 3, 5, 6 };
            //int target = 5;
            //int target = 2;
            int target = 4;
            //int target = 7;

            Solution solution = new Solution();
            int output = solution.SearchInsert(nums, target);
            Debug.Log($"Output: {output}");
        }
    }
}