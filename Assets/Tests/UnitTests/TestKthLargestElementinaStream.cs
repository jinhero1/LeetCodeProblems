using NUnit.Framework;
using KthLargestElementinaStream;

public class TestKthLargestElementinaStream
{
    [Test]
    [TestCase(new string[] { "KthLargest", "add", "add", "add", "add", "add" },
        new object[] { new object[] { 3, new int[] { 4, 5, 8, 2 } }, 3, 5, 10, 9, 4 },
        new object[] { null, 4, 5, 5, 8, 8 },
        TestName = "Example 1")]
    [TestCase(new string[] { "KthLargest", "add", "add", "add", "add", "add" },
        new object[] { new object[] { 1, new int[] { } }, -3, -2, -4, 0, 4 },
        new object[] { null, -3, -2, -2, 0, 4 },
        TestName = "Example 2")]
    public void Calculate_KthLargestElementinaStream(string[] methods, object[] parameterObjects, object[] result)
    {
        KthLargest kthLargest = null;
        object[] output = new object[result.Length];
        for (int i = 0; i < methods.Length; i++)
        {
            switch (methods[i])
            {
                case "KthLargest":
                    object[] subParameters = (object[])parameterObjects[i];
                    int k = (int)subParameters[0];
                    int[] nums = (int[])subParameters[1];
                    kthLargest = new KthLargest(k, nums);

                    output[i] = null;
                    break;
                case "add":
                    int val = (int)parameterObjects[i];
                    int kthLargestValue = kthLargest.Add(val);

                    output[i] = kthLargestValue;
                    break;
            }
        }

        CollectionAssert.AreEqual(result, output);
    }
}