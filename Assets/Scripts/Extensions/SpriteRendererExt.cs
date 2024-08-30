using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for Unity's SpriteRenderer type
/// </summary>
public static class SpriteRendererExt{
    
	/// <summary>
	/// Checks if two SpriteRenderer's have overlapping sprites
	/// </summary>
	/// <param name="sr"></param>
	/// <param name="overlapper"></param>
	/// <returns></returns>
	public static bool SpriteOverlaps(this SpriteRenderer sr, SpriteRenderer overlapper){
		Rect r = sr.GetSpriteRect();
		Rect r2 = overlapper.GetSpriteRect();
		
		return r.Overlaps(r2);
	}
	
	/// <summary>
	/// Gets the Rect of the SpriteRenderer's sprite
	/// </summary>
	/// <param name="sr"></param>
	/// <returns></returns>
	public static Rect GetSpriteRect(this SpriteRenderer sr){
		Rect r = new Rect();
		Sprite s = sr.sprite;
		
		r.x = sr.gameObject.transform.position.x - s.bounds.extents.x;
		r.y = sr.gameObject.transform.position.y - s.bounds.extents.y;
		
		r.width = s.bounds.extents.x * 2;
		r.height = s.bounds.extents.y * 2;
		return r;
	}


}
