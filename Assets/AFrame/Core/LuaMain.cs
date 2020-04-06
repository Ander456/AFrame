using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using XLua;

[LuaCallCSharp]
public class LuaMain : MonoBehaviour
{
	internal static float lastGCTime = 0;
	internal const float GCInterval = 1;//1 second

	Action _updateFunc = null;
	Action _lateUpdateFunc = null;
	Action _fixedUpdateFunc = null;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		Init();
	}

	public void Init()
	{
		LuaManager.Init(OnInited);
	}

	public void ResetLuaAndLoadScene(string name)
	{
		StartCoroutine(DoResetLuaAndLoadScene(name));
	}

	IEnumerator DoResetLuaAndLoadScene(string name)
	{
		yield return new WaitForEndOfFrame();
		Clear();
		var ui = GameObject.Find("UI/UIRoot");
		var objs = ui.GetComponentsInChildren<LuaBehaviour>(true);
		foreach (var obj in objs)
		{
			GameObject.DestroyImmediate(obj.gameObject);
		}
		LuaManager.Dispose();
		LuaManager.Init(OnInited);
		SceneManager.LoadScene(name);
	}

	void OnInited()
	{
		LuaManager.luaEnv.Global.Get("Update", out _updateFunc);
		LuaManager.luaEnv.Global.Get("LateUpdate", out _lateUpdateFunc);
		LuaManager.luaEnv.Global.Get("FixedUpdate", out _fixedUpdateFunc);
		Debug.Log ("LuaMain OnInited");
	}

	void FixedUpdate()
	{
		if (_fixedUpdateFunc != null)
			_fixedUpdateFunc();
	}

	void LateUpdate()
	{
		if (_lateUpdateFunc != null)
			_lateUpdateFunc();
	}

	void Update()
	{
		if (Time.time - LuaMain.lastGCTime > GCInterval) {
			LuaMain.lastGCTime = Time.time;
			if (LuaManager.luaEnv != null)
				LuaManager.luaEnv.Tick();
		}

		if (_updateFunc != null)
			_updateFunc();
	}

	void Clear()
	{
		_updateFunc = null;
		_lateUpdateFunc = null;
		_fixedUpdateFunc = null;
	}
}
