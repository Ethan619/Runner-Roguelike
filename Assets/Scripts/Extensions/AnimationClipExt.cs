using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// A Collection of extension/utility methods for Unity's AnimationClip type
/// </summary>
public static class AnimationClipExt{


#if UNITY_EDITOR
	/// <summary>
	/// Obtains a list of the 2D sprites used within the AnimationClip.
	/// </summary>
	/// <param name="clip">The animation clip to get sprites from.</param>
	/// <param name="removeDuplicateSprites">Whether sprites that appear more than once in the animation should appear more than once in the returned list.</param>
	/// <returns></returns>
	public static List<Sprite> GetSprites(this AnimationClip clip, bool removeDuplicateSprites = false) {
		List<Sprite> sprites = new List<Sprite>();

		foreach (EditorCurveBinding binding in AnimationUtility.GetObjectReferenceCurveBindings(clip)) {
			ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(clip, binding);

			foreach (ObjectReferenceKeyframe keyframe in keyframes) {
				sprites.Add((Sprite)keyframe.value);
			}

		}
		if (removeDuplicateSprites) {
			sprites.RemoveDuplicates();
		}

		return sprites;
	}
	
	#endif
	
	
}