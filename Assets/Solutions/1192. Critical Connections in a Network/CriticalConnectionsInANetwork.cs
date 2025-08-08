using System;
using System.Collections.Generic;

namespace CriticalConnectionsInANetwork
{
    public class Solution
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            // build undirected graph
            var g = new List<int>[n];
            for (int i = 0; i < n; i++) g[i] = new List<int>();
            foreach (var e in connections)
            {
                int u = e[0], v = e[1];
                g[u].Add(v);
                g[v].Add(u);
            }

            var res = new List<IList<int>>();
            var disc = new int[n];         // discovery time; 0 means unvisited
            var low = new int[n];         // low-link value
            int time = 0;

            void Dfs(int u, int parent)
            {
                disc[u] = low[u] = ++time;
                foreach (int v in g[u])
                {
                    if (v == parent) continue;            // skip the edge back to parent
                    if (disc[v] == 0)                   // tree edge
                    {
                        Dfs(v, u);
                        low[u] = Math.Min(low[u], low[v]);
                        if (low[v] > disc[u])           // u-v is a bridge
                        {
                            res.Add(new int[] { Math.Min(u, v), Math.Max(u, v) });
                        }
                    }
                    else                                // back edge
                    {                              
                        low[u] = Math.Min(low[u], disc[v]);
                    }
                }
            }

            // graph may be connected already, but run from all just in case
            for (int i = 0; i < n; i++) if (disc[i] == 0) Dfs(i, -1);

            return res;
        }
    }
}
