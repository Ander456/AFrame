namespace XLua.LuaDLL
{
    using System.Runtime.InteropServices;

    public partial class Lua
    {
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_cjson(System.IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_pb(System.IntPtr L);

    		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_yasio(System.IntPtr L);

        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadCJson(System.IntPtr L)
        {
            return luaopen_cjson(L);
        }

        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadLuaProfobuf(System.IntPtr L)
        {
            return luaopen_pb(L);
        }

        [MonoPInvokeCallback(typeof(LuaDLL.lua_CSFunction))]
        public static int LoadYasio(System.IntPtr L)
        {
            return luaopen_yasio(L);
        }
    }
}
