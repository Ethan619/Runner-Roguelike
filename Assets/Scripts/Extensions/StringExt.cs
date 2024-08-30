using System.Collections.Generic;

/// <summary>
/// A Collection of extension/utility methods for the string type
/// </summary>
public static class StringExt {

    /// <summary>
    /// Checks if two strings are equal while ignoring capitalization of letters.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool EqualsIgnoreCase(this string s, string s2) {
        return s.ToLower().Equals(s2.ToLower());
    }

    /// <summary>
    /// Concatanates a list of strings
    /// </summary>
    /// <param name="list"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string AsString(this List<string> list, string separator = "") {
        string res = "";
        list.ForEach(s => res += s + separator);
        return res;
    }
}