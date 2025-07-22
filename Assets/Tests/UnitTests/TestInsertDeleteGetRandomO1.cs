using NUnit.Framework;
using System.Collections;
using InsertDeleteGetRandomO1;

public class TestInsertDeleteGetRandomO1
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(
                (object)new string[] {
                    "RandomizedSet", "insert", "remove", "insert",
                    "getRandom",    "remove", "insert", "getRandom"
                },
                (object)new object[] {
                    new object[] { },        // RandomizedSet()
                    new object[] { 1 },      // insert(1)
                    new object[] { 2 },      // remove(2)
                    new object[] { 2 },      // insert(2)
                    new object[] { },        // getRandom()
                    new object[] { 1 },      // remove(1)
                    new object[] { 2 },      // insert(2)
                    new object[] { }         // getRandom()
                },
                (object)new object[] {
                    null,   // ctor
                    true,   // inserted 1
                    false,  // 2 not present
                    true,   // inserted 2
                    2,      // assume GetRandom() returns 2
                    true,   // removed 1
                    false,  // 2 already present
                    2       // only 2 remains
                }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_RandomizedSetCommands(string[] cmds, object[] argsList, object[] expected)
    {
        var results = new object[cmds.Length];
        RandomizedSet rs = null;

        for (int i = 0; i < cmds.Length; i++)
        {
            var args = (object[])argsList[i];
            switch (cmds[i])
            {
                case "RandomizedSet":
                    rs = new RandomizedSet();
                    results[i] = null;
                    break;
                case "insert":
                    results[i] = rs.Insert((int)args[0]);
                    break;
                case "remove":
                    results[i] = rs.Remove((int)args[0]);
                    break;
                case "getRandom":
                    results[i] = rs.GetRandom();
                    break;
                default:
                    Assert.Fail($"Unknown command: {cmds[i]}");
                    break;
            }
        }

        CollectionAssert.AreEqual(expected, results);
    }
}
