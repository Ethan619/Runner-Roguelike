using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for Unity's MonoBehaviour type
/// </summary>

public static class MonoBehaviourExt {


	public delegate void ActionDelegate();
	public delegate bool ConditionDelegate();
	public delegate Coroutine EnumeratedDelegate();
	public delegate IEnumerator EnumeratorDelegate();

	/// <summary>
	/// Performs an action after the provided delay
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="delay">Delay before performing action</param>
	/// <param name="action">The action to be executed.</param>
	public static void DoAfter(this MonoBehaviour mb, float delay, ActionDelegate action) {
		mb.StartCoroutine(DelayedActionCoroutine(delay, action));
	}
	
	/// <summary>
	/// Performs an action once after the provided condition evaluates to true
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="action"></param>
	/// <param name="condition"></param>
	public static void DoWhenConditionMet(this MonoBehaviour mb, ActionDelegate action, ConditionDelegate condition) {
		mb.StartCoroutine(ConditionedActionCoroutine(action, condition));
	}

	/// <summary>
	/// Performs an action after a given amount of frames.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="frames"></param>
	/// <param name="action"></param>
	public static void DoAfterFrames(this MonoBehaviour mb, int frames, ActionDelegate action) {
		mb.StartCoroutine(DelayedFrameActionCoroutine(frames, action));
	}

	/// <summary>
	/// Performs an action in intervals. Stops if stopCondition evaluates to true
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="interval"></param>
	/// <param name="action"></param>
	/// <param name="stopCondition"></param>
	public static void DoEvery(this MonoBehaviour mb, float interval, ActionDelegate action, ConditionDelegate stopCondition = null) {
		mb.StartCoroutine(IntervalActionCoroutine(interval, action, stopCondition));
	}

	/// <summary>
	/// Performs the provided actions in order. Waiting for each to complete before doing the next.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="actions"></param>
	public static void DoInOrder(this MonoBehaviour mb, params EnumeratedDelegate[] actions) {
		mb.StartCoroutine(OrderedActionCoroutine(mb, actions));
	}

	/// <summary>
	/// Performs the provided actions in order.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="actions"></param>
	public static void DoAsCoroutine(this MonoBehaviour mb, EnumeratorDelegate[] actions) {
		
		EnumeratedDelegate[] actionOrders = new EnumeratedDelegate[actions.Length];

		for (int i = 0; i < actions.Length; i++) {
			//We store index to use in the lambda otherwise the value used by the lambda will change as i changes.
			int index = i;
			actionOrders[i] = () => {
				
				return mb.StartCoroutine(actions[index]());
			};
		}
		
		mb.DoInOrder(actionOrders);
	}

	/// <summary>
	/// A coroutine for performing actions in order.
	/// </summary>
	/// <param name="routineStarter"></param>
	/// <param name="actions"></param>
	/// <returns></returns>
	static IEnumerator OrderedActionCoroutine(MonoBehaviour routineStarter, params EnumeratedDelegate[] actions) {
		for (int i = 0; i < actions.Length; i++) {
			yield return actions[i]();
		}
	}
	/// <summary>
	/// A coroutine for performing an action after a delay
	/// </summary>
	/// <param name="delay"></param>
	/// <param name="action"></param>
	/// <returns></returns>
	static IEnumerator DelayedActionCoroutine(float delay, ActionDelegate action) {
		yield return new WaitForSeconds(delay);
		action();

	}
	/// <summary>
	/// A coroutine for performing an action after a given number of frames.
	/// </summary>
	/// <param name="frames"></param>
	/// <param name="action"></param>
	/// <returns></returns>
	static IEnumerator DelayedFrameActionCoroutine(int frames, ActionDelegate action) {
		for (int i = 0; i < frames; i++) {
			yield return new WaitForEndOfFrame();
		}
		action();
	}

	/// <summary>
	/// A coroutine for performing an action in intervals until a stop condition is met.
	/// </summary>
	/// <param name="interval"></param>
	/// <param name="action"></param>
	/// <param name="stopCondition"></param>
	/// <returns></returns>
	static IEnumerator IntervalActionCoroutine(float interval, ActionDelegate action, ConditionDelegate stopCondition = null) {
		while (true) {
			action();
			yield return new WaitForSeconds(interval);
			if (stopCondition != null && stopCondition()) {
				break;
			}
		}
	}
	
	/// <summary>
	/// A coroutine for performing an action once a condition is evaluated to true.
	/// </summary>
	/// <param name="action"></param>
	/// <param name="condition"></param>
	/// <returns></returns>
	static IEnumerator ConditionedActionCoroutine(ActionDelegate action, ConditionDelegate condition) {
		yield return new WaitUntil(() => condition != null && condition());
		action();
	}

