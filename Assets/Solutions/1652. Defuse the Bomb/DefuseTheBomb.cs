namespace DefuseTheBomb
{
    public class Solution
    {
        public int[] Decrypt(int[] code, int k)
        {
            int n = code.Length;
            var ans = new int[n];
            if (k == 0) return ans; // all zeros

            int doubleLength = 2 * n;
            // duplicate code to handle wrap-around
            int[] ext = new int[doubleLength];
            for (int i = 0; i < doubleLength; i++) ext[i] = code[i % n];

            // prefix sums on ext: ps[t] = sum of ext[0..t-1]
            int[] ps = new int[doubleLength + 1];
            for (int i = 0; i < doubleLength; i++) ps[i + 1] = ps[i] + ext[i];

            if (k > 0)
            {
                int next;
                for (int i = 0; i < n; i++)
                {
                    next = i + 1;
                    ans[i] = ps[next + k] - ps[next];
                }
            }
            else
            {
                int extIndex;
                for (int i = 0; i < n; i++)
                {
                    extIndex = i + n;
                    ans[i] = ps[extIndex] - ps[extIndex + k];
                }
            }
            return ans;
        }
    }
}
