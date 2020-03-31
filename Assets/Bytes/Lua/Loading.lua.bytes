local M = class("Loading", View)

M.ASSET_PATH = "Assets/Prefabs/UI/Loading.prefab"
M.OPEN_ANIM = -1
M.BLOCK = -1

function M:Awake()
    self.updater = self.gameObject:GetComponent(typeof(CS.XAsset.AssetsUpdate))
    self.updater.updateNeed = handler(self, self.onUpdateNeed)
    self.updater.completed = handler(self, self.onCompleted)
    self.updater.progress = handler(self, self.onProgress)
    self.updater.onError = handler(self, self.onError)

    self.slider = self:Find("Root/Slider"):GetComponent(typeof(UE.UI.Slider))
    self.slider.gameObject:SetActive(false)
end

function M:Start()
    self.updater:Check()
end

function M:onCompleted()
    print("Assets update complete .")
    self:StartCoroutine(function()
        coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
        LuaManager.Clear()
        for key, value in pairs(package.loaded) do
            if string.find(key, 'framework') == 1 then
                package.loaded[key] = nil
            end
        end
        require("framework.init")
        UIManager:PushSync(require("Home"))
        self:Close()
    end)
end

function M:onError(e)
    print("onError", e)
end

function M:onProgress(name, progress, total_progress)
    self.slider.value = total_progress
end

function M:onUpdateNeed()
    self.slider.gameObject:SetActive(true)
    self.updater:Download()
end

return M