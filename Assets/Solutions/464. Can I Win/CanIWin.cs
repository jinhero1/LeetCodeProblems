namespace CanIWin
{
    public class Solution
    {
        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            // quick check: sum of 1..max < desiredTotal → cannot win
            int maxSum = maxChoosableInteger * (maxChoosableInteger + 1) / 2;
            if (maxSum < desiredTotal)
                return false;
            // quick win: desiredTotal ≤ any single pick
            if (desiredTotal <= maxChoosableInteger)
                return true;

            // prepare memo array: 0 = unknown, 1 = win, -1 = lose
            int states = 1 << maxChoosableInteger;
            var memo = new sbyte[states];

            // start DFS from empty mask, full remaining total
            return Dfs(0, desiredTotal, maxChoosableInteger, memo);
        }

        // Returns true if current player can force a win from this state
        private bool Dfs(int usedMask, int remaining, int maxNum, sbyte[] memo)
        {
            // return cached result if available
            if (memo[usedMask] != 0)
                return memo[usedMask] == 1;

            // try each unused number i (e.g., 1 to 10)
            for (int i = 1; i <= maxNum; i++)
            {
                int bit = 1 << (i - 1);
                if ((usedMask & bit) != 0)
                    continue;                // already taken

                // if picking i reaches target, win immediately
                if (i >= remaining)
                {
                    memo[usedMask] = 1;
                    return true;
                }

                // otherwise, if opponent loses thereafter, current wins
                if (!Dfs(usedMask | bit, remaining - i, maxNum, memo))
                {
                    memo[usedMask] = 1;
                    return true;
                }
            }

            // no winning move → current loses
            memo[usedMask] = -1;
            return false;
        }
    }
}
