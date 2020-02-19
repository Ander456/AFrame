local M = class("View", LuaBehaviour)

function M:Find(path)
    local trans
    if path == nil then
        trans = self.transform
    else
        trans = self.transform:Find(path)
    end 
    return trans
end

function M:Close()
    self:OnClose()
    GameObject.Destroy(self.gameObject)
    self.asset:Release()
end 

function M:SetParent(parent)
    self.gameObject.transform:SetParent(parent, false)
end

function M:OnLoaded(asset)
    self.asset = asset
end

function M:OnOpen(...)

end

function M:OnClose()

end 

return M