using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Collection of extension/utility methods for Unity's Bounds type
/// </summary>
public static class BoundsExt{
    
	public static Bounds Clone(this Bounds bounds){
		Bounds clone = new Bounds(bounds.center.Clone(), bounds.size.Clone());
		clone.extents = bounds.extents.Clone();
		clone.min = bounds.min.Clone();
		clone.max = bounds.max.Clone();
		return clone;
	}

}
