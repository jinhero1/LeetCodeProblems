using System;

namespace LongestDuplicateSubstring
{
    public class Solution
    {
        private const char A = 'a';
        public string LongestDupSubstring(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2) return string.Empty;

            var sam = new SuffixAutomaton(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                int c = s[i] - A;          // assumes 'a'..'z'
                sam.Extend(c, i);
            }

            // propagate occurrences by length descending (counting sort by len)
            sam.PropagateOccurrences();

            // find the state with max len and occ >= 2
            int bestLen = 0, bestEnd = -1;
            for (int v = 1; v < sam.Size; v++)
            { // skip root(0)
                if (sam.Occ[v] >= 2 && sam.Len[v] > bestLen)
                {
                    bestLen = sam.Len[v];
                    bestEnd = sam.FirstPos[v];
                }
            }

            return bestLen == 0 ? string.Empty : s.Substring(bestEnd - bestLen + 1, bestLen);
        }

        // ---------- Suffix Automaton ----------
        private sealed class SuffixAutomaton
        {
            private const int ALPH = 26;

            // transitions: Next[state][ch] = toState (or -1)
            public int[][] Next;
            // suffix link
            public int[] Link;
            // longest length of this state
            public int[] Len;
            // first end position for this state in the original string
            public int[] FirstPos;
            // occurrence count (endpos size), to be propagated
            public int[] Occ;

            public int Last;     // last state (active end)
            public int Size;     // number of states used

            public SuffixAutomaton(int n)
            {
                // SAM needs up to 2*n states
                int cap = 2 * n;
                Next = new int[cap][];
                Link = new int[cap];
                Len = new int[cap];
                FirstPos = new int[cap];
                Occ = new int[cap];

                // init root state 0
                Next[0] = NewRow();
                Link[0] = -1;
                Len[0] = 0;
                FirstPos[0] = -1;
                Occ[0] = 0;

                Last = 0;
                Size = 1;
            }

            // add character c at position pos
            public void Extend(int c, int pos)
            {
                int cur = Size++;
                Next[cur] = NewRow();
                Len[cur] = Len[Last] + 1;
                FirstPos[cur] = pos;
                Occ[cur] = 1; // each new terminal contributes once

                int p = Last;
                while (p != -1 && Next[p][c] == -1)
                {
                    Next[p][c] = cur;
                    p = Link[p];
                }

                if (p == -1)
                {
                    Link[cur] = 0;   // directly attach to root
                }
                else
                {
                    int q = Next[p][c];
                    if (Len[p] + 1 == Len[q])
                    {
                        Link[cur] = q;   // fine, no clone needed
                    }
                    else
                    {
                        // create clone state
                        int clone = Size++;
                        Next[clone] = CopyRow(Next[q]);
                        Len[clone] = Len[p] + 1;
                        Link[clone] = Link[q];
                        FirstPos[clone] = FirstPos[q];
                        Occ[clone] = 0;  // clone doesn't add new occurrences

                        // redirect transitions pointing to q → clone
                        while (p != -1 && Next[p][c] == q)
                        {
                            Next[p][c] = clone;
                            p = Link[p];
                        }
                        Link[q] = Link[cur] = clone;
                    }
                }
                Last = cur;
            }

            // propagate Occ from longer states to their suffix links (length-desc order)
            public void PropagateOccurrences()
            {
                // counting sort by Len
                int maxLen = 0;
                for (int i = 0; i < Size; i++) if (Len[i] > maxLen) maxLen = Len[i];
                int[] cnt = new int[maxLen + 1];
                for (int i = 0; i < Size; i++) cnt[Len[i]]++;
                for (int i = 1; i <= maxLen; i++) cnt[i] += cnt[i - 1];

                int[] order = new int[Size];
                for (int i = Size - 1; i >= 0; i--) order[--cnt[Len[i]]] = i;

                // traverse from longest to shortest
                for (int i = Size - 1; i > 0; i--)
                {
                    int v = order[i];
                    int p = Link[v];
                    if (p >= 0) Occ[p] += Occ[v];
                }
            }

            private static int[] NewRow()
            {
                var row = new int[ALPH];
                for (int i = 0; i < ALPH; i++) row[i] = -1;
                return row;
            }

            private static int[] CopyRow(int[] src)
            {
                var dst = new int[ALPH];
                Array.Copy(src, dst, ALPH);
                return dst;
            }
        }
    }
}
