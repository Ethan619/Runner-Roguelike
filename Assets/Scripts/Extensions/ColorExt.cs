using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Collection of extension/utility methods for Unity's Color type
/// </summary>
public static class ColorExt {


    /// <summary>
    /// Reduces the alpha value of the color by the given amount
    /// </summary>
    /// <param name="color"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Color ReduceAlpha(this Color color, float amount) {
        return new Color(color.r, color.g, color.b, Mathf.Clamp(color.a - amount, 0, 1));
    }

}