local M = class("Store", View)

M.ASSET_PATH = "Assets/Prefabs/UI/Store.prefab"

function M:Start()
    self:OnClick("Root/Button", function()
        print("click Store Button")
        UIManager:Push(require("Setting"))
    end)

    self:OnClick("Root/Button2", function()
        print("click Store Button2")
        -- UIManager:Push(require("Setting"))
    end)
end

return M