using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public struct BuildGenernalSetting
{
	public string projectName;
	public string productName;
	public string identifier;
	public string version;
	public string channel;
	public int generation;
	public string outputPath;
	public string companyName;

	public bool isDebug; 
}

public class UnityBuild
{

	private static string[] EnabledScenePaths
    {
		get {
			List<string> names = new List<string> ();
			foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes) {
				if (e == null)
					continue;
				if (e.enabled)
					names.Add (e.path);
			}
			return names.ToArray ();
		}
    }

	public static void BuildPlatforms()
	{
		List<string> arguments = Environment.GetCommandLineArgs().ToList();

		if (arguments.Contains("-windows"))
			BuildWindows();

		if (arguments.Contains("-macos"))
			BuildMacOS();

		if (arguments.Contains("-android"))
			BuildAndroid();

		if (arguments.Contains("-ios"))
			BuildiOS();

	}

	private static void BuildWindows()
	{
		string output = string.Format("{0}/../Publish/Windows/{1}", Application.dataPath, PlayerSettings.productName);
		BuildPipeline.BuildPlayer(EnabledScenePaths, output, BuildTarget.StandaloneWindows, BuildOptions.None);
	}

	private static void BuildMacOS()
	{
		string output = string.Format("{0}/../Publish/Macos/{1}", Application.dataPath, PlayerSettings.productName);
		BuildPipeline.BuildPlayer(EnabledScenePaths, output, BuildTarget.StandaloneOSXUniversal, BuildOptions.None);
	}

	private static void BuildAndroid()
	{
		string keystoreName = string.Empty;
		string keystorePass = string.Empty;
		string keyaliasName = string.Empty;
		string keyaliasPass = string.Empty;

		foreach (string arg in Environment.GetCommandLineArgs())
		{
			if (arg.StartsWith("keystoreName", StringComparison.OrdinalIgnoreCase))
			{
				keystoreName = arg.Split('=')[1];
			}
			else if (arg.StartsWith("keystorePass", StringComparison.OrdinalIgnoreCase))
			{
				keystorePass = arg.Split('=')[1];
			}
			else if (arg.StartsWith("keyaliasName", StringComparison.OrdinalIgnoreCase))
			{
				keyaliasName = arg.Split('=')[1];
			}
			else if (arg.StartsWith("keyaliasPass", StringComparison.OrdinalIgnoreCase))
			{
				keyaliasPass = arg.Split('=')[1];
			}
		}

		if (!string.IsNullOrEmpty(keystorePass) &&
			!string.IsNullOrEmpty(keyaliasPass) &&
			!string.IsNullOrEmpty(keyaliasName))
		{
			PlayerSettings.Android.keystoreName = keystoreName;
			PlayerSettings.Android.keystorePass = keystorePass;
			PlayerSettings.Android.keyaliasName = keyaliasName;
			PlayerSettings.Android.keyaliasPass = keyaliasPass;
		}

		BuildGenernalSetting buildGenernalSetting = ApplyGeneralSettings();
		PlayerSettings.Android.bundleVersionCode = buildGenernalSetting.generation;

		AssetDatabase.Refresh();

		string output = string.Format("{0}/../Publish/Android/Apks/{1}", Application.dataPath, buildGenernalSetting.outputPath);

		BuildPipeline.BuildPlayer(EnabledScenePaths, output, BuildTarget.Android, BuildOptions.None);
	}

	private static void BuildiOS()
	{
		BuildGenernalSetting buildGenernalSetting = ApplyGeneralSettings();
		string output = string.Format("{0}/../Publish/Ios/{1}", Application.dataPath, buildGenernalSetting.outputPath);

		PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneAndiPad;//目标设备
		PlayerSettings.iOS.targetOSVersionString = "8.0";//最低iOS版本要求
		PlayerSettings.iOS.statusBarStyle = iOSStatusBarStyle.Default;
		PlayerSettings.iOS.requiresPersistentWiFi = true;

		PlayerSettings.statusBarHidden = true;
		PlayerSettings.allowedAutorotateToLandscapeLeft = true;
		PlayerSettings.allowedAutorotateToLandscapeRight = true;
		PlayerSettings.allowedAutorotateToPortrait = false;
		PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
		PlayerSettings.defaultIsFullScreen = true;
		PlayerSettings.stripEngineCode = false;

		AssetDatabase.Refresh();

		BuildPipeline.BuildPlayer(EnabledScenePaths, output, BuildTarget.iOS, BuildOptions.None);
	}

	private static BuildGenernalSetting ApplyGeneralSettings()
	{
		BuildGenernalSetting settings = new BuildGenernalSetting();

		foreach (string arg in Environment.GetCommandLineArgs()) 
		{
			if (arg.StartsWith("project_name", StringComparison.OrdinalIgnoreCase))
			{
				settings.projectName = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("identifier", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.identifier = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("channel", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.channel = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("version", StringComparison.OrdinalIgnoreCase))
			{
				settings.version = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("generation", StringComparison.OrdinalIgnoreCase)) 
			{
				string code = arg.Split('=')[1];
				int.TryParse(code, out settings.generation);
			} 
			else if (arg.StartsWith("publish", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.isDebug = true;
				string code = arg.Split('=')[1];
				if (code == "release")
					settings.isDebug = false;
			} 
			else if (arg.StartsWith("output_path", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.outputPath = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("companyName", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.companyName = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("productName", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.productName = arg.Split('=')[1];
			}
		}

		PlayerSettings.companyName = settings.companyName;
		PlayerSettings.productName = settings.productName;
		PlayerSettings.applicationIdentifier = settings.identifier;
		PlayerSettings.bundleVersion = settings.version;

		return settings;
	}
}
