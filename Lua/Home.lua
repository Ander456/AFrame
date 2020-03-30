local M = class("Home", View)

M.assetPath = "Assets/Prefabs/UI/Home.prefab"
M.openAnim = -1

function M:Start()
    self:OnClick("Button", function()
        print("click Home Button")
    end)

    self:OnClick("Button2", function()
        print("click Home Button2")
        UIManager:Push(require("Setting"))
    end)
end

return M