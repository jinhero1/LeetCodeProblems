namespace NimGame
{
    public class Solution
    {
        private const int NUMBER = 4; 

        public bool CanWinNim(int n)
        {
            return n % NUMBER != 0;
        }
    }
}