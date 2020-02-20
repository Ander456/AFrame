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

	private delegate void LuaFunc(LuaTable self);

	private LuaFunc luaAwake;
	private LuaFunc luaStart;
	private LuaFunc luaUpdate;
	private LuaFunc luaOnDestroy;
	private LuaFunc luaOnEnable;
	private LuaFunc luaOnDisable;
	private LuaFunc luaFixedUpdate;
	private LuaFunc luaLateUpdate;

	public void Init(LuaTable table)
	{
		luaTable = table;
		luaScript = table.Get<String>("__cname");

		luaTable.Get("Awake", out luaAwake); 
		luaTable.Get("Start", out luaStart); 
		luaTable.Get("Update", out luaUpdate);
		luaTable.Get("OnDestroy", out luaOnDestroy); 
		luaTable.Get("OnEnable", out luaOnEnable); 
		luaTable.Get("OnDisable", out luaOnDisable); 
		luaTable.Get("FixedUpdate", out luaFixedUpdate); 
		luaTable.Get("LateUpdate", out luaLateUpdate); 

		CallAwake();
	}

	void CallAwake()
	{
		if (luaAwake != null) 
			luaAwake(luaTable);
	}

	void Start()
	{
		if (luaStart != null) 
			luaStart(luaTable);
	}
	
	void Update()
	{
		if (luaUpdate != null) 
			luaUpdate(luaTable);
	}

	void OnDestroy()
	{
		if (luaOnDestroy != null) 
			luaOnDestroy(luaTable);

		luaOnDestroy = null;
		luaAwake = null;
		luaUpdate = null;
		luaStart = null;
		luaOnEnable = null;
		luaOnDisable = null;
		luaFixedUpdate = null;
		luaLateUpdate = null;

		if (luaTable != null) 
			luaTable.Dispose();
	}

	void OnEnable()
	{
		if (luaOnEnable != null)
			luaOnEnable(luaTable);
	}

	void OnDisable()
	{
		if (luaOnDisable != null)
			luaOnDisable(luaTable);
	}

	void FixedUpdate()
	{
		if (luaFixedUpdate != null)
			luaFixedUpdate(luaTable);
	}

	void LateUpdate()
	{
		if (luaLateUpdate != null)
			luaLateUpdate(luaTable);
	}

}
