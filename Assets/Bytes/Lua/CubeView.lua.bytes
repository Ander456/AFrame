local M = class("CubeView", View)

M.assetPath = "Assets/Prefabs/Cube.prefab"

function M:Start()
    print(self.__cname, "Start")
    -- self:StartCoroutine(function()
    --     coroutine.yield(CS.UnityEngine.WaitForSeconds(3))
    --     -- self:Close()
    -- end)
end

function M:OnOpen(...)
    print(self.__cname, "OnOpen", ...)
end

function M:OnClose()
    print(self.__cname, "OnClose")
end

return M