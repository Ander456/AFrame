using UnityEngine;
using System;
using XLua;

public class LuaMain : MonoBehaviour
{
	Action _updateFunc = null;
	Action _lateUpdateFunc = null;
	Action _fixedUpdateFunc = null;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
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
		{
			_updateFunc();
		}
	}

	private void FixedUpdate()
	{
		if (_fixedUpdateFunc != null)
		{
			_fixedUpdateFunc();
		}
	}

	private void LateUpdate()
	{
		if (_lateUpdateFunc != null)
		{
			_lateUpdateFunc();
		}
	}
		
	private void OnDestroy()
	{
		_updateFunc = null;
		_lateUpdateFunc = null;
		_fixedUpdateFunc = null;
	}
}
