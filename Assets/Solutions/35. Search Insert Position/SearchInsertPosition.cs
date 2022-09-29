namespace SearchInsertPosition
{
    // Memory Usage: 37.6 MB, less than 86.14% of C# online submissions for Search Insert Position.
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
}