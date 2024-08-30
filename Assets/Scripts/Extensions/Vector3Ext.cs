using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Collection of extension/utility methods for Unity's Vector3 and Vector3Int types
/// </summary>
public static class Vector3Ext{
	
	/// <summary>
	/// Creates a copy of a Vector3
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector3 Clone(this Vector3 vec){
		return new Vector3(vec.x, vec.y, vec.z);
	}
	/// <summary>
	/// Reverses the direction of a Vector3
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static Vector3 Reverse(this Vector3 vec){
		return new Vector3(-vec.x, -vec.y, -vec.z);
	}
	
	
}
