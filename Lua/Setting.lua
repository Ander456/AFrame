local M = class("Setting", View)

M.ASSET_PATH = "Assets/Prefabs/UI/Setting.prefab"

function M:OnOpen()
    self:OnClick("Root/Button", function()
        print("click Setting Button")
    end)
    self:StartCoroutine(function()
        coroutine.yield(CS.UnityEngine.WaitForSeconds(3))
        self:Close()
    end)
end

return M
