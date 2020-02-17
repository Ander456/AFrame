using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class Utils {
	
	public static byte[] UTF8GetBytes(string str)
	{
		return System.Text.Encoding.UTF8.GetBytes(str);
	}
}
