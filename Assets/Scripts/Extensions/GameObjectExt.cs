using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for Unity's GameObject type
/// </summary>
public static class GameObjectExt{

	/// <summary>
	/// Sets the parent of a GameObject
	/// </summary>
	/// <param name="go"></param>
	/// <param name="parent"></param>
    public static void SetParent(this GameObject go, GameObject parent){
		go.transform.SetParent(parent.transform);
    }

	/// <summary>
	/// Sets the parent of a GameObject
	/// </summary>
	/// <param name="go"></param>
	/// <param name="parent"></param>
    public static void SetParent(this GameObject go, MonoBehaviour parent){
        go.transform.SetParent(parent.gameObject.transform);
    }
	/// <summary>
	/// Makes a GameObject active
	/// </summary>
	/// <param name="gameObject"></param>
    public static void Activate(this GameObject gameObject) {
        gameObject.SetActive(true);
    }
	/// <summary>
	/// Makes a GameObject inactive
	/// </summary>
	/// <param name="gameObject"></param>
    public static void Deactivate(this GameObject gameObject) {
        gameObject.SetActive(false);
    }

	/// <summary>
	/// Recursively gets all children of this GameObject. Includes children of children of children.. etc.
	/// </summary>
	/// <param name="go"></param>
	/// <returns></returns>
    public static List<GameObject> GetAllChildrenRecursive(this GameObject go) {
		List<GameObject> objs = new List<GameObject>();
		List<Transform> children = new List<Transform>();

		for(int i = 0; i < go.transform.childCount; i++) {
			Transform child = go.transform.GetChild(i);
			children.Add(child);
			objs.Add(child.gameObject);
        }

		for(int i = 0; i < children.Count; i++) {
			Transform child = children[i];
			List<GameObject> childObjects = child.gameObject.GetAllChildrenRecursive();
			objs.AddRange(childObjects);
        }
		return objs;
    }

    /// <summary>
    /// Recursively gets all children of this GameObject with the component T attached to them. Includes children of children of children.. etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static List<T> GetAllChildrenComponentsRecursive<T>(this GameObject go) where T : Component{
		List<T> childrenComponentList = new List<T>();
		List<Transform> children = new List<Transform>();
		
		for(int i = 0; i < go.transform.childCount; i++){
			Transform child = go.transform.GetChild(i);
			children.Add(child);
			T t = child.gameObject.GetComponent<T>();
			if(t != null){
				childrenComponentList.Add(t);
			}
		}
		
		for(int i = 0; i < children.Count; i++){
			Transform child = children[i];
			List<T> childComps = child.gameObject.GetAllChildrenComponentsRecursive<T>();
			foreach(T tcomp in childComps){
				childrenComponentList.Add(tcomp);
			}
		}
		
		return childrenComponentList;
	}
	
	/// <summary>
	/// Destroys all children of this GameObject.
	/// </summary>
	/// <param name="go"></param>
	/// <param name="immediate">Whether to destroy the children using GameObject.DestroyImmediate</param>
	public static void DestroyAllChildren(this GameObject go, bool immediate = true){
		for(int i = go.transform.childCount-1; i >= 0; i--){
			Transform child = go.transform.GetChild(i);
			if(immediate){
				GameObject.DestroyImmediate(child.gameObject);
			}else{
				GameObject.Destroy(child.gameObject);
			}
		}
	}
	
	/// <summary>
	/// Gets all immediate children of this GameObject
	/// </summary>
	/// <param name="go"></param>
	/// <returns></returns>
	public static List<GameObject> GetAllChildren(this GameObject go){
		List<GameObject> list = new List<GameObject>();
		for(int i = 0; i < go.transform.childCount; i++){
			list.Add(go.transform.GetChild(i).gameObject);
		}
		return list;
	}

	/// <summary>
	/// Gets all children of this GameObject with the component T attached.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="go"></param>
	/// <returns></returns>
    public static List<T> GetAllChildrenComponents<T>(this GameObject go) where T : Component{
		List<T> childrenComponentList = new List<T>();
        for(int i = 0; i < go.transform.childCount; i++){
            Transform child = go.transform.GetChild(i);
            T t = child.gameObject.GetComponent<T>();
            if(t != null){
                childrenComponentList.Add(t);
            }
        }

        return childrenComponentList;
	}
	
	/// <summary>
	/// Gets the first child in the hierarchy of this GameObject.
	/// </summary>
	/// <param name="go"></param>
	/// <returns></returns>
	public static GameObject GetFirstChild(this GameObject go){
		if(go.GetChildCount() == 0){
			return null;
		}
		return go.transform.GetChild(0).gameObject;
	}

	/// <summary>
	/// Gets the last child in the hierarchy of this GameObject.
	/// </summary>
	/// <param name="go"></param>
	/// <returns></returns>
	public static GameObject GetLastChild(this GameObject go){
		if(go.GetChildCount() == 0){
			return null;
		}
		return go.transform.GetChild(go.GetChildCount()-1).gameObject;
	}
	
	/// <summary>
	/// Gets the amount of children this GameObject has.
	/// </summary>
	/// <param name="go"></param>
	/// <returns></returns>
	public static int GetChildCount(this GameObject go){
		return go.transform.childCount;
	}
}
