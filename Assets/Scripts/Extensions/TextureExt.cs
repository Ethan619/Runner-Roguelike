using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A Collection of extension/utility methods for Unity's Texture2D type
/// </summary>
public static class TextureExt{
    /// <summary>
    /// Converts the texture to a Sprite
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static Sprite AsSprite(this Texture2D texture) {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width * 0.5f, texture.height * 0.5f));
    }
}
