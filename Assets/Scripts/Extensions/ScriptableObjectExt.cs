using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// A collection of extension/utility methods for Unity's ScriptableObject type
/// </summary> 
public static class ScriptableObjectExt{
#if UNITY_EDITOR

    /// <summary>
    /// Adds another ScriptableObject as a child
    /// </summary>
    /// <param name="asset"></param>
    /// <param name="objectToAdd"></param>
    public static void AddSubAsset(this ScriptableObject asset, ScriptableObject objectToAdd) {
        AssetDatabase.AddObjectToAsset(objectToAdd, asset);
        asset.Dirty();
        AssetDatabase.SaveAssets();
        objectToAdd.Import();
        
    }
    /// <summary>
    /// Calls Unity's callbacks for importing an asset on this ScriptableObject.
    /// </summary>
    /// <param name="asset"></param>
    public static void Import(this ScriptableObject asset) {
        AssetDatabase.ImportAsset(asset.GetPath());
    }

    /// <summary>
    /// Marks this ScriptableObject as Dirty/Changed in the Unity Editor.
    /// </summary>
    /// <param name="asset"></param>
    public static void Dirty(this ScriptableObject asset) {
        EditorUtility.SetDirty(asset);
    }

    /// <summary>
    /// Gets the path of the project directory this ScriptableObject exists in.
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    public static string GetDirectoryPath(this ScriptableObject asset) {
        string path = asset.GetPath();
        return path.Substring(0, path.LastIndexOf("/")+1);
    }

    /// <summary>
    /// Gets the path of this ScriptableObject in the project.
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    public static string GetPath(this ScriptableObject asset) {
        return AssetDatabase.GetAssetPath(asset);
    }
    /// <summary>
    /// Saves this ScriptableObject as an asset file in the project.
    /// </summary>
    /// <param name="asset"></param>
    /// <param name="path"></param>
    public static void SaveAsAsset(this ScriptableObject asset, string path) {
        AssetDatabase.CreateAsset(asset, path);
    }
#endif
}
