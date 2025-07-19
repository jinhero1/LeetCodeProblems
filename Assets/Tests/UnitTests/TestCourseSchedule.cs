using NUnit.Framework;
using System.Collections;
using CourseSchedule;

public class TestCourseSchedule
{
        private static IEnumerable TestCases
    {
        get
        {
            // Example 1: No cycle, can finish
            yield return new TestCaseData(
                2,
                (object)new int[][] { new[] { 1, 0 } }
            ).Returns(true);

            // Example 2: Cycle exists, cannot finish
            yield return new TestCaseData(
                2,
                (object)new int[][] { new[] { 1, 0 }, new[] { 0, 1 } }
            ).Returns(false);
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public bool Test_CanFinish(int numCourses, int[][] prerequisites)
        => new Solution().CanFinish(numCourses, prerequisites);
}
