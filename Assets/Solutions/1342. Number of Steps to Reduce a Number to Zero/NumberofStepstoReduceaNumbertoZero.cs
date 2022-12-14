namespace NumberofStepstoReduceaNumbertoZero
{
    #region RuntimeFastest
    // Runtime: 27 ms, faster than 81.46% of C# online submissions for Number of Steps to Reduce a Number to Zero
    /*
    public class Solution
    {
        private const int BITS = 32;
        private const int SHIFTING_PLACE = 1;

        // DotNet -> BitOperations.cs 
        // https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Numerics/BitOperations.cs

        public int NumberOfSteps(int num)
        {
            // Dividing by 2 is shifting the bits 1 place to the right.
            // Subtracting 1 from an odd number is flipping the right-most bit from 1 to 0.

            return BITS - BitOperations.LeadingZeroCount((uint)num >> SHIFTING_PLACE)
              + BitOperations.PopCount((uint)num);
        }
    }
    */
    #endregion
    #region General
    public class Solution
    {
        private const int ZERO = 0;
        private const int TWO = 2;

        public int NumberOfSteps(int num)
        {
            int steps = ZERO;

            while (num > ZERO)
            {
                steps++;

                if (num % TWO == ZERO)
                {
                    num /= TWO;
                    continue;
                }

                num--;
            }

            return steps;
        }
    }
    #endregion
}