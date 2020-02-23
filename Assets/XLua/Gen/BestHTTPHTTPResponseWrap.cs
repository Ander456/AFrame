#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class BestHTTPHTTPResponseWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BestHTTP.HTTPResponse);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 17, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHeaderValues", _m_GetHeaderValues);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFirstHeaderValue", _m_GetFirstHeaderValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasHeaderWithValue", _m_HasHeaderWithValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasHeader", _m_HasHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRange", _m_GetRange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetStreamedFragments", _m_GetStreamedFragments);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "VersionMajor", _g_get_VersionMajor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "VersionMinor", _g_get_VersionMinor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StatusCode", _g_get_StatusCode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsSuccess", _g_get_IsSuccess);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Message", _g_get_Message);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsStreamed", _g_get_IsStreamed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsStreamingFinished", _g_get_IsStreamingFinished);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsFromCache", _g_get_IsFromCache);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CacheFileInfo", _g_get_CacheFileInfo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsCacheOnly", _g_get_IsCacheOnly);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Headers", _g_get_Headers);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsUpgraded", _g_get_IsUpgraded);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Cookies", _g_get_Cookies);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DataAsText", _g_get_DataAsText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DataAsTexture2D", _g_get_DataAsTexture2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsClosedManually", _g_get_IsClosedManually);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ReadTo", _m_ReadTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NoTrimReadTo", _m_NoTrimReadTo_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MinBufferSize", BestHTTP.HTTPResponse.MinBufferSize);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "BestHTTP.HTTPResponse does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHeaderValues(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<string> gen_ret = gen_to_be_invoked.GetHeaderValues( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFirstHeaderValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.GetFirstHeaderValue( _name );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasHeaderWithValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _headerName = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.HasHeaderWithValue( _headerName, _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasHeader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _headerName = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.HasHeader( _headerName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        BestHTTP.HTTPRange gen_ret = gen_to_be_invoked.GetRange(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.IO.Stream>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    byte _blocker = (byte)LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = BestHTTP.HTTPResponse.ReadTo( _stream, _blocker );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.IO.Stream>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    byte _blocker1 = (byte)LuaAPI.xlua_tointeger(L, 2);
                    byte _blocker2 = (byte)LuaAPI.xlua_tointeger(L, 3);
                    
                        string gen_ret = BestHTTP.HTTPResponse.ReadTo( _stream, _blocker1, _blocker2 );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPResponse.ReadTo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NoTrimReadTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    byte _blocker1 = (byte)LuaAPI.xlua_tointeger(L, 2);
                    byte _blocker2 = (byte)LuaAPI.xlua_tointeger(L, 3);
                    
                        string gen_ret = BestHTTP.HTTPResponse.NoTrimReadTo( _stream, _blocker1, _blocker2 );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStreamedFragments(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<byte[]> gen_ret = gen_to_be_invoked.GetStreamedFragments(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VersionMajor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.VersionMajor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VersionMinor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.VersionMinor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StatusCode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StatusCode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSuccess(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsSuccess);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Message(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Message);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsStreamed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsStreamed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsStreamingFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsStreamingFinished);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFromCache(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsFromCache);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CacheFileInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CacheFileInfo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCacheOnly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsCacheOnly);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Headers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Headers);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUpgraded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsUpgraded);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cookies(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Cookies);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataAsText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DataAsText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataAsTexture2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.DataAsTexture2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsClosedManually(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPResponse gen_to_be_invoked = (BestHTTP.HTTPResponse)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsClosedManually);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
