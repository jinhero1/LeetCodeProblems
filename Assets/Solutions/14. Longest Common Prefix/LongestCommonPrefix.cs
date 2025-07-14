using System.Text;

namespace LongestCommonPrefix
{
    public class Solution
    {
        private readonly StringBuilder result = new();
        public string LongestCommonPrefix(string[] strs)
        {
            byte characterLength = (byte)strs[0].Length;
            for (byte characterIndex = 0; characterIndex < characterLength; characterIndex++)
            {
                char? commonCharacter = FindCommonCharacter(strs, characterIndex);
                if (commonCharacter == null)
                {
                    break;
                }

                result.Append(commonCharacter);
            }

            return result.ToString();
        }

        private char? FindCommonCharacter(string[] strs, byte characterIndex)
        {
            byte length = (byte)strs.Length;
            byte nextIndex = 0;
            for (byte i = 0; i < length; i++)
            {
                nextIndex = (byte)(i + 1);
                if (nextIndex >= length)
                {
                    break;
                }

                if (characterIndex >= strs[i].Length || characterIndex >= strs[nextIndex].Length)
                {
                    return null;
                }

                if (strs[i][characterIndex] != strs[nextIndex][characterIndex])
                {
                    return null;
                }
            }

            return strs[0][characterIndex];
        }
    }
}
