local M = class("M", Dispatcher)

function M:ctor()
    self.stack = {}
end

function M:Load(cls, assetPath)
    local asset = Assets.LoadAsync(assetPath, typeof(GameObject))
    asset.completed = function(a) 
        local prefab = a.asset
        local go  = GameObject.Instantiate(prefab)  
        go.name = prefab.name   
        local ins = LuaManager.AddLuaComponent(go, cls)
        ins:OnLoaded(asset)
        table.insert(self.stack, ins)
    end 
end 

return M