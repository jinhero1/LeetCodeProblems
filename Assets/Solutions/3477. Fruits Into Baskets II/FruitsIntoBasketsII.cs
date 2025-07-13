namespace FruitsIntoBasketsII
{
    public class Solution
    {
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            byte length = (byte)fruits.Length;
            byte found = 0;
            for (byte i = 0; i < length; i++)
            {
                for (byte j = 0; j < length; j++)
                {
                    if (fruits[i] <= baskets[j])
                    {
                        found++;
                        baskets[j] = 0; // Mark this basket as used
                        break;
                    }
                }
            }
            return length - found;
        }
    }
}