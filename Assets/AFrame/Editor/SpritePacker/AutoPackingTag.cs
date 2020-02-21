using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class AutoPackingTag : AssetPostprocessor 
{
	void OnPostprocessTexture (Texture2D texture) 
	{
		string AtlasName =  new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
		TextureImporter textureImporter  = assetImporter as TextureImporter;
		textureImporter.textureType = TextureImporterType.Sprite;
		textureImporter.spritePackingTag = AtlasName;
		textureImporter.mipmapEnabled = false;
	}
}