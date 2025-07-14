namespace CountPrefixAndSuffixPairsI
{
    public class Solution
    {
        public int CountPrefixSuffixPairs(string[] words)
        {
            int count = 0;
            byte length = (byte)words.Length;
            for (byte i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (isPrefixAndSuffix(words[i], words[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        
        private bool isPrefixAndSuffix(string str1, string str2)
        {
            byte length1 = (byte)str1.Length;
            byte length2 = (byte)str2.Length;

            if (length1 > length2)
            {
                return false;
            }
            
            char currentChar1;
            for (byte i = 0; i < length1; i++)
            {
                currentChar1 = str1[i];
                // Prefix case
                if (currentChar1 != str2[i])
                {
                    return false;
                }

                // Suffix case
                if (currentChar1 != str2[str2.Length - str1.Length + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}