using System;

namespace MinCosToConnectAllPoints
{
    public class Solution
    {
        private short n, u;
        private bool[] used;
        private int[] dist;
        private int result, cost;

        public int MinCostConnectPoints(int[][] points)
        {
            n = (short)points.Length;
            // used[i] indicates whether point i is included in the MST
            used = new bool[n];
            // dist[i] stores the minimum cost to connect point i to the current MST
            dist = new int[n];

            // initialize all distances to infinity, except start from point 0
            dist[0] = 0;
            for (short i = 1; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }            

            result = 0;
            // repeat until all points are added to the MST
            for (short iter = 0; iter < n; iter++)
            {
                // find the unused point with the smallest connection cost
                u = -1;
                for (short i = 0; i < n; i++)
                {
                    if (!used[i] && (u == -1 || dist[i] < dist[u]))
                    {
                        u = i;
                    }
                }

                // add point u to the MST
                used[u] = true;
                result += dist[u];

                // update the connection cost for all remaining points
                for (short v = 0; v < n; v++)
                {
                    if (!used[v])
                    {
                        // compute Manhattan distance between u and v
                        cost = Math.Abs(points[u][0] - points[v][0])
                                 + Math.Abs(points[u][1] - points[v][1]);
                        // if this edge offers a cheaper connection, update dist[v]
                        if (cost < dist[v])
                        {
                            dist[v] = cost;
                        }
                    }
                }
            }

            return result;
        }
    }
}
