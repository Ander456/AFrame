#ifndef __LUA_SOCKET_H__
#define __LUA_SOCKET_H__

#define olua_postpush(L, v, s) ((void)L, (void)v, (void)s)

#include "olua/olua.hpp"

#ifdef __cplusplus
extern "C" {
#endif
LUALIB_API int luaopen_socket(lua_State *L);
#ifdef __cplusplus
}
#endif

#endif
