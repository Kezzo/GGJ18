using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static Vector2 XZ(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    public static bool NearlyEqual(this Vector2 a, Vector2 b, float precision)
    {
        return (a - b).sqrMagnitude < precision * precision;
    }

    public static bool NearlyEqual(this Vector3 a, Vector3 b, float precision)
    {
        return (a - b).sqrMagnitude < precision * precision;
    }

    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
    {
        System.Random rnd = new System.Random();
        return source.OrderBy((item) => rnd.Next());
    }
}
