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
    public class BestHTTPHTTPManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BestHTTP.HTTPManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 6, 18, 17);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Setup", _m_Setup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SendRequest", _m_SendRequest_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetGeneralStatistics", _m_GetGeneralStatistics_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "OnUpdate", _m_OnUpdate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "OnQuit", _m_OnQuit_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MaxConnectionPerServer", _g_get_MaxConnectionPerServer);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "KeepAliveDefaultValue", _g_get_KeepAliveDefaultValue);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "IsCachingDisabled", _g_get_IsCachingDisabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MaxConnectionIdleTime", _g_get_MaxConnectionIdleTime);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "IsCookiesEnabled", _g_get_IsCookiesEnabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "CookieJarSize", _g_get_CookieJarSize);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "EnablePrivateBrowsing", _g_get_EnablePrivateBrowsing);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ConnectTimeout", _g_get_ConnectTimeout);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "RequestTimeout", _g_get_RequestTimeout);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "RootCacheFolderProvider", _g_get_RootCacheFolderProvider);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Proxy", _g_get_Proxy);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Heartbeats", _g_get_Heartbeats);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Logger", _g_get_Logger);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "DefaultCertificateVerifyer", _g_get_DefaultCertificateVerifyer);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "DefaultClientCredentialsProvider", _g_get_DefaultClientCredentialsProvider);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UseAlternateSSLDefaultValue", _g_get_UseAlternateSSLDefaultValue);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "DefaultCertificationValidator", _g_get_DefaultCertificationValidator);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "TryToMinimizeTCPLatency", _g_get_TryToMinimizeTCPLatency);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MaxConnectionPerServer", _s_set_MaxConnectionPerServer);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "KeepAliveDefaultValue", _s_set_KeepAliveDefaultValue);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "IsCachingDisabled", _s_set_IsCachingDisabled);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MaxConnectionIdleTime", _s_set_MaxConnectionIdleTime);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "IsCookiesEnabled", _s_set_IsCookiesEnabled);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "CookieJarSize", _s_set_CookieJarSize);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "EnablePrivateBrowsing", _s_set_EnablePrivateBrowsing);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ConnectTimeout", _s_set_ConnectTimeout);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "RequestTimeout", _s_set_RequestTimeout);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "RootCacheFolderProvider", _s_set_RootCacheFolderProvider);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Proxy", _s_set_Proxy);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Logger", _s_set_Logger);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "DefaultCertificateVerifyer", _s_set_DefaultCertificateVerifyer);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "DefaultClientCredentialsProvider", _s_set_DefaultClientCredentialsProvider);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "UseAlternateSSLDefaultValue", _s_set_UseAlternateSSLDefaultValue);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "DefaultCertificationValidator", _s_set_DefaultCertificationValidator);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "TryToMinimizeTCPLatency", _s_set_TryToMinimizeTCPLatency);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "BestHTTP.HTTPManager does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Setup_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    BestHTTP.HTTPManager.Setup(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendRequest_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<BestHTTP.HTTPRequest>(L, 1)) 
                {
                    BestHTTP.HTTPRequest _request = (BestHTTP.HTTPRequest)translator.GetObject(L, 1, typeof(BestHTTP.HTTPRequest));
                    
                        BestHTTP.HTTPRequest gen_ret = BestHTTP.HTTPManager.SendRequest( _request );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 2)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 1);
                    BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 2);
                    
                        BestHTTP.HTTPRequest gen_ret = BestHTTP.HTTPManager.SendRequest( _url, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<BestHTTP.HTTPMethods>(L, 2)&& translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 3)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 1);
                    BestHTTP.HTTPMethods _methodType;translator.Get(L, 2, out _methodType);
                    BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 3);
                    
                        BestHTTP.HTTPRequest gen_ret = BestHTTP.HTTPManager.SendRequest( _url, _methodType, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<BestHTTP.HTTPMethods>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 4)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 1);
                    BestHTTP.HTTPMethods _methodType;translator.Get(L, 2, out _methodType);
                    bool _isKeepAlive = LuaAPI.lua_toboolean(L, 3);
                    BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 4);
                    
                        BestHTTP.HTTPRequest gen_ret = BestHTTP.HTTPManager.SendRequest( _url, _methodType, _isKeepAlive, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<BestHTTP.HTTPMethods>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 5)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 1);
                    BestHTTP.HTTPMethods _methodType;translator.Get(L, 2, out _methodType);
                    bool _isKeepAlive = LuaAPI.lua_toboolean(L, 3);
                    bool _disableCache = LuaAPI.lua_toboolean(L, 4);
                    BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 5);
                    
                        BestHTTP.HTTPRequest gen_ret = BestHTTP.HTTPManager.SendRequest( _url, _methodType, _isKeepAlive, _disableCache, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPManager.SendRequest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGeneralStatistics_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    BestHTTP.Statistics.StatisticsQueryFlags _queryFlags;translator.Get(L, 1, out _queryFlags);
                    
                        BestHTTP.Statistics.GeneralStatistics gen_ret = BestHTTP.HTTPManager.GetGeneralStatistics( _queryFlags );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnUpdate_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    BestHTTP.HTTPManager.OnUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnQuit_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    BestHTTP.HTTPManager.OnQuit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxConnectionPerServer(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, BestHTTP.HTTPManager.MaxConnectionPerServer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KeepAliveDefaultValue(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.KeepAliveDefaultValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCachingDisabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.IsCachingDisabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxConnectionIdleTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.MaxConnectionIdleTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCookiesEnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.IsCookiesEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CookieJarSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushuint(L, BestHTTP.HTTPManager.CookieJarSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnablePrivateBrowsing(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.EnablePrivateBrowsing);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConnectTimeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.ConnectTimeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RequestTimeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.RequestTimeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RootCacheFolderProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.RootCacheFolderProvider);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Proxy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.Proxy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Heartbeats(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.Heartbeats);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Logger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, BestHTTP.HTTPManager.Logger);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultCertificateVerifyer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, BestHTTP.HTTPManager.DefaultCertificateVerifyer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultClientCredentialsProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, BestHTTP.HTTPManager.DefaultClientCredentialsProvider);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseAlternateSSLDefaultValue(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.UseAlternateSSLDefaultValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultCertificationValidator(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BestHTTP.HTTPManager.DefaultCertificationValidator);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TryToMinimizeTCPLatency(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, BestHTTP.HTTPManager.TryToMinimizeTCPLatency);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxConnectionPerServer(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.MaxConnectionPerServer = (byte)LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KeepAliveDefaultValue(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.KeepAliveDefaultValue = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCachingDisabled(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.IsCachingDisabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxConnectionIdleTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.TimeSpan gen_value;translator.Get(L, 1, out gen_value);
				BestHTTP.HTTPManager.MaxConnectionIdleTime = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCookiesEnabled(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.IsCookiesEnabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CookieJarSize(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.CookieJarSize = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnablePrivateBrowsing(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.EnablePrivateBrowsing = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConnectTimeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.TimeSpan gen_value;translator.Get(L, 1, out gen_value);
				BestHTTP.HTTPManager.ConnectTimeout = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RequestTimeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.TimeSpan gen_value;translator.Get(L, 1, out gen_value);
				BestHTTP.HTTPManager.RequestTimeout = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RootCacheFolderProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.RootCacheFolderProvider = translator.GetDelegate<System.Func<string>>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Proxy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.Proxy = (BestHTTP.HTTPProxy)translator.GetObject(L, 1, typeof(BestHTTP.HTTPProxy));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Logger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.Logger = (BestHTTP.Logger.ILogger)translator.GetObject(L, 1, typeof(BestHTTP.Logger.ILogger));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultCertificateVerifyer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.DefaultCertificateVerifyer = (Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer)translator.GetObject(L, 1, typeof(Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultClientCredentialsProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.DefaultClientCredentialsProvider = (Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider)translator.GetObject(L, 1, typeof(Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseAlternateSSLDefaultValue(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.UseAlternateSSLDefaultValue = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DefaultCertificationValidator(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BestHTTP.HTTPManager.DefaultCertificationValidator = translator.GetDelegate<System.Func<BestHTTP.HTTPRequest, System.Security.Cryptography.X509Certificates.X509Certificate, System.Security.Cryptography.X509Certificates.X509Chain, bool>>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TryToMinimizeTCPLatency(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPManager.TryToMinimizeTCPLatency = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
