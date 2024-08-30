using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for Unity's Vector2 and Vector2Int types
/// </summary>
public static class Vector2Ext{
	
	/// <summary>
	/// Creates a copy of a Vector2
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector2 Clone(this Vector2 vec){
		return new Vector2(vec.x, vec.y);
	}
	/// <summary>
	/// Creates a copy of a Vector2Int
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector2Int Clone(this Vector2Int vec) {
		return new Vector2Int(vec.x, vec.y);
	}

	/// <summary>
	/// Reverses the direction of a Vector2
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector2 Reverse(this Vector2 vec){
		return new Vector2(-vec.x, -vec.y);
	}

	/// <summary>
	/// Reverses the direction of a Vector2Int
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector2Int Reverse(this Vector2Int vec) {
		return new Vector2Int(-vec.x, -vec.y);
	}
	
	/// <summary>
	/// Rotates the direction of a Vector2 by a given degrees
	/// </summary>
	/// <param name="vec"></param>
	/// <param name="degrees"></param>
	/// <returns></returns>
	public static Vector2 Rotate(this Vector2 vec, float degrees){
		return Quaternion.Euler(0, 0, degrees) * vec;
	}

	/// <summary>
	/// Rotates the direction of a Vector2Int by a given degrees
	/// </summary>
	/// <param name="vec"></param>
	/// <param name="degrees"></param>
	/// <returns></returns>
	public static Vector2Int Rotate(this Vector2Int vec, float degrees) {
		Vector2 v = new Vector2(vec.x, vec.y).Rotate(degrees);
		return new Vector2Int(Mathf.RoundToInt(v.x),Mathf.RoundToInt(v.y));
    }
}
