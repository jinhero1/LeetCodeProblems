using UnityEngine;

namespace RansomNote
{
    public class Solution
    {
        private const char A = 'a';

        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] letterCounts = new int[26];
            for (int i = 0; i < magazine.Length; i++)
            {
                letterCounts[magazine[i] - A]++;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (--letterCounts[ransomNote[i] - A] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class RansomNote : MonoBehaviour
    {
        void Start()
        {
            Solution solution = new Solution();
            //bool output = solution.CanConstruct("a", "b");    // false
            //bool output = solution.CanConstruct("aa", "ab");  // false
            bool output = solution.CanConstruct("aa", "aab");   // true
            //bool output = solution.CanConstruct("aab", "baa");  // true
            //bool output = solution.CanConstruct("fffbfg", "effjfggbffjdgbjjhhdegh");  // true
            Debug.Log($"Output: {output}");
        }
    }
}
