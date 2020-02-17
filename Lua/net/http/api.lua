local get = function( uri , params )
	local baseUrl = DEBUG and config.dev or config.pro
	local url = baseUrl..uri
	params = params or {}
	if table.nums(params) > 0 then
		local keys = table.keys(params)
		table.sort( keys )
		local query = ""
		for i, key in ipairs( keys ) do
			query = query .. key .. "=" .. params[key].. "&"
		end
		query = string.sub(query, 1, string.len(query) - 1)
		url = url .. "?" .. query
	end
	local req, resp = http.get(url, {})
	if resp and resp.StatusCode == 200 then
		xpcall(function() resp = json.decode(resp.DataAsText) end, function()end)  
        return true, resp
    else
        return false, resp and resp.StatusCode or "unknown error see HTTPRequestStates"
    end
end

local post = function( uri, params )
	local baseUrl = DEBUG and config.dev or config.pro
	local url = baseUrl..uri
	local req, resp = http.post(url, params, {})
	if resp and resp.StatusCode == 200 then
		xpcall(function() resp = json.decode(resp.DataAsText) end, function()end)  
        return true, resp
    else
        return false, resp and resp.StatusCode or req.State
    end
end

--[[
	RESTFUL API
	/project/version/what
]]
local api = {
	login = function( params )
		return post("/xxx/v1/login", params)
	end,
	heartbeat = function( params )
		return post("/xxx/v1/heartbeat", params)
	end,
}

return api





