using NUnit.Framework;
using ImplementStackusingQueues;

public class TestImplementStackusingQueues
{
    [Test]
    [TestCase(new string[] { "MyStack", "push", "push", "top", "pop", "empty" },
        new object[] { null, 1, 2, null, null, null },
        new object[] { null, null, null, 2, 2, false },
        TestName = "Example 1")]
    [TestCase(new string[] { "MyStack", "push", "pop", "empty" },
        new object[] { null, 1, null, null },
        new object[] { null, null, 1, true },
        TestName = "Example 2")]
    public void Calculate_ImplementStackusingQueues(string[] methods, object[] parameterObjects, object[] result)
    {
        int?[] parameterValues = IntArrayUtility.ToIntNullableArray(parameterObjects);

        MyStack myStack = null;
        object[] output = new object[result.Length];
        for (int i = 0; i < methods.Length; i++)
        {
            switch (methods[i])
            {
                case "MyStack":
                    myStack = new MyStack();
                    output[i] = null;
                    break;
                case "push":
                    myStack.Push(parameterValues[i].Value);
                    output[i] = null;
                    break;
                case "top":
                    output[i] = myStack.Top();
                    break;
                case "pop":
                    output[i] = myStack.Pop();
                    break;
                case "empty":
                    output[i] = myStack.Empty();
                    break;
            }
        }

        CollectionAssert.AreEqual(result, output);
    }
}
