namespace MinimumPairRemovalToSortArrayI
{
    public class Solution
    {
        public int MinimumPairRemoval(int[] nums)
        {
            byte length = (byte)nums.Length;
            byte operations = 0;
            byte mergeIndex = 0;
            while (IsDecreasing(nums, length))
            {
                mergeIndex = FindMinimumSumPairIndex(nums, length);
                if (mergeIndex != byte.MaxValue)
                {
                    MergeAndShrink(nums, mergeIndex, ref length);
                    operations++;
                }
            }
            return operations;
        }

        private bool IsDecreasing(int[] nums, byte length)
        {
            byte nextIndex = 0;
            for (byte i = 0; i < length - 1; i++)
            {
                nextIndex = (byte)(i + 1);
                if (nextIndex >= length)
                {
                    break;
                }
                if (nums[i] > nums[nextIndex])
                {
                    return true;
                }
            }
            return false;
        }

        private byte FindMinimumSumPairIndex(int[] nums, byte length)
        {
            byte previousIndex = 0;
            byte minimumSumIndex = byte.MaxValue;
            int numsSum = 0;
            int minimumSum = int.MaxValue;
            for (byte i = (byte)(length - 1); i >= 0; i--)
            {
                if (i <= 0)
                {
                    break;
                }
                previousIndex = (byte)(i - 1);
                numsSum = nums[i] + nums[previousIndex];
                if (numsSum <= minimumSum)
                {
                    minimumSum = numsSum;
                    minimumSumIndex = previousIndex;
                }
            }

            return minimumSumIndex;
        }

        private void MergeAndShrink(int[] nums, int mergeIndex, ref byte length)
        {
            nums[mergeIndex] = nums[mergeIndex] + nums[mergeIndex + 1];
            for (int j = mergeIndex + 1; j < length - 1; j++)
            {
                nums[j] = nums[j + 1];
            }
            length--;
        }
    }
}