	/// <summary>
	/// Destroys all children of this object
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="immediate"></param>
	public static void DestroyAllChildren(this MonoBehaviour mb, bool immediate = true) {
		mb.gameObject.DestroyAllChildren(immediate);
	}
	/// <summary>
	/// Checks if this object is active in the hierarchy
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static bool IsActive(this MonoBehaviour mb) {
		return mb.gameObject.activeSelf && mb.gameObject.activeInHierarchy;
	}
	/// <summary>
	/// Sets this object to be active
	/// </summary>
	/// <param name="mb"></param>
	public static void Activate(this MonoBehaviour mb) {
		mb.gameObject.SetActive(true);
	}
	/// <summary>
	/// Sets this object to be inactive
	/// </summary>
	/// <param name="mb"></param>
	public static void Deactivate(this MonoBehaviour mb) {
		mb.gameObject.SetActive(false);
	}
	/// <summary>
	/// Gets the amount of children this object has
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static int GetChildCount(this MonoBehaviour mb) {
		return mb.gameObject.transform.childCount;
	}
	/// <summary>
	/// Gets the first child of this object in the hierarchy
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static GameObject GetFirstChild(this MonoBehaviour mb) {
		if (mb.GetChildCount() == 0) {
			return null;
		}
		return mb.gameObject.transform.GetChild(0).gameObject;
	}
	/// <summary>
	/// Gets the last child of this object in the hierarchy
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static GameObject GetLastChild(this MonoBehaviour mb) {
		if (mb.GetChildCount() == 0) {
			return null;
		}
		return mb.gameObject.transform.GetChild(mb.GetChildCount() - 1).gameObject;
	}

    /// <summary>
    /// Recursively gets all children of this object with the component T attached to them. Includes children of children of children.. etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="mb"></param>
    /// <returns></returns>
    public static List<T> GetAllChildrenComponentsRecursive<T>(this MonoBehaviour mb) where T : Component {
		return mb.gameObject.GetAllChildrenComponentsRecursive<T>();
	}
    /// <summary>
    /// Gets all children of this object with the component T attached.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="mb"></param>
    /// <returns></returns>
    public static List<T> GetAllChildrenComponents<T>(this MonoBehaviour mb) where T : Component{
		return mb.gameObject.GetAllChildrenComponents<T>();
	}

	/// <summary>
	/// Gets the parent of this object
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static bool HasParent(this MonoBehaviour mb) {
		return mb.gameObject.transform.parent != null;
	}

	/// <summary>
	/// Gets the component T from the parent of this object.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static T GetParentComponent<T>(this MonoBehaviour mb) where T : Component {
		if (!mb.HasParent()) {
			return null;
		}
		Transform parent = mb.GetParent();
		T t = parent.gameObject.GetComponent<T>();
		return t;
	}

	/// <summary>
	/// Gets the parent Transform of this object.
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static Transform GetParent(this MonoBehaviour mb) {
		return mb.gameObject.transform.parent;
	}

	/// <summary>
	/// Sets the UI parent of this object
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="parent"></param>
	public static void SetParent(this MonoBehaviour mb, RectTransform parent) {
		mb.gameObject.transform.SetParent(parent, false);
	}
	/// <summary>
	/// Sets the parent of this object.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="parent"></param>
	public static void SetParent(this MonoBehaviour mb, Transform parent) {
		mb.gameObject.transform.SetParent(parent);
	}
	/// <summary>
	/// Sets the parent of this object.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="parent"></param>
	public static void SetParent(this MonoBehaviour mb, MonoBehaviour parent) {
		mb.gameObject.transform.SetParent(parent.gameObject.transform);
	}
	/// <summary>
	/// Sets the parent of this object.
	/// </summary>
	/// <param name="mb"></param>
	/// <param name="parent"></param>
	public static void SetParent(this MonoBehaviour mb, GameObject parent) {
		mb.gameObject.transform.SetParent(parent.transform);
	}

	/// <summary>
	/// Removes this object's parent.
	/// </summary>
	/// <param name="mb"></param>
	public static void RemoveParent(this MonoBehaviour mb) {
		mb.gameObject.transform.SetParent(null);
	}

	/// <summary>
	/// Gets all immediate children of this object
	/// </summary>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static List<GameObject> GetAllChildren(this MonoBehaviour mb) {
		return mb.gameObject.GetAllChildren();
	}





	

	/// <summary>
	/// Gets component T from the closest Parent in the hierarchy that has it.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="mb"></param>
	/// <returns></returns>
	public static T GetClosestParentComponent<T>(this MonoBehaviour mb) where T : Component {
		if (!mb.HasParent()) {
			return default(T);
		}
		Transform activeObject = mb.transform;

		while (activeObject != null && activeObject.HasParent()) {
			T t = activeObject.GetParentComponent<T>();
			if (t == null) {
				activeObject = mb.GetParent();
			} else {
				return t;
			}
		}

		return null;
	}

}












