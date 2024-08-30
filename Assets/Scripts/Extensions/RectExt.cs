using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Collection of extension/utility methods for Unity's Rect and RectInt types
/// </summary>
public static class RectExt{

	public enum RectDirection {
		Up, Down, Left, Right
	}
	
	/// <summary>
	/// Returns a Rect with the size increased by length in the given direction.
	/// </summary>
	/// <param name="rect"></param>
	/// <param name="direction"></param>
	/// <returns></returns>
	public static Rect Extend(this Rect rect, RectDirection direction, float length = 1){
		
		if(direction == RectDirection.Left){
			return new Rect(rect.x-length, rect.y, rect.width + length, rect.height);
		}else if(direction == RectDirection.Right){
			return new Rect(rect.x, rect.y, rect.width + length, rect.height);
		}else if(direction == RectDirection.Up){
			return new Rect(rect.x, rect.y, rect.width, rect.height + length);
		}else if(direction == RectDirection.Down){
			return new Rect(rect.x, rect.y-length, rect.width, rect.height+length);
		}
		
		return rect;
	}

	/// <summary>
	/// Creates a RectInt that is moved by a given amount
	/// </summary>
	/// <param name="rect"></param>
	/// <param name="dx"></param>
	/// <param name="dy"></param>
	/// <returns></returns>
	public static RectInt Move(this RectInt rect, int dx, int dy) {

		return new RectInt(rect.x + dx, rect.y + dy, rect.width, rect.height);
    }

    /// <summary>
    /// Returns a RectInt with the size increased by length in the given direction.
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static RectInt Extend(this RectInt rect, RectDirection direction, int length = 1) {

		if(direction == RectDirection.Left) {
			return new RectInt(rect.x - length, rect.y, rect.width + length, rect.height);
		} else if(direction == RectDirection.Right) {
			return new RectInt(rect.x, rect.y, rect.width + length, rect.height);
		} else if(direction == RectDirection.Up) {
			return new RectInt(rect.x, rect.y, rect.width, rect.height + length);
		} else if(direction == RectDirection.Down) {
			return new RectInt(rect.x, rect.y - length, rect.width, rect.height + length);
		}

		return rect;
	}

	/// <summary>
	/// Gets a Rect grown by the given length in every direction
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Rect Grow(this Rect rect, float length = 1) {

		Rect result = rect;
		foreach(RectDirection direction in System.Enum.GetValues(typeof(RectDirection))) {
			result = result.Extend(direction, length);
        }
		return result;
    }
	/// <summary>
	/// Returns a copy of this Rect
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Rect Copy(this Rect rect) {
		return new Rect(rect.x, rect.y, rect.width, rect.height);
    }
    /// <summary>
    /// Gets a RectInt grown by the given length in every direction
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static RectInt Grow(this RectInt rect, int length = 1) {
		RectInt result = rect;

        foreach (RectDirection direction in System.Enum.GetValues(typeof(RectDirection))) {
            result = result.Extend(direction, length);
		}
		return result;
	}

	/// <summary>
	/// Gets a Rect that is shrank in by the given amount
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Rect Shrink(this Rect rect, float amount = 1){
		float x = rect.x + amount;
		float y = rect.y + amount;
		float width = rect.width - (amount*2);
		float height = rect.height - (amount*2);
		
		return new Rect(x,y,width,height);
	}

	/// <summary>
	/// Checks if the given position is within the Rect
	/// </summary>
	/// <param name="rect"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public static bool ContainsPoint(this Rect rect, float x, float y) {
		return x >= rect.x && y >= rect.y && x < rect.x + rect.width && y < rect.y + rect.height; 
    }
	/// <summary>
	/// Checks if the given position is within the RectInt
	/// </summary>
	/// <param name="rect"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public static bool ContainsPoint(this RectInt rect, int x, int y) {
		return x >= rect.x && y >= rect.y && x < rect.x + rect.width && y < rect.y + rect.height; 
    }
	
	/// <summary>
	/// Gets a random point within the Rect
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Vector2 RandomPoint(this Rect rect){
		float x = Random.Range(rect.x, rect.x + rect.width-1);
		float y = Random.Range(rect.y, rect.y + rect.height-1);
		return new Vector2(x,y);
	}
	
	/// <summary>
	/// Gets a Random point within the Rect as Vector2Int
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Vector2Int RandomIntPoint(this Rect rect){
		Vector2 r = rect.RandomPoint();
		return new Vector2Int((int)r.x, (int)r.y);
	}
	/// <summary>
	/// Gets a random point within the RectInt 
	/// </summary>
	/// <param name="rect"></param>
	/// <returns></returns>
	public static Vector2Int RandomPoint(this RectInt rect) {
		int x = Random.Range(rect.x, rect.x + rect.width-1);
		int y = Random.Range(rect.y, rect.y + rect.height - 1);
		return new Vector2Int(x, y);
	}
}