local M = class("View", LuaBehaviour)

function M:OnLoaded(asset)
    self.asset = asset
end

--- virtual for your view when open
function M:OnOpen(...)

end

--- virutal for your view when close clear env
function M:OnClose()

end 

--- do not override
function M:Close()
    self:OnClose()
    GameObject.Destroy(self.gameObject)
    self.asset:Release()
    self.asset = nil
    UIManager:Remove(self)
end 

function M:Find(path, typ)
    local trans
    if path == nil then
        trans = self.transform
    else
        trans = self.transform:Find(path)
    end
    local component
    if typ ~= nil then
        component = trans:GetComponent(typ)
        return component
    end 
    return trans
end

function M:OnClick(path, func)
    local btn = self:Find(path)
    btn:GetComponent("Button").onClick:AddListener(func)
    return btn
end

function M:SetParent(parent)
    self.gameObject.transform:SetParent(parent, false)
end

function M:SetInteractable(flag)
    local canvasGroup = self.gameObject:GetComponent(typeof(UE.CanvasGroup))
    if canvasGroup and not IsNull(canvasGroup) then
        canvasGroup.interactable = flag
    end
end

return M