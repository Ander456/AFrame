using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System;
using System.IO;
using System.Collections.Generic;

/// https://blog.csdn.net/linxinfa/article/details/87618408
/// <summary>
/// Xcode post process.
/// </summary>
public class XcodePostProcess 
{

	[PostProcessBuildAttribute(1)]
	public static void OnPostProcessBuild(BuildTarget buildTarget, string pathToBuiltProject)
	{
		// 只处理IOS工程， pathToBuildProject会传入导出的ios工程的根目录
		if (buildTarget != BuildTarget.iOS)
		        return;

		// 创建工程设置对象
		var projectPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
		PBXProject project = new PBXProject();
		project.ReadFromFile(projectPath);
		string targetGuid = project.TargetGuidByName("Unity-iPhone");

		// 修改BITCODE设置的例子
		project.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");

		// 你可能会设置的--------------------------------------------------
		//project.SetBuildProperty(targetGuid, "CODE_SIGN_IDENTITY", "p12证书的code_sign");
		// 把证书设置设置为手动，即不使用Automatically manage signing
		//project.SetTargetAttributes("ProvisioningStyle","Manual");

		//project.SetBuildProperty(targetGuid, "PROVISIONING_PROFILE", "mobileprovison文件的UUID");
		//project.SetBuildProperty(targetGuid, "PROVISIONING_PROFILE_SPECIFIER", "mobileprovison文件的Name");

		//project.SetTeamId(targetGuid,"证书的TeamId");
		//project.SetBuildProperty(targetGuid, "IPHONEOS_DEPLOYMENT_TARGET", "8.0");

		// 添加framework
		//project.AddFrameworkToProject(targetGuid, "StoreKit.framework", true);
		//----------------------------------------------------------------

		// 修改后的内容写回到配置文件
//		File.WriteAllText(projectPath, project.WriteToString());
//
//		// 修改Info.plist的示例
//		var plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
//		var plist = new PlistDocument();
//		plist.ReadFromFile(plistPath);
//
//		// 增加字符串类型的设置
//		plist.root.SetString("fieldname", "value");
//
//		// 修改后的内容写回到文件Info.plist
//		plist.WriteToFile(plistPath);

	}
}

public class XcodeExportPlist
{

	/// <summary>
	/// 对应ios_build_config.json的exportArchiveMethod
	/// </summary>
	public static readonly string[] kMethods =
	{
		"app-store",
		"enterprise",
		"ad-hoc",
		"development",
	};

	public static void GenFile(string filPath, string teamID, string method, string bundleID, string profileName)
	{
		string text = GenText(teamID, method, bundleID, profileName);
		System.IO.File.WriteAllText(filPath, text);
	}

	static string GenText(string teamID, string method, string bundleID, string profileName)
	{
		var sb = new System.Text.StringBuilder();
		sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
		sb.Append("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n");
		sb.Append("<plist version=\"1.0\">\n");
		sb.Append("<dict>\n");

		AppendTeamID(sb, teamID);
		AppendMethod(sb, method);
		AppendUploadSymbols(sb, false);
		AppendProfiles(sb, bundleID, profileName);
		sb.Append("</dict>\n");
		sb.Append("</plist>\n");
		return sb.ToString();
	}

	static void AppendTeamID(System.Text.StringBuilder sb, string teamID, string ind = "\t")
	{
		sb.Append(ind).Append("<key>teamID</key>\n");
		AppendPStr(sb, teamID, ind);
	}

	static void AppendMethod(System.Text.StringBuilder sb, string method, string ind = "\t")
	{
		sb.Append(ind).Append("<key>method</key>\n");
		AppendPStr(sb, method, ind);
	}

	static void AppendUploadSymbols(System.Text.StringBuilder sb, bool isUploadSymbols, string ind = "\t")
	{
		sb.Append(ind).Append("<key>uploadSymbols</key>\n");
		AppendPBool(sb, isUploadSymbols, ind);
	}

	static void AppendProfiles(System.Text.StringBuilder sb, string bundleID, string profilesName, string ind = "\t")
	{
		Dictionary<string, string> dic = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(bundleID))
		{
			dic.Add(bundleID, profilesName);
		}
		if (dic.Count > 0)
		{
			sb.Append(ind).Append("<key>provisioningProfiles</key>\n");
			AppendPDict(sb, dic, ind);
		}
	}

	static void AppendPStr(System.Text.StringBuilder sb, string s, string ind)
	{
		sb.Append(ind);
		sb.Append("<string>");
		sb.Append(s);
		sb.Append("</string>\n");
	}

	static void AppendPBool(System.Text.StringBuilder sb, bool b, string ind)
	{
		sb.Append(ind).Append(b ? "<true/>" : "<false/>").Append("\n");
	}

	static void AppendPDict(System.Text.StringBuilder sb, Dictionary<string, string> key_value, string ind)
	{
		sb.Append(ind);
		sb.Append("<dict>");
		foreach (var item in key_value)
		{
			sb.Append("\n").Append(ind);
			sb.Append("<key>");
			sb.Append(item.Key);
			sb.Append("</key>");
			sb.Append("\n").Append(ind);
			sb.Append("<string>");
			sb.Append(item.Value);
			sb.Append("</string>");
		}
		sb.Append("\n").Append(ind);
		sb.Append("</dict>\n");
	}
}