local M = class("Store", View)

M.assetPath = "Assets/Prefabs/UI/Store.prefab"

function M:Start()
    self:OnClick("Button", function()
        print("click Store Button")
        UIManager:Push(require("Setting"))
    end)

    self:OnClick("Button2", function()
        print("click Store Button2")
        -- UIManager:Push(require("Setting"))
    end)
end

return M