---@LuaBehaviour
--[[
    the lua part monobehaviour, any lua class inherit LuaBehaviour which define Awake(and other monobehaviour funcs) can 
    perform like in c# ps: the c# and lua communcation is expensive if the function useless do not write
]]

local M = class("LuaBehaviour")

local util = require 'framework.core.util'

function M:ctor(...)
    local comp = ...
    self.cscomp = comp
    self.gameObject = comp.gameObject
    self.transform = comp.transform
end

function M:AddComponent(typ)
    return self.gameObject:AddComponent(typ)
end

function M:GetComponent(typ)
    return self.gameObject:GetComponent(typ)
end

function M:StartCoroutine(func)
    return self.cscomp:StartCoroutine(util.cs_generator(func))
end

function M:StopCoroutine(co)
    self.cscomp:StopCoroutine(co)
end

-- function M:Awake()
-- end

-- function M:Start()
-- end

-- function M:Update()
-- end

-- function M:LateUpdate()
-- end

-- function M:FixedUpdate()
-- end

-- function M:OnEnable()
-- end

-- function M:OnDisable()
-- end

-- function M:OnDestroy()
-- end

return M