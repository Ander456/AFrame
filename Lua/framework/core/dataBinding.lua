local observe
local subscribe

observe = function( s )
	local c, mt = {}
    mt = {
    	__bind__ = {},
        __index = function(_, k)
            return mt[k]
        end,
        __newindex = function(_, k, v)
            local o = mt[k]
      		if o ~= v then
      			mt[k] = v
      			for i, e in pairs( mt.__bind__[k] or {} ) do
      				e(v, o)
      			end
      		end
        end
    }
    setmetatable(c, mt)
    for k, v in pairs( s ) do
		if type(v) == "table" then
			c[k] = observe(v)
		else
			c[k] = s[k]
		end
	end
    return c
end

subscribe = function( t, k, f )
	local b = t.__bind__
	if not b[k] then
		b[k] = setmetatable( {}, { __mode = "kv" } )
	end
	b[k][f] = f
end 

local bind
bind = function(ui, t, k, f)
	local cb
	cb = function( ... )
		if not isNull(ui) then
			f(...)
		else
			t.__bind__[k][cb] = nil
		end
	end
	subscribe(t, k, cb)
end

return {
	ob = observe,
	bind = bind
}
