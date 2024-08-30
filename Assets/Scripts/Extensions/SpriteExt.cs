using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// A Collection of extension/utility methods for Unity's Sprite type
/// </summary>
public static class SpriteExt{
	
	/// <summary>
	/// Gets this Sprite as a Texture2D
	/// </summary>
	/// <param name="sprite"></param>
	/// <returns></returns>
	public static Texture2D AsTexture(this Sprite sprite){
		if(sprite.texture.isReadable) {
			Texture2D croppedTexture = new Texture2D(sprite.GetWidth(),
													 sprite.GetHeight()
													);
			Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
														(int)sprite.textureRect.y,
														(int)sprite.GetWidth(),
														(int)sprite.GetHeight()
													 );
			croppedTexture.SetPixels(pixels);
			croppedTexture.Apply();
			return croppedTexture;
		}
		
		return null;
	}
	
	/// <summary>
	/// Creates a new sprite combining this sprite and the provided sprite
	/// </summary>
	/// <param name="s"></param>
	/// <param name="s2"></param>
	/// <returns></returns>
	public static Sprite Fuse(this Sprite s, Sprite s2){
		Texture2D mainTex = new Texture2D(Math.Max(s.GetWidth(),s2.GetWidth()), Math.Max(s.GetHeight(), s2.GetHeight()));
		s.DrawToTexture(mainTex, new Vector2(0.2f, 0.2f));
		s2.DrawToTexture(mainTex, new Vector2(0, 0));
		mainTex.Apply();
		return Sprite.Create(mainTex, new Rect(0,0,mainTex.width, mainTex.height), new Vector2(0.5f, 0.5f));
	}
	
	/// <summary>
	/// Draw this sprite onto the provided Texture2D
	/// </summary>
	/// <param name="s"></param>
	/// <param name="tex"></param>
	/// <param name="offset"></param>
	public static void DrawToTexture(this Sprite s, Texture2D tex, Vector2 offset){
		int xOffset = (int)(tex.width * offset.x);
		int yOffset = (int)(tex.height * offset.y);
		for(int x = 0; x < s.GetWidth(); x++){
			for(int y = 0; y < s.GetHeight(); y++){
				Color pixel = s.GetPixel(x,y);
				if(pixel.a > 0.05f){
					tex.SetPixel(x+xOffset,y+yOffset,s.GetPixel(x,y));
				}
			}
		}
	}
	/// <summary>
	/// Get the width of this Sprite
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static int GetWidth(this Sprite s){
		return (int)s.rect.width;
	}
	/// <summary>
	/// Get the height of this Sprite
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static int GetHeight(this Sprite s){
		return (int)s.rect.height;
	}
	/// <summary>
	/// Get the Color of a pixel at the given coordinates in the Sprite.
	/// </summary>
	/// <param name="s"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public static Color GetPixel(this Sprite s, int x, int y){
		return s.texture.GetPixel(x,y);
	}

}
