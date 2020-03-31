local M = class("BlockLayer", View)

M.ASSET_PATH = "Assets/Prefabs/UI/BlockLayer.prefab"

function M:Awake()
    self.transform:SetSiblingIndex(0)
    local img = self:GetComponent(typeof(UE.UI.Image))
    if img then
        img:DOColor(UE.Color(0,0,0,0.4), 1.5)
    end
end

return M