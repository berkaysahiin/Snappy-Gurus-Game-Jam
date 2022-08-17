using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 ToVector3(this Vector2 vector2)
    {
        var vector3 = new Vector3(vector2.x, 0, vector2.y);
        return vector3;
    }
}
