using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for the int type
/// </summary>
public static class IntExt {

    /// <summary>
    /// Checks if the int is an odd value
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsOdd(this int num) {
        return num % 2 == 0;
    }

    /// <summary>
    /// Increments the number but does not surpass the max value
    /// </summary>
    /// <param name="num"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int ClampIncrement(this int num, int max) {
        num++;
        return Mathf.Min(num, max);
    }

    /// <summary>
    /// Decrements the number but does not go below the min value
    /// </summary>
    /// <param name="num"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static int ClampDecrement(this int num, int min) {
        num--;
        return Mathf.Max(num, min);
    }

    /// <summary>
    /// Increments the number but loops to the min value if surpassing the max value
    /// </summary>
    /// <param name="num"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int LoopIncrement(this int num, int min, int max) {
        num++;
        num = num > max ? min : num;
        return num;
    }

    /// <summary>
    /// Checks if the number is within an inclusive range
    /// </summary>
    /// <param name="num"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static bool WithinRange(this int num, int min, int max) {
        return num >= min && num <= max;
    }

    /// <summary>
    /// Increments the number but returns to 0 if the value surpasses the max
    /// </summary>
    /// <param name="num"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int LoopIncrement(this int num, int max) {
        return num.LoopIncrement(0, max);
    }

    /// <summary>
    /// Decrements the number but loops to the max value if going below the min value.
    /// </summary>
    /// <param name="num"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int LoopDecrement(this int num, int min, int max) {
        num--;
        num = num < min ? max : num;
        return num;
    }

    /// <summary>
    /// Decrements the number but loops to the max value if going below 0
    /// </summary>
    /// <param name="num"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int LoopDecrement(this int num, int max) {
        return num.LoopDecrement(0, max);
    }

}