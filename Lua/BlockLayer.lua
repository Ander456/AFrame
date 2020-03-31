local M = class("BlockLayer", View)

M.ASSET_PATH = "Assets/Prefabs/UI/BlockLayer.prefab"

function M:Awake()
    self.transform:SetSiblingIndex(0)
end

return M