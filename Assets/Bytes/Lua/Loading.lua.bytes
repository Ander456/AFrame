local M = class("Loading", View)

M.assetPath = "Assets/Prefabs/UI/Loading.prefab"

function M:Awake()
    self.updater = self.gameObject:GetComponent(typeof(CS.XAsset.AssetsUpdate))
    self.updater.updateNeed = handler(self, self.onUpdateNeed)
    self.updater.completed = handler(self, self.onCompleted)
    self.updater.progress = handler(self, self.onProgress)
    self.updater.onError = handler(self, self.onError)

    self.slider = self:Find("Slider"):GetComponent(typeof(UE.UI.Slider))
    self.slider.gameObject:SetActive(false)
end

function M:Start()
    self.updater:Check()
end

function M:onCompleted()
    print("Assets update complete .")
    self:StartCoroutine(function()
        coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
        local lm = GameObject.Find("LuaMain"):GetComponent(typeof(CS.LuaMain))
        local t = {"Scenes/Start", "Scenes/Home"}
        lm:ResetLuaAndLoadScene(t[math.random(1, 2)])
        UIManager:PushSync(require("Home"))
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