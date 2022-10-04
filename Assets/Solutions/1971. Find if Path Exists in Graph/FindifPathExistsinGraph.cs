namespace FindifPathExistsinGraph
{
    class DisjointSetUnion
    {
        private int[] parents;

        public DisjointSetUnion(int n)
        {
            parents = new int[n];

            // Making sets
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
            }
        }

        public bool AreConnected(int ui, int vi)
        {
            return FindAndMergeSets(ui) == FindAndMergeSets(vi);
        }

        public void Union(int ui, int vi)
        {
            if (ui != vi)
            {
                int uiRootNode = FindAndMergeSets(ui);
                int viRootNode = FindAndMergeSets(vi);
                // Update the set.
                parents[uiRootNode] = viRootNode;
            }
        }

        private int FindAndMergeSets(int node)
        {
            int _rootNode = node;
            // Find until no root node.
            while (_rootNode != parents[_rootNode])
            {
                _rootNode = parents[_rootNode];
            }
            // Merging the root node of set.
            parents[node] = _rootNode;

            return _rootNode;
        }
    }

    public class Solution
    {
        private const int UI_INDEX = 0;
        private const int VI_INDEX = 1;

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            DisjointSetUnion set = new DisjointSetUnion(n);
            for (int i = 0; i < edges.Length; i++)
            {
                set.Union(edges[i][UI_INDEX], edges[i][VI_INDEX]);
            }

            return set.AreConnected(source, destination);
        }
    }
}
