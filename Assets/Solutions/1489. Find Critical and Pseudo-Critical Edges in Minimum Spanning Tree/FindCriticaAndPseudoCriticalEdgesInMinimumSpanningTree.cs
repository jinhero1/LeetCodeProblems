using System;
using System.Collections.Generic;

namespace FindCriticaAndPseudoCriticalEdgesInMinimumSpanningTree
{
    public class Solution
    {
        const int ROOT = 0;
        int n, m, LOG;
        int[][] aug;                // [u, v, w, originalIndex]
        List<(int to, int w)>[] tree;
        int[] depth;
        int[][] up;
        int[][] maxUp;
        int[] parent, rank, baseParent, baseRank;
        int groupCount;

        public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
        {
            this.n = n;
            m = edges.Length;
            LOG = (int)Math.Ceiling(Math.Log(n) / Math.Log(2)) + 1;

            // 1) augment & sort edges
            aug = new int[m][];
            for (int i = 0; i < m; i++)
                aug[i] = new int[] { edges[i][0], edges[i][1], edges[i][2], i };
            Array.Sort(aug, (a, b) => a[2].CompareTo(b[2]));

            // 2) prepare DSU buffers
            parent = new int[n];
            rank = new int[n];
            baseParent = new int[n];
            baseRank = new int[n];
            for (int i = 0; i < n; i++)
            {
                baseParent[i] = i;
                baseRank[i] = 0;
            }

            // 3) build original MST and record which sorted-edge indices used
            var mstEdges = new List<int>();
            int originalCost = BuildMstAndRecordMstEdges(mstEdges);

            // 4) build MST adjacency for LCA
            BuildTree(mstEdges);

            // 5) preprocess LCA + max-edge on path
            depth = new int[n];
            up = new int[LOG][];
            maxUp = new int[LOG][];
            for (int k = 0; k < LOG; k++)
            {
                up[k] = new int[n];
                maxUp[k] = new int[n];
            }
            Dfs(ROOT, ROOT, 0, 0);
            for (int k = 1; k < LOG; k++)
            {
                for (int v = 0; v < n; v++)
                {
                    int p = up[k - 1][v];
                    up[k][v] = up[k - 1][p];
                    maxUp[k][v] = Math.Max(maxUp[k - 1][v], maxUp[k - 1][p]);
                }
            }

            var critical = new List<int>();
            var pseudo = new List<int>();
            var isCritical = new bool[m];

            // 6) critical: test only MST edges by skipping
            foreach (int ei in mstEdges)
            {
                int costSkip = BuildMst(skipEdge: ei, forceEdge: -1);
                if (costSkip > originalCost)
                {
                    critical.Add(aug[ei][3]);
                    isCritical[ei] = true;
                }
            }

            // 7) pseudo-critical: any non-critical edge whose weight equals max on MST-path
            for (int ei = 0; ei < m; ei++)
            {
                if (isCritical[ei]) continue;
                var e = aug[ei];
                int maxEdgeOnPath = QueryMaxOnPath(e[0], e[1]);
                if (maxEdgeOnPath == e[2])
                {
                    pseudo.Add(e[3]);
                }
            }

            return new List<IList<int>> { critical, pseudo };
        }

        // reset DSU, build MST optionally skipping or forcing one sorted-edge index
        int BuildMst(int skipEdge, int forceEdge)
        {
            Array.Copy(baseParent, parent, n);
            Array.Copy(baseRank, rank, n);
            groupCount = n;
            int cost = 0;
            if (forceEdge >= 0)
            {
                var e = aug[forceEdge];
                if (Union(e[0], e[1])) cost += e[2];
            }
            for (int i = 0; i < m && groupCount > 1; i++)
            {
                if (i == skipEdge) continue;
                var e = aug[i];
                if (Union(e[0], e[1])) cost += e[2];
            }
            return groupCount == 1 ? cost : int.MaxValue;
        }

        // first MST build + record sorted-edge indices used
        int BuildMstAndRecordMstEdges(List<int> mstEdges)
        {
            mstEdges.Clear();
            Array.Copy(baseParent, parent, n);
            Array.Copy(baseRank, rank, n);
            groupCount = n;
            int cost = 0;
            for (int i = 0; i < m; i++)
            {
                var e = aug[i];
                if (Union(e[0], e[1]))
                {
                    cost += e[2];
                    mstEdges.Add(i);
                    if (groupCount == 1) break;
                }
            }
            return cost;
        }

        // build adjacency list of MST for LCA
        void BuildTree(List<int> mstEdges)
        {
            tree = new List<(int to, int w)>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<(int, int)>();
            foreach (int ei in mstEdges)
            {
                var e = aug[ei];
                tree[e[0]].Add((e[1], e[2]));
                tree[e[1]].Add((e[0], e[2]));
            }
        }

        // DFS to set depth, up[0], maxUp[0]
        void Dfs(int v, int p, int w, int d)
        {
            up[0][v] = p;
            maxUp[0][v] = w;
            depth[v] = d;
            foreach (var (to, wt) in tree[v])
            {
                if (to == p) continue;
                Dfs(to, v, wt, d + 1);
            }
        }

        // return max edge weight on path between u and v in MST
        int QueryMaxOnPath(int u, int v)
        {
            if (depth[u] < depth[v]) (u, v) = (v, u);
            int diff = depth[u] - depth[v], ans = 0;
            for (int k = 0; k < LOG; k++)
            {
                if (((diff >> k) & 1) != 0)
                {
                    ans = Math.Max(ans, maxUp[k][u]);
                    u = up[k][u];
                }
            }
            if (u == v) return ans;
            for (int k = LOG - 1; k >= 0; k--)
            {
                if (up[k][u] != up[k][v])
                {
                    ans = Math.Max(ans, Math.Max(maxUp[k][u], maxUp[k][v]));
                    u = up[k][u];
                    v = up[k][v];
                }
            }
            // one step to LCA
            ans = Math.Max(ans, maxUp[0][u]);
            ans = Math.Max(ans, maxUp[0][v]);
            return ans;
        }

        // DSU with path compression + union by rank
        int Find(int x)
        {
            while (parent[x] != x)
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return x;
        }
        bool Union(int x, int y)
        {
            int rx = Find(x), ry = Find(y);
            if (rx == ry) return false;
            if (rank[rx] < rank[ry]) parent[rx] = ry;
            else if (rank[ry] < rank[rx]) parent[ry] = rx;
            else
            {
                parent[ry] = rx;
                rank[rx]++;
            }
            groupCount--;
            return true;
        }
    }
}
