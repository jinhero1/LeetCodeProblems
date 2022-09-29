namespace RansomNote
{
    // Runtime: 81 ms, faster than 96.90% of C# online submissions for Ransom Note.
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
}
