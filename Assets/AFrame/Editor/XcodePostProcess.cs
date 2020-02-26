using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

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
		// 设置签名证书
		project.SetBuildProperty(targetGuid, "CODE_SIGN_IDENTITY", "Apple Development: 540545947@qq.com (73CV3XMX9K)");
		project.SetBuildProperty(targetGuid, "PROVISIONING_PROFILE", "b6b4ebb8-0b4e-4deb-b357-4b991eada6bb");
		project.SetBuildProperty(targetGuid, "PROVISIONING_PROFILE_SPECIFIER", "iOS Team Provisioning Profile: com.AFrame.AFrame");
		project.SetBuildProperty(targetGuid, "DEVELOPMENT_TEAM", "5Y99JR9625");
		project.SetBuildProperty(targetGuid, "IPHONEOS_DEPLOYMENT_TARGET", "8.0");

		// 添加framework
		project.AddFrameworkToProject(targetGuid, "StoreKit.framework", true);

		// 添加flag
//		project.AddBuildProperty(targetGuid, "OTHER_LDFLAGS", "-ObjC");

		// 修改后的内容写回到配置文件
		File.WriteAllText(projectPath, project.WriteToString());

		// 修改Info.plist文件
		var plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
		var plist = new PlistDocument();
		plist.ReadFromFile(plistPath);

		PlistElementDict rootDict = plist.root;
		// 权限
		rootDict.SetString("NSCameraUsageDescription", "请允许打开摄像头");
		rootDict.SetString("NSMicrophoneUsageDescription", "请允许打开麦克风");

		// 允许http
		var atsKey = "NSAppTransportSecurity";
		PlistElementDict dictTmp = rootDict.CreateDict(atsKey);
		dictTmp.SetBoolean("NSAllowsArbitraryLoads", true);

		// 插入URL Scheme到Info.plsit（理清结构）
		var array = rootDict.CreateArray("CFBundleURLTypes");
		//插入dict
		var urlDict = array.AddDict();
		urlDict.SetString("CFBundleTypeRole", "Editor");
		//插入array
		var urlInnerArray = urlDict.CreateArray("CFBundleURLSchemes");
		urlInnerArray.AddString("blablabla");
	
		// 应用修改
		plist.WriteToFile(plistPath);

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

	public static string GenArchiveOptPlist()
	{
		var path = Application.dataPath.Replace("Assets", "Bin/exportOption.plist");
		var teamId = "BQCHO456";
		// "app-store","enterprise","ad-hoc","development"
		var archiveMethod = "enterprise";
		var bundleId = "com.linxinfa.test";
		var provisionName = "linxinfaEnt2019614";

		GenFile(path, teamId, archiveMethod, bundleId, provisionName);
		return path;
	}
}

public class XClass : System.IDisposable
{
	private string filePath;
	
	public XClass(string fPath)
	{
		filePath = fPath;
		if(!System.IO.File.Exists(filePath)) 
		{
			Debug.LogError(filePath +"路径下文件不存在");
			return;
		}
	}
	
	public void WriteBelow(string below, string text)
	{
		StreamReader streamReader = new StreamReader(filePath);
		string text_all = streamReader.ReadToEnd();
		streamReader.Close();
		
		int beginIndex = text_all.IndexOf(below);
		if(beginIndex == -1)
		{
			Debug.LogError(filePath +"中没有找到标志"+below);
			return; 
		}
		
		int endIndex = text_all.LastIndexOf("\n", beginIndex + below.Length);
		text_all = text_all.Substring(0, endIndex) + "\n"+text+"\n" + text_all.Substring(endIndex);
		StreamWriter streamWriter = new StreamWriter(filePath);
		streamWriter.Write(text_all);
		streamWriter.Close();
	}
	
	public void Replace(string below, string newText)
	{
		StreamReader streamReader = new StreamReader(filePath);
		string text_all = streamReader.ReadToEnd();
		streamReader.Close();
		
		int beginIndex = text_all.IndexOf(below);
		
		if(beginIndex == -1)
		{
			Debug.LogError(filePath +"中没有找到标志"+below);
			return; 
		}
		
		text_all =  text_all.Replace(below,newText);
		StreamWriter streamWriter = new StreamWriter(filePath);
		streamWriter.Write(text_all);
		streamWriter.Close();
	}

	public void Add(string text)
	{
		StreamReader streamReader = new StreamReader(filePath);
		string text_all = streamReader.ReadToEnd();
		streamReader.Close();

		text_all = text_all + "\n" + text;
		StreamWriter streamWriter = new StreamWriter(filePath);
		streamWriter.Write(text_all);
		streamWriter.Close();
	}
	
	public void WriteEnd(string text)
	{
		StreamReader streamReader = new StreamReader(filePath);
		string text_all = streamReader.ReadToEnd();
		streamReader.Close();
		text_all = text_all + "\n" + text;
		StreamWriter streamWriter = new StreamWriter(filePath);
		streamWriter.Write(text_all);
		streamWriter.Close();
	}

	public void Dispose()
	{
	}
}