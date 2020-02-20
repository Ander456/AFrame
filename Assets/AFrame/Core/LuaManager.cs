using System;
using System.Collections.Generic;
using UnityEngine;
using XAsset;
using XLua;

[LuaCallCSharp]
public class LuaManager
{
	public static LuaEnv luaEnv = new LuaEnv();
    private static Dictionary<string, Asset> assets = new Dictionary<string, Asset>();
	private delegate LuaTable LuaCtor(LuaBehaviour comp);

    public static void Init(Action succes)
    {
        Action onSuccess = delegate
        {
			luaEnv.AddLoader(LuaLoader);
			OnInited(succes);
        };

        Action<string> onError = delegate (string e)
        {
            Debug.LogError(e);
        };

        Assets.Initialize(onSuccess, onError);
    }

    public static void Clear()
    {
        foreach (var item in assets)
        {
            item.Value.Release();
        }
        assets.Clear();
    }

    public static void Dispose()
    {
        Clear();

        luaEnv.Dispose();
        luaEnv = null;
        Debug.Log("[LuaManager]Dispose");
    }

    public static void OnInited(Action cb)
    { 
		luaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
		luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProfobuf);
		luaEnv.AddBuildin("xsocket", XLua.LuaDLL.Lua.LoadXSocket);
        luaEnv.DoString("require 'main'");
        if (cb != null)
        {
            cb.Invoke();
            cb = null;
        }
    }

    private static byte[] LuaLoader(ref string filepath)
    {
		filepath = filepath.Replace(".", "/");

		if (Utility.assetBundleMode)
		{
			var path = "Assets/Bytes/Lua/" + filepath + ".lua.bytes";
			Asset a; 
			if (!assets.TryGetValue(path, out a))
			{
				a = Assets.Load(path, typeof(TextAsset));
				assets[path] = a;
			}
			var ta = a.asset as TextAsset;
			if (ta != null)
			{
				return ta.bytes;
			}
			return null;
		}
		else 
		{
			var path = System.Environment.CurrentDirectory
				+ "/Lua/"
				+ filepath
				+ ".lua";

			if (!System.IO.File.Exists(path))
			{
				throw new System.IO.FileNotFoundException(path);
			}
			return System.IO.File.ReadAllBytes(path);
		}
    }

	public static LuaTable AddLuaComponent(GameObject go, LuaTable luaClass)
	{
		LuaCtor ctor;
		luaClass.Get("new", out ctor);
		if (ctor != null) 
		{
			LuaBehaviour comp = go.AddComponent<LuaBehaviour>();
			LuaTable instance = ctor(comp);
			comp.Init(instance);
			return instance;
		}
		else
		{
			throw new Exception("Lua function new not found");
		}
	}

	public static LuaTable GetLuaComponent(GameObject go, LuaTable table)
	{
		LuaBehaviour[] comps = go.GetComponents<LuaBehaviour>();
		string tableStr = table.ToString();
		for(int i = 0; i < comps.Length;i++)
		{
			if(string.Equals(tableStr, comps[i].luaTable.ToString()))
			{
				return comps[i].luaTable;
			}
		}
		return null;
	}

}
