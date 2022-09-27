using UnityEngine;

namespace FindtheTownJudge
{
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

    public class FindtheTownJudge : MonoBehaviour
    {
        private void Start()
        {
            int n = 1;
            int[][] trust = new int[][]
            {
            };
            /*
            int n = 2;
            int[][] trust = new int[][]
            {
                new int[] { 1,2 },
            };
            */
            /*
            int n = 3;
            int[][] trust = new int[][]
            {
                new int[] { 1,3 },
                new int[] { 2,3 },
            };
            */
            /*
            int n = 3;
            int[][] trust = new int[][]
            {
                new int[] { 1,2 },
                new int[] { 2,3 },
            };
            */
            /*
            int n = 3;
            int[][] trust = new int[][]
            {
                new int[] { 1,3 },
                new int[] { 2,3 },
                new int[] { 3,1 },
            };
            */
            /*
            int n = 4;
            int[][] trust = new int[][]
            {
                new int[] { 1,3 },
                new int[] { 1,4 },
                new int[] { 2,3 },
                new int[] { 2,4 },
                new int[] { 4,3 },
            };
            */
            Solution solution = new Solution();
            int output = solution.FindJudge(n, trust);
            Debug.Log($"Output: {output}");
        }
    }
}