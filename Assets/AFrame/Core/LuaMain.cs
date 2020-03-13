using UnityEngine;
using System;

public class LuaMain : MonoBehaviour
{
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
		Clear();
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

	private void Clear()
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
