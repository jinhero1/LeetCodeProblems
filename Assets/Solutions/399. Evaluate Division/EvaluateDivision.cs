using System.Collections.Generic;

namespace EvaluateDivision
{
    public class Solution
    {
        private const byte ZERO = 0;
        private const byte ONE = 1;
        private const double ONE_POINT_ZERO = 1.0;
        private const double NOT_FOUND = -1.0;
        // adjacency list: each variable → list of (neighbor, weight)
        private readonly Dictionary<string, List<(string to, double w)>> graph = new();

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            // 1. build graph from equations
            for (int i = 0; i < equations.Count; i++)
            {
                string a = equations[i][ZERO];
                string b = equations[i][ONE];
                double v = values[i];

                AddEdge(a, b, v);                   // a / b = v
                AddEdge(b, a, ONE_POINT_ZERO / v);  // b / a = 1/v
            }

            // 2. answer each query
            double[] result = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string src = queries[i][ZERO];
                string dst = queries[i][ONE];
                result[i] = Query(src, dst);
            }
            return result;
        }

        // add a directed edge from→to with given weight
        private void AddEdge(string from, string to, double weight)
        {
            if (!graph.TryGetValue(from, out var list))
            {
                list = new List<(string,double)>();
                graph[from] = list;
            }
            list.Add((to, weight));
        }

        // compute value for src/dst or -1.0 if no path
        private double Query(string src, string dst)
        {
            if (!graph.ContainsKey(src) || !graph.ContainsKey(dst))
                return NOT_FOUND;

            var seen = new HashSet<string>();
            return Dfs(src, dst, ONE_POINT_ZERO, seen);
        }

        // DFS accumulating product of weights
        private double Dfs(string cur, string target, double prod, HashSet<string> seen)
        {
            if (cur == target)
                return prod;

            seen.Add(cur);
            if (!graph.TryGetValue(cur, out var list))
                return NOT_FOUND;

            foreach (var (nei, w) in list)
            {
                if (seen.Contains(nei))
                    continue;
                double sub = Dfs(nei, target, prod * w, seen);
                if (sub > ZERO)
                    return sub;
            }

            return NOT_FOUND;
        }
    }
}
