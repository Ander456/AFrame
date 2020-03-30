local HTTPManager = CS.BestHTTP.HTTPManager
local HTTPRequest = CS.BestHTTP.HTTPRequest
local HTTPResponse = CS.BestHTTP.HTTPResponse
local HTTPMethods = CS.BestHTTP.HTTPMethods
local HTTPProxy = CS.BestHTTP.HTTPProxy
local HTTPRequestStates = CS.BestHTTP.HTTPRequestStates
local Uri = CS.System.Uri
local TimeSpan = CS.System.TimeSpan
local Utils = CS.Utils

local M = {}

--[[
--tip: use coroutinue for the convenient code will block in co when asyncall return
--usage:
http.go(function() what task you want to do end)
task like bellow
-- local req, resp = http({method = "GET", url = "https://www.weibo.com"})
-- local req, resp = http.get("http://www.baidu.com")
-- local req, resp = http.post("http://www.baidu.com", {xx = xx}, {xx = xx})
completely example:
-- http.go(function( ... )
--     local req, resp = http.get("http://www.baidu.com")
--     if resp then
--         print( resp.DataAsText )
--     else
--         print(req.State) 
--     end
-- end)
]]

local HttpMethod = {
    GET = HTTPMethods.Get,
    POST = HTTPMethods.Post,
    -- PUT = HTTPMethods.Put,
}

local function createRequest(data)
    local req = HTTPRequest(Uri(data.url))
    req.MethodType = HttpMethod[data.method]
    req.Timeout = TimeSpan.FromSeconds(15)
    req.ConnectTimeout = TimeSpan.FromSeconds(15)
    req.DisableCache = true
    if data.headers then
        for field, value in pairs(data.headers) do
            req:AddHeader(field, value)
        end
    end
    if data.postData then
        local jstr = json.encode(data.postData)
        req.RawData = Utils.UTF8GetBytes(jstr)
    end
    req.Callback = function(request, response)
        data.callback(request, response)
    end
    return req
end

function M.request(args)
    assert(args.url)
    assert(args.callback)

    local req = createRequest(args)
    req:Send()
end

function M.get( url, headers )
    return M.call({method = "GET", url = url, headers = headers})
end

function M.post( url, postData, headers )
    return M.call({method = "POST", url = url, postData = postData, headers = headers})
end

function M.call(args)
    local co, ismain = coroutine.running()
    assert(not ismain, 'http call not support in main thread')
    assert(not args.callback)
    args.callback = function (req, resp)
        coroutine.resume(co, req, resp)
    end
    M.request(args)
    return coroutine.yield()
end

local function doCall(_, args)
    return M.call(args)
end

function M.go(func)
    assert(coroutine.resume(coroutine.create(func)))
end

return setmetatable(M, {__call = doCall})