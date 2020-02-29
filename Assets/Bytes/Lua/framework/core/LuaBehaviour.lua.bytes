---@LuaBehaviour
--[[
    the lua part monobehaviour, any lua class inherit LuaBehaviour which define Awake(and other monobehaviour funcs) can 
    perform like in c# ps: the c# and lua communcation is expensive if the function useless do not write
]]

local LuaBehaviour = class("LuaBehaviour")

local util = require 'framework.core.util'

function LuaBehaviour:ctor(...)
    local comp = ...
    self.cscomp = comp
    self.gameObject = comp.gameObject
    self.transform = comp.transform
end

function LuaBehaviour:AddComponent(typ)
    return self.gameObject:AddComponent(typ)
end

function LuaBehaviour:GetComponent(typ)
    return self.gameObject:GetComponent(typ)
end

function LuaBehaviour:StartCoroutine(func)
    return self.cscomp:StartCoroutine(util.cs_generator(func))
end

function LuaBehaviour:StopCoroutine(co)
    self.cscomp:StopCoroutine(co)
end

-- function LuaBehaviour:Awake()
-- end

-- function LuaBehaviour:Start()
-- end

-- function LuaBehaviour:Update()
-- end

-- function LuaBehaviour:LateUpdate()
-- end

-- function LuaBehaviour:FixedUpdate()
-- end

-- function LuaBehaviour:OnEnable()
-- end

-- function LuaBehaviour:OnDisable()
-- end

-- function LuaBehaviour:OnDestroy()
-- end

return LuaBehaviour