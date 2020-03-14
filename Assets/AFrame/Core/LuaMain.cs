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

	private void OnInited()
	{
		Debug.Log ("LuaMian OnInited");
	}

	private void Update()
	{
		if (Time.time - LuaMain.lastGCTime > GCInterval) {
			LuaMain.lastGCTime = Time.time;
			if (LuaManager.luaEnv != null)
				LuaManager.luaEnv.Tick();
		}
	}
}
