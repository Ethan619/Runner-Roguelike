using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A Collection of extension/utility methods for Unity's Transform type
/// </summary>
public static class TransformExt{
	
	/// <summary>
	/// Copy this transform's data to another Transform
	/// </summary>
	/// <param name="source"></param>
	/// <param name="to"></param>
	public static void CopyTo(this Transform source, Transform to){
		to.position = source.position.Clone();
		to.localEulerAngles = source.localEulerAngles.Clone();
		to.localPosition = source.localPosition.Clone();
		to.localRotation = source.localRotation.Clone();
		to.localScale = source.localScale.Clone();
		to.rotation = source.rotation.Clone();
	}
	
	/// <summary>
	/// Sets this object to active
	/// </summary>
	/// <param name="t"></param>
	public static void Activate(this Transform t) {
		t.gameObject.Activate();
	}
	/// <summary>
	/// Sets this object to inactive
	/// </summary>
	/// <param name="t"></param>
	public static void Deactivate(this Transform t) {
		t.gameObject.Deactivate();
	}
	/// <summary>
	/// Checks if this Transform has a parent.
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	public static bool HasParent(this Transform t){
		return t.parent != null;
	}
	
	/// <summary>
	/// Get all children of this object.
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	public static List<GameObject> GetAllChildren(this Transform t){
		return t.gameObject.GetAllChildren();
	}
	
	/// <summary>
	/// Get the component T in the parent of this object.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static T GetParentComponent<T>(this Transform mb) where T : Component{
		if(!mb.HasParent()){
			return default(T);
		}
		Transform parent = mb.parent;
		T t = parent.gameObject.GetComponent<T>();
		return t;
	}

	/// <summary>
	/// Bring this object to the front of objects with identical rendering by setting it as last in it's sibling hierarchy
	/// </summary>
	/// <param name="t"></param>
	public static void BringToFront(this Transform t) {
		t.SetAsLastSibling();
    }
	
	/// <summary>
	/// Maximize the anchors of the RectTransform
	/// </summary>
	/// <param name="rt"></param>
	public static void Maximize(this RectTransform rt) {
		rt.offsetMin = Vector2.zero;
		rt.offsetMax = Vector2.zero;
		rt.anchoredPosition = Vector2.zero;

		rt.anchorMin = Vector2.zero;
		rt.anchorMax = Vector2.one;
    }

	/// <summary>
	/// Set the Y position for the Transform
	/// </summary>
	/// <param name="transform"></param>
	/// <param name="y"></param>
	public static void SetY(this Transform transform, float y) {
		Vector3 pos = transform.position;
		pos.y = y;
		transform.position = pos;
	}

	/// <summary>
	/// Gets the transform as a RectTransform
	/// </summary>
	/// <param name="transform"></param>
	/// <returns></returns>
	public static RectTransform AsRectTransform(this Transform transform) {
		RectTransform rt = (RectTransform)transform;
		if (!rt) {
			rt = transform.gameObject.GetComponent<RectTransform>();
		}
		return rt;
	}

}
		
