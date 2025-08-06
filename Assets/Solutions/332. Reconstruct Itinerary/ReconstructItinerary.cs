using System;
using System.Collections.Generic;

namespace ReconstructItinerary
{
    public class Solution
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            // build graph: origin → sorted list of destinations
            var graph = new Dictionary<string, List<string>>();
            foreach (var ticket in tickets)
            {
                var u = ticket[0];
                var v = ticket[1];
                if (!graph.ContainsKey(u)) graph[u] = new List<string>();
                graph[u].Add(v);
            }
            foreach (var kv in graph)
            {
                kv.Value.Sort(StringComparer.Ordinal);
            }

            var itinerary = new List<string>();
            // Hierholzer’s algorithm via post-order DFS
            void Dfs(string u)
            {
                if (graph.TryGetValue(u, out var dests))
                {
                    while (dests.Count > 0)
                    {
                        var v = dests[0];
                        dests.RemoveAt(0);
                        Dfs(v);
                    }
                }
                itinerary.Add(u);
            }

            Dfs("JFK");
            itinerary.Reverse();
            return itinerary;
        }
    }
}
