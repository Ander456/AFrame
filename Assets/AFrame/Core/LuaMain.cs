using UnityEngine;
using XLua;

public class LuaMain : MonoBehaviour
{
	LuaFunction _updateFunc = null;
	LuaFunction _lateUpdateFunc = null;
	LuaFunction _fixedUpdateFunc = null;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		LuaManager.Init(OnInited);
	}

	private void OnInited()
	{
		_updateFunc = LuaManager.GetFunc<LuaFunction>("Update");
		_lateUpdateFunc = LuaManager.GetFunc<LuaFunction>("LateUpdate");
		_fixedUpdateFunc = LuaManager.GetFunc<LuaFunction>("FixedUpdate");
	}

	private void Update()
	{
		if (_updateFunc != null)
		{
			_updateFunc.Call();
		}
	}

	private void FixedUpdate()
	{
		if (_fixedUpdateFunc != null)
		{
			_fixedUpdateFunc.Call();
		}
	}

	private void LateUpdate()
	{
		if (_lateUpdateFunc != null)
		{
			_lateUpdateFunc.Call();
		}
	}
		
	private void SafeDispose(ref LuaFunction func)
	{
		if (func != null)
		{
			func.Dispose();
			func = null;
		}
	}

	private void OnDestroy()
	{
		SafeDispose(ref _updateFunc);
		SafeDispose(ref _lateUpdateFunc);
		SafeDispose(ref _fixedUpdateFunc);

		LuaManager.Dispose();
	}
}
