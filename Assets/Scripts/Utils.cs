using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float EPSILON = 1f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return Mathf.Abs(a-b) < EPSILON;
    }

    public static float FixAngle(float a)
    {
        if(ApproximatelyEqual(a, 0))
            return 0;
        if(ApproximatelyEqual(a, 90))
            return 90;
        if(ApproximatelyEqual(a, 180))
            return 180;
        if(ApproximatelyEqual(a, 270))
            return 270;
        if(ApproximatelyEqual(a, 360))
            return 360;
        if(ApproximatelyEqual(a, -90))
            return -90;
        return a;
    }

    public static float Degrees360(float angleDegrees)
    {
        if(angleDegrees >= 360)
            angleDegrees -= 360;
        if(angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }
}
