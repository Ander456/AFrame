local M = class("Store", View)

M.assetPath = "Assets/Prefabs/UI/Store.prefab"

function M:Start()
    self:OnClick("Button", function()
        print("click Store Button")
    end)
end

return M