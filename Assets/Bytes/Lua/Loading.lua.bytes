local M = class("Loading", View)

M.assetPath = "Assets/Prefabs/UI/loading.prefab"

function M:Awake()
    self.slider = self:Find("Slider"):GetComponent(typeof(UE.UI.Slider))
    self.slider.gameObject:SetActive(false)
end

function M:Start()
    Updater:SetUp({
        complete = handler(self, self.onCompleted),
        onError = handler(self, self.onError),
        onProgress = handler(self, self.onProgress),
        onUpdateNeed = handler(self, self.onUpdateNeed)
    })
    Updater:Check()
end

function M:onCompleted()
    print("Assets update complete .")
    self:StartCoroutine(function()
        coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
        local sceneAsset = Res.LoadScene("Assets/Scenes/Home.unity", true)
        while not sceneAsset.isDone do
            print(sceneAsset.progress)
            coroutine.yield()
        end
        self:Close()
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
end

return M