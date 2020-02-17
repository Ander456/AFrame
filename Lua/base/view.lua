local M = class("View")

function M:ctor()
    ViewManager.Add(self)
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

function M:Load(assetPath)
    self.asset = Assets.LoadAsync(assetPath, typeof(GameObject))
    self.asset.completed = function(a) 
        if not self.closed then
            local prefab = a.asset
            local go  = GameObject.Instantiate(prefab)  
            go.name = prefab.name   
            self.gameObject = go 
            self.luaBehaviour = self.gameObject:AddComponent(typeof(CS.LuaBehaviour))
            self.transform = self.gameObject.transform
            if self.onloaded then
                self.onloaded(self)
            end
            self:OnLoaded() 
            if ViewManager.rootView == nil then
                ViewManager.rootView = self
            else
                self:SetParent(ViewManager.rootView.canvasRoot)
            end
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