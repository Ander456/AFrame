local M = class("UIManager", Dispatcher)

function M:ctor()
    self.stack = {}
end

function M:Load(cls, assetPath, cb)
    Res.Load(assetPath, typeof(GameObject), function(a)
        local prefab = a.asset
        local go  = GameObject.Instantiate(prefab)  
        go.name = prefab.name   
        local ins = LuaManager.AddLuaComponent(go, cls)
        ins:OnLoaded(asset)
        cb(ins)
    end)
end 

function M:Push(cls)
    self:Load(cls, cls.assetPath, function(view)
        table.insert(self.stack, view)
    end)
end

function M:Pop()
    local view = table.remove(self.stack, #self.stack)
    view:Close()
end

return M