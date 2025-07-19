namespace CourseSchedule
{
    public class Solution
    {
        // Runtime: 4ms (Beats 90.94%)
        // Memory: 48.88MB (Beats 98.81%)
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // 1) Compute indegree and out-degree counts
            int[] indegree = new int[numCourses];
            int[] outCount = new int[numCourses];
            foreach (var pre in prerequisites)
            {
                int course = pre[0], before = pre[1];
                indegree[course]++;
                outCount[before]++;
            }

            // 2) Build fixed‐size adjacency arrays
            int[][] adj = new int[numCourses][];
            for (int i = 0; i < numCourses; i++)
                adj[i] = new int[outCount[i]];

            // helper cursor to fill each row
            int[] cursor = new int[numCourses];
            foreach (var pre in prerequisites)
            {
                int course = pre[0], before = pre[1];
                adj[before][cursor[before]++] = course;
            }

            // 3) Ring‐buffer queue
            int[] queue = new int[numCourses];
            int head = 0, tail = 0;

            // enqueue all zero‐indegree nodes
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    queue[tail++] = i;
            }

            // 4) BFS topological sort
            int seen = 0;
            while (head < tail)
            {
                int u = queue[head++];
                seen++;
                // look at all neighbors
                foreach (int v in adj[u])
                {
                    if (--indegree[v] == 0)
                        queue[tail++] = v;
                }
            }

            // 5) if we saw all nodes, no cycle
            return seen == numCourses;
        }
        /*
        // Runtime: 7ms (Beats 69.62%)
        // Memory: 49.55MB (Beats 88.93%)
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // 1. Define data structures
            //    adj[i] will hold the list of courses that depend on course i
            var adj = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                adj[i] = new List<int>();

            //    indegree[i] = number of prerequisites required before taking course i
            var indegree = new int[numCourses];

            // 2. Populate adj and indegree
            //    Each prerequisite pair [a, b] means b → a
            foreach (var pre in prerequisites)
            {
                int course = pre[0], before = pre[1];
                adj[before].Add(course);   // add edge from 'before' to 'course'
                indegree[course]++;        // increment indegree of 'course'
            }

            // 3. Enqueue all courses with no prerequisites (indegree == 0)
            var q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    q.Enqueue(i);
            }

            // 4. Process courses in topological order
            int taken = 0;
            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                taken++;  // course 'cur' can now be taken

                // Decrease indegree of all courses that depend on 'cur'
                foreach (int next in adj[cur])
                {
                    if (--indegree[next] == 0)
                        q.Enqueue(next);
                }
            }

            // 5. If we were able to take all courses, there is no cycle
            return taken == numCourses;
        }
        */
    }
}
