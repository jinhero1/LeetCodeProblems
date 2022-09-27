using System.Collections.Generic;
using UnityEngine;

public class DebugUtility
{
    public static void Log(int[] output)
    {
        if (output == null)
        {
            Debug.Log("Output is null");
        }
        else if (output.Length == 0)
        {
            Debug.Log($"Output length is zero");
        }
        else
        {
            Debug.Log(string.Join(",", output));
        }
    }

    public static void Log<T>(IList<T> output)
    {
        if (output == null)
        {
            Debug.Log("Output is null");
        }
        else if (output.Count == 0)
        {
            Debug.Log($"Output count is zero");
        }
        else
        {
            Debug.Log(string.Join(",", output));
        }
    }
}
