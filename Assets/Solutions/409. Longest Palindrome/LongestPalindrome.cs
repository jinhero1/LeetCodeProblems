using UnityEngine;

namespace LongestPalindrome
{
    public class Solution
    {
        private const int ONE = 1;
        private const int TWO = 2;
        private const char UPPER_CASE_A = 'A';

        public int LongestPalindrome(string s)
        {
            int[] letterCounts = new int[58];

            for (int i = 0; i < s.Length; i++)
            {
                letterCounts[s[i] - UPPER_CASE_A]++;
            }

            int lengthCount = 0;
            int _charCount = 0;
            bool _hasOddChecked = false;
            for (int i = 0; i < letterCounts.Length; i++)
            {
                _charCount = letterCounts[i];
                if (_charCount == 0) continue;

                if (_charCount % TWO == 0)
                {
                    lengthCount += _charCount;
                }
                // count odd as the even 
                else
                {
                    lengthCount += _charCount - ONE;
                    _hasOddChecked = true;
                }
            }

            if (_hasOddChecked) lengthCount++;

            return lengthCount;
        }
    }

    public class LongestPalindrome : MonoBehaviour
    {
        void Start()
        {
            Solution solution = new Solution();
            //int output = solution.LongestPalindrome("abccccdd");
            //int output = solution.LongestPalindrome("a");
            //int output = solution.LongestPalindrome("ccc"); // 3
            //int output = solution.LongestPalindrome("bananas"); // 5 (anana)
            // 983
            int output = solution.LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth");
            Debug.Log(output);
        }
    }
}