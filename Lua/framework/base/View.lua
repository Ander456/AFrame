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
    if not trans then
        return
    end
    local component
    if typ ~= nil then
        component = trans:GetComponent(typ)
        return component
    end 
    return trans
end

function M:OnClick(path, func)
    local btn, cb
    if type(path) == "function" then
        btn = self.gameObject
        cb = path
    else
        btn = self:Find(path)
        cb = func
    end
    btn:GetComponent("Button").onClick:AddListener(cb)
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

function M:TweenOpen()
    local trs = self:Find("Root")
    if trs then
        local time = 0.1
        local tw = trs:DOScale(1.1, time)
        tw:SetEase(Tweening.Ease.Linear)
        tw:SetLoops(2, Tweening.LoopType.Yoyo) 
        tw = trs:DOScale(0.9, time)
        tw:SetEase(Tweening.Ease.Linear)
        tw:SetLoops(2, Tweening.LoopType.Yoyo) 
    end
end

function M:BlockLayer()
    local block = self:Find("BlockLayer")
    if not block then
        UIManager:Create(require("BlockLayer"), self.transform)
    end
end

return M