using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using XLua;

[LuaCallCSharp]
public class LuaBehaviour : MonoBehaviour
{
	public String luaScript;
	public LuaTable luaTable;

	private LuaFunction luaAwake;
	private LuaFunction luaStart;
	private LuaFunction luaUpdate;
	private LuaFunction luaOnDestroy;
	private LuaFunction luaOnEnable;
	private LuaFunction luaOnDisable;
	private LuaFunction luaFixedUpdate;
	private LuaFunction luaLateUpdate;

	public void Init(LuaTable table)
	{
		luaTable = table;
		luaScript = table.Get<String>("__cname");

		luaAwake = luaTable.Get<LuaFunction>("Awake"); 
		luaStart = luaTable.Get<LuaFunction>("Start"); 
		luaUpdate = luaTable.Get<LuaFunction>("Update"); 
		luaOnDestroy = luaTable.Get<LuaFunction>("OnDestroy"); 
		luaOnEnable = luaTable.Get<LuaFunction>("OnEnable"); 
		luaOnDisable = luaTable.Get<LuaFunction>("OnDisable"); 
		luaFixedUpdate = luaTable.Get<LuaFunction>("FixedUpdate"); 
		luaLateUpdate = luaTable.Get<LuaFunction>("LateUpdate"); 

		CallAwake();
	}

	void CallAwake()
	{
		if (luaAwake != null) 
			luaAwake.Call(luaTable);
	}

	void Start()
	{
		if (luaStart != null) 
			luaStart.Call(luaTable);
	}
	
	void Update()
	{
		if (luaUpdate != null) 
			luaUpdate.Call(luaTable);
	}

	void OnDestroy()
	{
		if (luaOnDestroy != null) 
			luaOnDestroy.Call(luaTable);

		SafeDispose(ref luaOnDestroy);
		SafeDispose(ref luaOnDestroy);
		SafeDispose(ref luaUpdate);
		SafeDispose(ref luaStart);
		SafeDispose(ref luaOnEnable);
		SafeDispose(ref luaOnDisable);
		SafeDispose(ref luaFixedUpdate);
		SafeDispose(ref luaLateUpdate);

		if (luaTable != null) 
			luaTable.Dispose();
	}

	void OnEnable()
	{
		if (luaOnEnable != null)
			luaOnEnable.Call(luaTable);
	}

	void OnDisable()
	{
		if (luaOnDisable != null)
			luaOnDisable.Call(luaTable);
	}

	void FixedUpdate()
	{
		if (luaFixedUpdate != null)
			luaFixedUpdate.Call(luaTable);
	}

	void LateUpdate()
	{
		if (luaLateUpdate != null)
			luaLateUpdate.Call(luaTable);
	}

	void SafeDispose(ref LuaFunction func)
	{
		if (func != null)
		{
			func.Dispose();
			func = null;
		}
	}
}
