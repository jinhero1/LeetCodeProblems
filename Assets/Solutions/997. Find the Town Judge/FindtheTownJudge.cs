namespace FindtheTownJudge
{
    // Runtime: 352 ms, faster than 68.59% of C# online submissions for Find the Town Judge.
    // Memory Usage: 47.2 MB, less than 98.72% of C# online submissions for Find the Town Judge.
    public class Solution
    {
        private const int NOT_FOUND = -1;
        private const int ZERO = 0;
        private const int ONE = 1;

        public int FindJudge(int n, int[][] trust)
        {
            if (n == ONE)
            {
                return n;
            }

            int allowedTrustedCount = n - 1;

            int[] trustPersonCount = new int[n + 1];
            int[] beTrustedCount = new int[n + 1];
            int _beTrustedLabel = 0;
            int _currentTrustedCount = 0;
            int _maxTrustedCount = 0;
            int townJudge = NOT_FOUND;
            for (int i = 0; i < trust.Length; i++)
            {
                trustPersonCount[trust[i][0]]++;

                _beTrustedLabel = trust[i][1];
                beTrustedCount[_beTrustedLabel]++;

                _currentTrustedCount = beTrustedCount[_beTrustedLabel];
                if (_currentTrustedCount > _maxTrustedCount)
                {
                    _maxTrustedCount = _currentTrustedCount;
                    townJudge = _beTrustedLabel;
                }
            }

            if (_maxTrustedCount == allowedTrustedCount &&
                (townJudge > ZERO && trustPersonCount[townJudge] == ZERO))
            {
                return townJudge;
            }

            return NOT_FOUND;
        }
    }
}