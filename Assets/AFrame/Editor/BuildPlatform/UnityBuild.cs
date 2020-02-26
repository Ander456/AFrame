using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public struct BuildGenernalSetting
{
	public string productName;
	public string identifier;
	public string bundleVersion;
	public string channel;
	public string companyName;
	public string buildPath;
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

	private static void BuildWindows()
	{
		BuildPlayerOptions playerOptions = new BuildPlayerOptions {
			scenes = EnabledScenePaths,
			locationPathName = Path.Combine(Application.dataPath.Replace("Assets",""), "Publish/Windows"),
			target = BuildTarget.StandaloneWindows
		};
		BuildPipeline.BuildPlayer(playerOptions);
	}

	private static void BuildMacOS()
	{
		BuildPlayerOptions playerOptions = new BuildPlayerOptions {
			scenes = EnabledScenePaths,
			locationPathName = Path.Combine(Application.dataPath.Replace("Assets",""), "Publish/MacOS"),
			target = BuildTarget.StandaloneOSXUniversal
		};
		BuildPipeline.BuildPlayer(playerOptions);
	}

	private static void BuildAndroid()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android,BuildTarget.Android);

		Builder.Build();

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
		PlayerSettings.Android.bundleVersionCode = BundleVersionCode(buildGenernalSetting.bundleVersion);

		AssetDatabase.Refresh();

		BuildPlayerOptions playerOptions = new BuildPlayerOptions {
			scenes = EnabledScenePaths,
			locationPathName = buildGenernalSetting.buildPath,
			target = BuildTarget.Android,
			options = EditorUserBuildSettings.development ? BuildOptions.Development | BuildOptions.AllowDebugging : BuildOptions.None
		};
		BuildPipeline.BuildPlayer(playerOptions);
	}

	private static void BuildIOS()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);

		Builder.Build();

		BuildGenernalSetting buildGenernalSetting = ApplyGeneralSettings();

		PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneAndiPad;//目标设备
		PlayerSettings.iOS.targetOSVersionString = "8.0";//最低iOS版本要求
		PlayerSettings.iOS.statusBarStyle = iOSStatusBarStyle.Default;
		PlayerSettings.iOS.requiresPersistentWiFi = true;
		PlayerSettings.iOS.buildNumber = buildGenernalSetting.bundleVersion;
		PlayerSettings.iOS.appleEnableAutomaticSigning = false;

		AssetDatabase.Refresh();

		BuildPlayerOptions playerOptions = new BuildPlayerOptions {
			scenes = EnabledScenePaths,
			locationPathName = buildGenernalSetting.buildPath,
			target = BuildTarget.iOS,
			options = EditorUserBuildSettings.development ? BuildOptions.Development | BuildOptions.AllowDebugging : BuildOptions.None
		};
		BuildPipeline.BuildPlayer(playerOptions);
	}

	private static BuildGenernalSetting ApplyGeneralSettings()
	{
		BuildGenernalSetting settings = new BuildGenernalSetting();

		foreach (string arg in Environment.GetCommandLineArgs()) 
		{
			if (arg.StartsWith("identifier", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.identifier = arg.Split('=')[1];
				Debug.Log ("fuck" + settings.identifier);
			} 
			else if (arg.StartsWith("channel", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.channel = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("bundleVersion", StringComparison.OrdinalIgnoreCase))
			{
				settings.bundleVersion = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("build_type", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.isDebug = true;
				string code = arg.Split('=')[1];
				if (code == "Release")
					settings.isDebug = false;
			} 
			else if (arg.StartsWith("companyName", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.companyName = arg.Split('=')[1];
			} 
			else if (arg.StartsWith("productName", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.productName = arg.Split('=')[1];
			}
			else if (arg.StartsWith("build_path", StringComparison.OrdinalIgnoreCase)) 
			{
				settings.buildPath = arg.Split('=')[1];
			}
		}

		PlayerSettings.companyName = settings.companyName;
		PlayerSettings.productName = settings.productName;
		PlayerSettings.applicationIdentifier = settings.identifier;
		PlayerSettings.bundleVersion = settings.bundleVersion;
		Debug.Log ("fuck2" + PlayerSettings.applicationIdentifier);
		PlayerSettings.statusBarHidden = true;
		PlayerSettings.allowedAutorotateToLandscapeLeft = true;
		PlayerSettings.allowedAutorotateToLandscapeRight = true;
		PlayerSettings.allowedAutorotateToPortrait = false;
		PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
		PlayerSettings.defaultIsFullScreen = true;
		PlayerSettings.stripEngineCode = false;

		EditorUserBuildSettings.development = settings.isDebug;

		return settings;
	}

	public static int BundleVersionCode(string version)
    {
        if (version == null || string.IsNullOrEmpty(version)) return 0;
        string[] nums = version.Split(new char[] { '.' }, System.StringSplitOptions.RemoveEmptyEntries);
        if (nums.Length != 3)
        {
            return 0;
        }
        int major = int.Parse(nums[0]);
        int minor = int.Parse(nums[1]);
        int build = int.Parse(nums[2]);
        int result = major * 10000 + minor * 100 + build;
		return result;
    }
}
