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
    public class SystemUriWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(System.Uri);
			Utils.BeginObjectRegister(type, L, translator, 1, 8, 21, 0);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLeftPart", _m_GetLeftPart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MakeRelativeUri", _m_MakeRelativeUri);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetComponents", _m_GetComponents);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsBaseOf", _m_IsBaseOf);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsWellFormedOriginalString", _m_IsWellFormedOriginalString);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "AbsolutePath", _g_get_AbsolutePath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AbsoluteUri", _g_get_AbsoluteUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Authority", _g_get_Authority);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Fragment", _g_get_Fragment);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Host", _g_get_Host);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HostNameType", _g_get_HostNameType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsDefaultPort", _g_get_IsDefaultPort);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsFile", _g_get_IsFile);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsLoopback", _g_get_IsLoopback);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsUnc", _g_get_IsUnc);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LocalPath", _g_get_LocalPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PathAndQuery", _g_get_PathAndQuery);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Port", _g_get_Port);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Query", _g_get_Query);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Scheme", _g_get_Scheme);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Segments", _g_get_Segments);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UserEscaped", _g_get_UserEscaped);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UserInfo", _g_get_UserInfo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DnsSafeHost", _g_get_DnsSafeHost);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAbsoluteUri", _g_get_IsAbsoluteUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OriginalString", _g_get_OriginalString);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 25, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckHostName", _m_CheckHostName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckSchemeName", _m_CheckSchemeName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromHex", _m_FromHex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HexEscape", _m_HexEscape_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HexUnescape", _m_HexUnescape_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsHexDigit", _m_IsHexDigit_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsHexEncoding", _m_IsHexEncoding_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Compare", _m_Compare_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EscapeDataString", _m_EscapeDataString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EscapeUriString", _m_EscapeUriString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsWellFormedUriString", _m_IsWellFormedUriString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryCreate", _m_TryCreate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnescapeDataString", _m_UnescapeDataString_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SchemeDelimiter", System.Uri.SchemeDelimiter);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeFile", System.Uri.UriSchemeFile);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeFtp", System.Uri.UriSchemeFtp);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeGopher", System.Uri.UriSchemeGopher);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeHttp", System.Uri.UriSchemeHttp);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeHttps", System.Uri.UriSchemeHttps);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeMailto", System.Uri.UriSchemeMailto);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeNews", System.Uri.UriSchemeNews);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeNntp", System.Uri.UriSchemeNntp);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeNetPipe", System.Uri.UriSchemeNetPipe);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UriSchemeNetTcp", System.Uri.UriSchemeNetTcp);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _uriString = LuaAPI.lua_tostring(L, 2);
					
					System.Uri gen_ret = new System.Uri(_uriString);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && translator.Assignable<System.UriKind>(L, 3))
				{
					string _uriString = LuaAPI.lua_tostring(L, 2);
					System.UriKind _uriKind;translator.Get(L, 3, out _uriKind);
					
					System.Uri gen_ret = new System.Uri(_uriString, _uriKind);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Uri>(L, 2) && translator.Assignable<System.Uri>(L, 3))
				{
					System.Uri _baseUri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					System.Uri _relativeUri = (System.Uri)translator.GetObject(L, 3, typeof(System.Uri));
					
					System.Uri gen_ret = new System.Uri(_baseUri, _relativeUri);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Uri>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					System.Uri _baseUri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					string _relativeUri = LuaAPI.lua_tostring(L, 3);
					
					System.Uri gen_ret = new System.Uri(_baseUri, _relativeUri);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.Uri constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<System.Uri>(L, 1) && translator.Assignable<System.Uri>(L, 2))
				{
					System.Uri leftside = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
					System.Uri rightside = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need System.Uri!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckHostName_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        System.UriHostNameType gen_ret = System.Uri.CheckHostName( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSchemeName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _schemeName = LuaAPI.lua_tostring(L, 1);
                    
                        bool gen_ret = System.Uri.CheckSchemeName( _schemeName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _comparant = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( _comparant );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLeftPart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.UriPartial _part;translator.Get(L, 2, out _part);
                    
                        string gen_ret = gen_to_be_invoked.GetLeftPart( _part );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromHex_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    char _digit = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        int gen_ret = System.Uri.FromHex( _digit );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HexEscape_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    char _character = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        string gen_ret = System.Uri.HexEscape( _character );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HexUnescape_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _pattern = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        char gen_ret = System.Uri.HexUnescape( _pattern, ref _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _index);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHexDigit_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    char _digit = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        bool gen_ret = System.Uri.IsHexDigit( _digit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHexEncoding_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _pattern = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool gen_ret = System.Uri.IsHexEncoding( _pattern, _index );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeRelativeUri(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
                    
                        System.Uri gen_ret = gen_to_be_invoked.MakeRelativeUri( _uri );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponents(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.UriComponents _components;translator.Get(L, 2, out _components);
                    System.UriFormat _format;translator.Get(L, 3, out _format);
                    
                        string gen_ret = gen_to_be_invoked.GetComponents( _components, _format );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBaseOf(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Uri _uri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
                    
                        bool gen_ret = gen_to_be_invoked.IsBaseOf( _uri );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWellFormedOriginalString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsWellFormedOriginalString(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Compare_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Uri _uri1 = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    System.Uri _uri2 = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
                    System.UriComponents _partsToCompare;translator.Get(L, 3, out _partsToCompare);
                    System.UriFormat _compareFormat;translator.Get(L, 4, out _compareFormat);
                    System.StringComparison _comparisonType;translator.Get(L, 5, out _comparisonType);
                    
                        int gen_ret = System.Uri.Compare( _uri1, _uri2, _partsToCompare, _compareFormat, _comparisonType );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EscapeDataString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _stringToEscape = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = System.Uri.EscapeDataString( _stringToEscape );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EscapeUriString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _stringToEscape = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = System.Uri.EscapeUriString( _stringToEscape );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWellFormedUriString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _uriString = LuaAPI.lua_tostring(L, 1);
                    System.UriKind _uriKind;translator.Get(L, 2, out _uriKind);
                    
                        bool gen_ret = System.Uri.IsWellFormedUriString( _uriString, _uriKind );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryCreate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.UriKind>(L, 2)) 
                {
                    string _uriString = LuaAPI.lua_tostring(L, 1);
                    System.UriKind _uriKind;translator.Get(L, 2, out _uriKind);
                    System.Uri _result;
                    
                        bool gen_ret = System.Uri.TryCreate( _uriString, _uriKind, out _result );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _result);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Uri _baseUri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    string _relativeUri = LuaAPI.lua_tostring(L, 2);
                    System.Uri _result;
                    
                        bool gen_ret = System.Uri.TryCreate( _baseUri, _relativeUri, out _result );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _result);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Uri>(L, 1)&& translator.Assignable<System.Uri>(L, 2)) 
                {
                    System.Uri _baseUri = (System.Uri)translator.GetObject(L, 1, typeof(System.Uri));
                    System.Uri _relativeUri = (System.Uri)translator.GetObject(L, 2, typeof(System.Uri));
                    System.Uri _result;
                    
                        bool gen_ret = System.Uri.TryCreate( _baseUri, _relativeUri, out _result );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _result);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Uri.TryCreate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnescapeDataString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _stringToUnescape = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = System.Uri.UnescapeDataString( _stringToUnescape );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AbsolutePath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AbsolutePath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AbsoluteUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AbsoluteUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Authority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Authority);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Fragment(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Fragment);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Host(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Host);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HostNameType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.HostNameType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsDefaultPort(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsDefaultPort);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsFile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLoopback(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsLoopback);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUnc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsUnc);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.LocalPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathAndQuery(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.PathAndQuery);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Port(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Port);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Query(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Query);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Scheme(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Scheme);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Segments(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Segments);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserEscaped(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.UserEscaped);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.UserInfo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DnsSafeHost(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DnsSafeHost);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAbsoluteUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAbsoluteUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OriginalString(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                System.Uri gen_to_be_invoked = (System.Uri)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.OriginalString);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
