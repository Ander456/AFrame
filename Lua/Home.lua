local M = class("Home", View)

M.assetPath = "Assets/Prefabs/UI/Home.prefab"

function M:Start()
    self:OnClick("Button", function()
        print("click Button")
    end)
end

return M