using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
    public static float ManhattaDistance(this Vector3 a, Vector3 b)
    {
        float x = Mathf.Abs(a.x - b.x);
        float y = Mathf.Abs(a.y - b.y);
        float z = Mathf.Abs(a.z - b.z);

        return x + y + z;
    }

    public static float ManhattaDistance(this Vector2 a, Vector2 b)
    {
        float x = Mathf.Abs(a.x - b.x);
        float y = Mathf.Abs(a.y - b.y);

        return x + y;
    }
}
