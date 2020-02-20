local M = class("UIManager", Dispatcher)

function M:ctor()
    self.stack = {}
end

function M:Load(cls, assetPath)
    Res.Load(assetPath, typeof(GameObject), function(a)
        local prefab = a.asset
        local go  = GameObject.Instantiate(prefab)  
        go.name = prefab.name   
        local ins = LuaManager.AddLuaComponent(go, cls)
        ins:OnLoaded(asset)
        table.insert(self.stack, ins)
    end)
end 

return M