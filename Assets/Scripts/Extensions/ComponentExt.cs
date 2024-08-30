using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Collection of extension/utility methods for Unity's Component type
/// </summary>
public static class ComponentExt {

    /// <summary>
    /// Gets a list of the GameObjects these components are attached to.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="components"></param>
    /// <returns></returns>
    public static List<GameObject> AsGameObjects<T>(this List<T> components) where T : Component {
        List<GameObject> gameObjects = new List<GameObject>();
        components.ForEach((component) => gameObjects.Add(component.gameObject));
        return gameObjects;
    }

    /// <summary>
    /// Gets the nearest object in the list to the given point
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public static T Nearest<T>(this List<T> list, Vector3 point) where T : Component {
        T nearest = list[0];
        float shortestDistance = nearest.Distance(point);
        foreach (T t in list) {
            if (t) {
                float distance = t.Distance(point);
                if (distance < shortestDistance) {
                    nearest = t;
                    shortestDistance = distance;
                }
            }

        }

        return nearest;

    }

    /// <summary>
    /// Get the distance between this component's object and a given point.
    /// </summary>
    /// <param name="component"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public static float Distance(this Component component, Vector3 point) {
        return Vector3.Distance(component.transform.position, point);
    }
}