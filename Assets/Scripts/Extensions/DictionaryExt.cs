using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for the Dictionary type
/// </summary>
public static class DictionaryExt {

    public delegate void DictionaryOperation<T, K>(T key);

    /// <summary>
    /// Performs an action for each pair in the dictionary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="dict"></param>
    /// <param name="operation"></param>
    public static void ForEach<T,K>(this Dictionary<T,K> dict, DictionaryOperation<T, K> operation) {
        List<T> keys = new List<T>();
        keys.AddRange(dict.Keys);
        foreach(T key in keys) {
            operation(key);
        }
    }

    /// <summary>
    /// Gets the value using the Key's index.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="dict"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static K GetValueByKeyIndex<T, K>(this Dictionary<T,K> dict, int index) {
        List<T> keys = new List<T>(dict.Keys);
        return dict[keys[index]];
    }

}
