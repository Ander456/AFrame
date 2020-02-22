using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ImportTexture : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
		TextureImporter textureImporter = assetImporter as TextureImporter;
		if (textureImporter != null)
        {
			textureImporter.textureType = TextureImporterType.Sprite;
			textureImporter.spriteImportMode = SpriteImportMode.Single;
			textureImporter.spritePixelsPerUnit = 100;
			textureImporter.spritePackingTag = SpritePackingTag;

			TextureImporterSettings textureImportSetting = new TextureImporterSettings();
			textureImporter.ReadTextureSettings(textureImportSetting);
			textureImportSetting.spriteMeshType = SpriteMeshType.FullRect;
			textureImportSetting.spriteExtrude = 1;
			textureImporter.SetTextureSettings(textureImportSetting);

			textureImporter.mipmapEnabled = false;
			textureImporter.isReadable = false;
			textureImporter.wrapMode = TextureWrapMode.Clamp;
			textureImporter.filterMode = FilterMode.Bilinear;
			textureImporter.alphaIsTransparency = true;
			textureImporter.alphaSource = TextureImporterAlphaSource.FromInput;
			textureImporter.sRGBTexture = true;

			TextureImporterPlatformSettings platformSetting = textureImporter.GetPlatformTextureSettings("Standalone");
			platformSetting.maxTextureSize = 2048;
			platformSetting.textureCompression = TextureImporterCompression.Compressed;
			platformSetting.overridden = true;
			platformSetting.textureCompression = TextureImporterCompression.Compressed;
			platformSetting.format = TextureImporterFormat.DXT5;
			textureImporter.SetPlatformTextureSettings(platformSetting);

			platformSetting = textureImporter.GetPlatformTextureSettings("iPhone");
			platformSetting.maxTextureSize = 2048;
			platformSetting.overridden = true;
			platformSetting.compressionQuality = 100;
			platformSetting.textureCompression = TextureImporterCompression.Compressed;
			platformSetting.format = TextureImporterFormat.PVRTC_RGBA4;
			textureImporter.SetPlatformTextureSettings(platformSetting);

			platformSetting = textureImporter.GetPlatformTextureSettings("Android");
			platformSetting.maxTextureSize = 2048;
			platformSetting.overridden = true;
			platformSetting.textureCompression = TextureImporterCompression.Compressed;
			platformSetting.format = TextureImporterFormat.ETC2_RGBA8;
			textureImporter.SetPlatformTextureSettings(platformSetting);

			platformSetting = textureImporter.GetPlatformTextureSettings("Web");
			platformSetting.maxTextureSize = 2048;
			platformSetting.overridden = true;
			platformSetting.format = TextureImporterFormat.RGBA32;
			textureImporter.SetPlatformTextureSettings(platformSetting);
        }
    }

	string SpritePackingTag
	{
		get {
			return assetPath.Contains ("Assets/Atlas") ? new System.IO.DirectoryInfo (System.IO.Path.GetDirectoryName (assetPath)).Name : "";
		}
	}

	static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string str in movedAssets)
		{
			if (str.Contains("Assets/Atlas")) 
			{
				AssetDatabase.ImportAsset(str);
			}
		}
	}
}