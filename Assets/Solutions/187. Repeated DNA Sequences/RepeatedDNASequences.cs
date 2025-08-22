using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RepeatedDNASequences
{
    public class Solution
    {
        private const int L = 10;                                   // fixed window length
        private const int BITS_PER_BASE = 2;                        // A/C/G/T -> 2 bits. A = 00,  C = 01,  G = 10,  T = 11
        private const int KEY_BITS = BITS_PER_BASE * L;             // 20 bits for 10 bases
        private const int KEY_MASK = (1 << KEY_BITS) - 1;           // keep last 20 bits
        private const int WORD_SHIFT = 5;                           // log2(32) for uint
        private const int WORDS_LEN = 1 << (KEY_BITS - WORD_SHIFT); // 2^(20-5) = 2^15
        private const int WORD_MASK = 31;
        private const char A = 'A';                                 // DNA characters
        private const char C = 'C';
        private const char G = 'G';
        private const char T = 'T';

        private static readonly byte[] LUT = InitLut();
        private static byte[] InitLut()
        {
            var t = new byte[26];          // default 0 everywhere
            t[A - A] = 0;
            t[C - A] = 1;
            t[G - A] = 2;
            t[T - A] = 3;
            return t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Map(char c) => LUT[c - A];

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            int n = s.Length;
            var ans = new List<string>();
            if (n <= L) return ans;

            int code = 0;

            // Build first 10-letter window
            for (int i = 0; i < L; i++) code = (code << BITS_PER_BASE) | Map(s[i]);

            // Bitsets holding 2^20 flags: 2^20 bits / 32 = 32768 uints
            var seen = new uint[WORDS_LEN];
            var added = new uint[WORDS_LEN];

            // Mark first window as seen
            seen[code >> WORD_SHIFT] |= 1u << (code & WORD_MASK);

            // Slide window
            for (int i = L; i < n; i++)
            {
                code = ((code << BITS_PER_BASE) | Map(s[i])) & KEY_MASK;    // Keep last 20 bits (length 10)

                int word = code >> WORD_SHIFT;                              // code / 32
                uint bit = 1u << (code & WORD_MASK);                        // code % 32

                if ((seen[word] & bit) != 0)                                // If already seen
                {
                    if ((added[word] & bit) == 0)
                    {
                        added[word] |= bit;
                        // Substring alloc only when we discover a *new* duplicate
                        ans.Add(s.Substring(i - L + 1, L));
                    }
                }
                else
                {
                    seen[word] |= bit;
                }
            }
            return ans;
        }
    }
}
