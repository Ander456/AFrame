--- a lua component to simulator behaviour but schedule by pure lua global update to improve performance
local M = class("LuaComponent")

local util = require 'framework.core.util'

function M:ctor(go)
    self.gameObject = go
    self.transform = go.transform
    LuaComponents[self] = self
end

function M:Awake()
    print("Awake")
end

function M:Start()
    print("Start")
end

function M:Update()
    self.transform:Rotate(UE.Vector3.up * 30 * UE.Time.deltaTime)
end

function M:OnDestroy()
    LuaComponents[self] = nil
end

function M:AddComponent(typ)
    return self.gameObject:AddComponent(typ)
end

function M:GetComponent(typ)
    return self.gameObject:GetComponent(typ)
end

return M