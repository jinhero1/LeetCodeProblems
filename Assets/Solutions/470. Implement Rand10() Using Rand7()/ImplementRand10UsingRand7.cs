using System;

namespace ImplementRand10UsingRand7
{
    public class SolBase
    {
        private Random _rand = new();

        public int Rand7()
        {
            return _rand.Next(1, 8);
        }
    }

    public class Solution : SolBase
    {
        private const int MaxAcceptable = 40;
        private const int Rand10Max = 10;
        private const int Rand7Max = 7;
        private const int One = 1;

        public int Rand10()
        {
            // The expected number of total iterations (tries) is 49/40 = 1.225
            while (true)
            {
                int x = (Rand7() - One) * Rand7Max + Rand7();  // (0,7,14,...,42) + (1,2,3,...,7) = (1,...,49)
                if (x <= MaxAcceptable) 
                    return (x - One) % Rand10Max + One; // (1,2,...,40) -> (1,2,...,10)
                // else retry (41,...,49)
            }
        }
    }
}
