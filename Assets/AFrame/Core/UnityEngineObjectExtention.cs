using UnityEngine;
using XLua;

[LuaCallCSharp]
public static class UnityEngineObjectExtention
{
    public static bool IsNull(this UnityEngine.Object o)
    {
        return o == null;
    }
}