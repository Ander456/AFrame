using UnityEngine;
using System;
using XLua;

[LuaCallCSharp]
public class LuaMain : MonoBehaviour
{
	Action _updateFunc = null;
	Action _lateUpdateFunc = null;
	Action _fixedUpdateFunc = null;

	internal static float lastGCTime = 0;
	internal const float GCInterval = 1;//1 second

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		Init();
	}

	public void Init()
	{
		LuaManager.Init(OnInited);
	}

	private void OnInited()
	{
		LuaManager.luaEnv.Global.Get("Update", out _updateFunc);
		LuaManager.luaEnv.Global.Get("LateUpdate", out _lateUpdateFunc);
		LuaManager.luaEnv.Global.Get("FixedUpdate", out _fixedUpdateFunc);
	}

	private void Update()
	{
		if (_updateFunc != null)
			_updateFunc();
		
		if (Time.time - LuaMain.lastGCTime > GCInterval) {
			LuaMain.lastGCTime = Time.time;
			if (LuaManager.luaEnv != null)
				LuaManager.luaEnv.Tick();
		}
	}

	private void FixedUpdate()
	{
		if (_fixedUpdateFunc != null)
			_fixedUpdateFunc();
	}

	private void LateUpdate()
	{
		if (_lateUpdateFunc != null)
			_lateUpdateFunc();
	}

	public void Clear()
	{
		_updateFunc = null;
		_lateUpdateFunc = null;
		_fixedUpdateFunc = null;
	}
		
	private void OnDestroy()
	{
		Clear();
	}
}
