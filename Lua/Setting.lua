local M = class("Setting", View)

M.assetPath = "Assets/Prefabs/UI/Setting.prefab"

function M:Start()
    self:OnClick("Button", function()
        print("click Setting Button")
    end)
    self:StartCoroutine(function()
        coroutine.yield(CS.UnityEngine.WaitForSeconds(3))
        self:Close()
    end)
end

return M