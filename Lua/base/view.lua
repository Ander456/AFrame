local M = class("View", LuaBehaviour)

function M:ctor()
end

function M:Find(path)
    local trans
    if path == nil then
        trans = self.transform
    else
        trans = self.transform:Find(path)
    end 
    return trans
end

function M:Update()
    self.transform:Rotate(UE.Vector3.up*3);
end

function M:Load(assetPath)
    self.asset = Assets.LoadAsync(assetPath, typeof(GameObject))
    self.asset.completed = function(a) 
        if not self.closed then
            local prefab = a.asset
            local go  = GameObject.Instantiate(prefab)  
            go.name = prefab.name   
            local t = LuaManager.AddLuaComponent(go, M)
            if self.onloaded then
                self.onloaded(self)
            end
            self:OnLoaded() 
            self.loaded = true 
        end
    end 
end 

function M:Close()
    self.onloaded = nil
    self:OnClose()
    GameObject.Destroy(self.gameObject)
    self.asset:Release()
    self.closed = true
end 

function M:SetParent(parent)
    self.gameObject.transform:SetParent(parent, false)
end

function M:OnLoaded()
    
end

function M:OnClose()

end 

return M