using System.Collections.Generic;

public class IntArrayUtility
{
    public static int?[] ToIntNullableArray(object[] objects)
    {
        int?[] values = new int?[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            values[i] = objects[i] as int?;
        }

        return values;
    }
}
