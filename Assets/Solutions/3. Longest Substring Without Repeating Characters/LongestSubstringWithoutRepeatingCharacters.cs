namespace LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            // last index for each ASCII char, -1 means unseen
            int[] last = new int[128];
            for (int i = 0; i < last.Length; i++) last[i] = -1;

            int left = 0, best = 0;
            for (int right = 0; right < s.Length; right++)
            {
                int ci = s[right];                 // ASCII code (0..127)
                int prev = last[ci];
                if (prev >= left) left = prev + 1; // shrink window if repeated
                last[ci] = right;                  // update last seen index
                int len = right - left + 1;
                if (len > best) best = len;
            }
            return best;
        }
    }
}
