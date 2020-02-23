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
    public class BestHTTPHTTPRequestWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BestHTTP.HTTPRequest);
			Utils.BeginObjectRegister(type, L, translator, 0, 24, 43, 32);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddField", _m_AddField);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddBinaryData", _m_AddBinaryData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFields", _m_SetFields);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetForm", _m_SetForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearForm", _m_ClearForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddHeader", _m_AddHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetHeader", _m_SetHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveHeader", _m_RemoveHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasHeader", _m_HasHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFirstHeaderValue", _m_GetFirstHeaderValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHeaderValues", _m_GetHeaderValues);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveHeaders", _m_RemoveHeaders);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRangeHeader", _m_SetRangeHeader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnumerateHeaders", _m_EnumerateHeaders);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DumpHeaders", _m_DumpHeaders);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Send", _m_Send);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Abort", _m_Abort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveNext", _m_MoveNext);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reset", _m_Reset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CustomCertificationValidator", _e_CustomCertificationValidator);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeRedirection", _e_OnBeforeRedirection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeHeaderSend", _e_OnBeforeHeaderSend);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Uri", _g_get_Uri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MethodType", _g_get_MethodType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RawData", _g_get_RawData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UploadStream", _g_get_UploadStream);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DisposeUploadStream", _g_get_DisposeUploadStream);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UseUploadStreamLength", _g_get_UseUploadStreamLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsKeepAlive", _g_get_IsKeepAlive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DisableCache", _g_get_DisableCache);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CacheOnly", _g_get_CacheOnly);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UseStreaming", _g_get_UseStreaming);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StreamFragmentSize", _g_get_StreamFragmentSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Callback", _g_get_Callback);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DisableRetry", _g_get_DisableRetry);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsRedirected", _g_get_IsRedirected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RedirectUri", _g_get_RedirectUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurrentUri", _g_get_CurrentUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Response", _g_get_Response);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ProxyResponse", _g_get_ProxyResponse);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Exception", _g_get_Exception);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Tag", _g_get_Tag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Credentials", _g_get_Credentials);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HasProxy", _g_get_HasProxy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Proxy", _g_get_Proxy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxRedirects", _g_get_MaxRedirects);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UseAlternateSSL", _g_get_UseAlternateSSL);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsCookiesEnabled", _g_get_IsCookiesEnabled);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Cookies", _g_get_Cookies);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FormUsage", _g_get_FormUsage);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "State", _g_get_State);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RedirectCount", _g_get_RedirectCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ConnectTimeout", _g_get_ConnectTimeout);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Timeout", _g_get_Timeout);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnableTimoutForStreaming", _g_get_EnableTimoutForStreaming);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnableSafeReadOnUnknownContentLength", _g_get_EnableSafeReadOnUnknownContentLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Priority", _g_get_Priority);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CustomCertificateVerifyer", _g_get_CustomCertificateVerifyer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CustomClientCredentialsProvider", _g_get_CustomClientCredentialsProvider);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ProtocolHandler", _g_get_ProtocolHandler);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TryToMinimizeTCPLatency", _g_get_TryToMinimizeTCPLatency);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Current", _g_get_Current);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnUploadProgress", _g_get_OnUploadProgress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnProgress", _g_get_OnProgress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnUpgraded", _g_get_OnUpgraded);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "MethodType", _s_set_MethodType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RawData", _s_set_RawData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UploadStream", _s_set_UploadStream);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DisposeUploadStream", _s_set_DisposeUploadStream);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UseUploadStreamLength", _s_set_UseUploadStreamLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "IsKeepAlive", _s_set_IsKeepAlive);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DisableCache", _s_set_DisableCache);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CacheOnly", _s_set_CacheOnly);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UseStreaming", _s_set_UseStreaming);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "StreamFragmentSize", _s_set_StreamFragmentSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Callback", _s_set_Callback);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DisableRetry", _s_set_DisableRetry);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Tag", _s_set_Tag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Credentials", _s_set_Credentials);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Proxy", _s_set_Proxy);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaxRedirects", _s_set_MaxRedirects);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UseAlternateSSL", _s_set_UseAlternateSSL);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "IsCookiesEnabled", _s_set_IsCookiesEnabled);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Cookies", _s_set_Cookies);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FormUsage", _s_set_FormUsage);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ConnectTimeout", _s_set_ConnectTimeout);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Timeout", _s_set_Timeout);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EnableTimoutForStreaming", _s_set_EnableTimoutForStreaming);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EnableSafeReadOnUnknownContentLength", _s_set_EnableSafeReadOnUnknownContentLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Priority", _s_set_Priority);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CustomCertificateVerifyer", _s_set_CustomCertificateVerifyer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CustomClientCredentialsProvider", _s_set_CustomClientCredentialsProvider);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ProtocolHandler", _s_set_ProtocolHandler);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TryToMinimizeTCPLatency", _s_set_TryToMinimizeTCPLatency);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnUploadProgress", _s_set_OnUploadProgress);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnProgress", _s_set_OnProgress);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnUpgraded", _s_set_OnUpgraded);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 1, 1);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EOL", BestHTTP.HTTPRequest.EOL);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MethodNames", BestHTTP.HTTPRequest.MethodNames);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UploadChunkSize", _g_get_UploadChunkSize);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "UploadChunkSize", _s_set_UploadChunkSize);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Uri>(L, 2))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 3))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 3);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<System.Uri>(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 4))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					bool _isKeepAlive = LuaAPI.lua_toboolean(L, 3);
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 4);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _isKeepAlive, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<System.Uri>(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 5))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					bool _isKeepAlive = LuaAPI.lua_toboolean(L, 3);
					bool _disableCache = LuaAPI.lua_toboolean(L, 4);
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 5);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _isKeepAlive, _disableCache, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<BestHTTP.HTTPMethods>(L, 3))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					BestHTTP.HTTPMethods _methodType;translator.Get(L, 3, out _methodType);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _methodType);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<BestHTTP.HTTPMethods>(L, 3) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 4))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					BestHTTP.HTTPMethods _methodType;translator.Get(L, 3, out _methodType);
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 4);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _methodType, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<BestHTTP.HTTPMethods>(L, 3) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 5))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					BestHTTP.HTTPMethods _methodType;translator.Get(L, 3, out _methodType);
					bool _isKeepAlive = LuaAPI.lua_toboolean(L, 4);
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 5);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _methodType, _isKeepAlive, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 6 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<BestHTTP.HTTPMethods>(L, 3) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5) && translator.Assignable<BestHTTP.OnRequestFinishedDelegate>(L, 6))
				{
					System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					BestHTTP.HTTPMethods _methodType;translator.Get(L, 3, out _methodType);
					bool _isKeepAlive = LuaAPI.lua_toboolean(L, 4);
					bool _disableCache = LuaAPI.lua_toboolean(L, 5);
					BestHTTP.OnRequestFinishedDelegate _callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 6);
					
					BestHTTP.HTTPRequest gen_ret = new BestHTTP.HTTPRequest(_uri, _methodType, _isKeepAlive, _disableCache, _callback);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddField(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fieldName = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.AddField( _fieldName, _value );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Text.Encoding>(L, 4)) 
                {
                    string _fieldName = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    System.Text.Encoding _e = (System.Text.Encoding)translator.GetObject(L, 4, typeof(System.Text.Encoding));
                    
                    gen_to_be_invoked.AddField( _fieldName, _value, _e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.AddField!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBinaryData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fieldName = LuaAPI.lua_tostring(L, 2);
                    byte[] _content = LuaAPI.lua_tobytes(L, 3);
                    
                    gen_to_be_invoked.AddBinaryData( _fieldName, _content );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fieldName = LuaAPI.lua_tostring(L, 2);
                    byte[] _content = LuaAPI.lua_tobytes(L, 3);
                    string _fileName = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.AddBinaryData( _fieldName, _content, _fileName );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fieldName = LuaAPI.lua_tostring(L, 2);
                    byte[] _content = LuaAPI.lua_tobytes(L, 3);
                    string _fileName = LuaAPI.lua_tostring(L, 4);
                    string _mimeType = LuaAPI.lua_tostring(L, 5);
                    
                    gen_to_be_invoked.AddBinaryData( _fieldName, _content, _fileName, _mimeType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.AddBinaryData!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFields(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.WWWForm _wwwForm = (UnityEngine.WWWForm)translator.GetObject(L, 2, typeof(UnityEngine.WWWForm));
                    
                    gen_to_be_invoked.SetFields( _wwwForm );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BestHTTP.Forms.HTTPFormBase _form = (BestHTTP.Forms.HTTPFormBase)translator.GetObject(L, 2, typeof(BestHTTP.Forms.HTTPFormBase));
                    
                    gen_to_be_invoked.SetForm( _form );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearForm(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddHeader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.AddHeader( _name, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHeader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.SetHeader( _name, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveHeader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveHeader( _name );
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
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.HasHeader( _name );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
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
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetHeaderValues(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_RemoveHeaders(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RemoveHeaders(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRangeHeader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _firstBytePos = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetRangeHeader( _firstBytePos );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int _firstBytePos = LuaAPI.xlua_tointeger(L, 2);
                    int _lastBytePos = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.SetRangeHeader( _firstBytePos, _lastBytePos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.SetRangeHeader!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnumerateHeaders(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<BestHTTP.OnHeaderEnumerationDelegate>(L, 2)) 
                {
                    BestHTTP.OnHeaderEnumerationDelegate _callback = translator.GetDelegate<BestHTTP.OnHeaderEnumerationDelegate>(L, 2);
                    
                    gen_to_be_invoked.EnumerateHeaders( _callback );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<BestHTTP.OnHeaderEnumerationDelegate>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    BestHTTP.OnHeaderEnumerationDelegate _callback = translator.GetDelegate<BestHTTP.OnHeaderEnumerationDelegate>(L, 2);
                    bool _callBeforeSendCallback = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.EnumerateHeaders( _callback, _callBeforeSendCallback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.EnumerateHeaders!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DumpHeaders(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.DumpHeaders(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        BestHTTP.HTTPRequest gen_ret = gen_to_be_invoked.Send(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Abort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Abort(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveNext(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.MoveNext(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
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
            
            
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Uri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Uri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MethodType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushBestHTTPHTTPMethods(L, gen_to_be_invoked.MethodType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.RawData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UploadStream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.UploadStream);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DisposeUploadStream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.DisposeUploadStream);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseUploadStreamLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.UseUploadStreamLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsKeepAlive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsKeepAlive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DisableCache(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.DisableCache);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CacheOnly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.CacheOnly);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseStreaming(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.UseStreaming);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StreamFragmentSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StreamFragmentSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Callback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Callback);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DisableRetry(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.DisableRetry);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsRedirected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsRedirected);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RedirectUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RedirectUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CurrentUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Response(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Response);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ProxyResponse(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ProxyResponse);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Exception(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Exception);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.Tag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Credentials(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Credentials);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasProxy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.HasProxy);
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
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Proxy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxRedirects(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxRedirects);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseAlternateSSL(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.UseAlternateSSL);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCookiesEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsCookiesEnabled);
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
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Cookies);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FormUsage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.FormUsage);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushBestHTTPHTTPRequestStates(L, gen_to_be_invoked.State);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RedirectCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RedirectCount);
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
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ConnectTimeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Timeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Timeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnableTimoutForStreaming(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.EnableTimoutForStreaming);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnableSafeReadOnUnknownContentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.EnableSafeReadOnUnknownContentLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Priority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CustomCertificateVerifyer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.CustomCertificateVerifyer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CustomClientCredentialsProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.CustomClientCredentialsProvider);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ProtocolHandler(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ProtocolHandler);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TryToMinimizeTCPLatency(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.TryToMinimizeTCPLatency);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, gen_to_be_invoked.Current);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UploadChunkSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, BestHTTP.HTTPRequest.UploadChunkSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnUploadProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnUploadProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnUpgraded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnUpgraded);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MethodType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                BestHTTP.HTTPMethods gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.MethodType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RawData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RawData = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UploadStream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UploadStream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DisposeUploadStream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DisposeUploadStream = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseUploadStreamLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UseUploadStreamLength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsKeepAlive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.IsKeepAlive = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DisableCache(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DisableCache = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CacheOnly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CacheOnly = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseStreaming(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UseStreaming = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StreamFragmentSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.StreamFragmentSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Callback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Callback = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DisableRetry(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DisableRetry = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Tag = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Credentials(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Credentials = (BestHTTP.Authentication.Credentials)translator.GetObject(L, 2, typeof(BestHTTP.Authentication.Credentials));
            
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
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Proxy = (BestHTTP.HTTPProxy)translator.GetObject(L, 2, typeof(BestHTTP.HTTPProxy));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxRedirects(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaxRedirects = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseAlternateSSL(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UseAlternateSSL = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCookiesEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.IsCookiesEnabled = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Cookies(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Cookies = (System.Collections.Generic.List<BestHTTP.Cookies.Cookie>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<BestHTTP.Cookies.Cookie>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FormUsage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                BestHTTP.Forms.HTTPFormUsage gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.FormUsage = gen_value;
            
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
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                System.TimeSpan gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.ConnectTimeout = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Timeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                System.TimeSpan gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Timeout = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableTimoutForStreaming(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.EnableTimoutForStreaming = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableSafeReadOnUnknownContentLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.EnableSafeReadOnUnknownContentLength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Priority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Priority = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CustomCertificateVerifyer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CustomCertificateVerifyer = (Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer)translator.GetObject(L, 2, typeof(Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CustomClientCredentialsProvider(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CustomClientCredentialsProvider = (Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider)translator.GetObject(L, 2, typeof(Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ProtocolHandler(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                BestHTTP.SupportedProtocols gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.ProtocolHandler = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TryToMinimizeTCPLatency(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TryToMinimizeTCPLatency = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UploadChunkSize(RealStatePtr L)
        {
		    try {
                
			    BestHTTP.HTTPRequest.UploadChunkSize = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnUploadProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnUploadProgress = translator.GetDelegate<BestHTTP.OnUploadProgressDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnProgress = translator.GetDelegate<BestHTTP.OnDownloadProgressDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnUpgraded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnUpgraded = translator.GetDelegate<BestHTTP.OnRequestFinishedDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_CustomCertificationValidator(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                System.Func<BestHTTP.HTTPRequest, System.Security.Cryptography.X509Certificates.X509Certificate, System.Security.Cryptography.X509Certificates.X509Chain, bool> gen_delegate = translator.GetDelegate<System.Func<BestHTTP.HTTPRequest, System.Security.Cryptography.X509Certificates.X509Certificate, System.Security.Cryptography.X509Certificates.X509Chain, bool>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Func<BestHTTP.HTTPRequest, System.Security.Cryptography.X509Certificates.X509Certificate, System.Security.Cryptography.X509Certificates.X509Chain, bool>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.CustomCertificationValidator += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.CustomCertificationValidator -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.CustomCertificationValidator!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeRedirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                BestHTTP.OnBeforeRedirectionDelegate gen_delegate = translator.GetDelegate<BestHTTP.OnBeforeRedirectionDelegate>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need BestHTTP.OnBeforeRedirectionDelegate!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeRedirection += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeRedirection -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.OnBeforeRedirection!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnBeforeHeaderSend(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			BestHTTP.HTTPRequest gen_to_be_invoked = (BestHTTP.HTTPRequest)translator.FastGetCSObj(L, 1);
                BestHTTP.OnBeforeHeaderSendDelegate gen_delegate = translator.GetDelegate<BestHTTP.OnBeforeHeaderSendDelegate>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need BestHTTP.OnBeforeHeaderSendDelegate!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnBeforeHeaderSend += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnBeforeHeaderSend -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to BestHTTP.HTTPRequest.OnBeforeHeaderSend!");
            return 0;
        }
        
		
		
    }
}
