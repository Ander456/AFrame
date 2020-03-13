local M = class("Loading", View)

M.assetPath = "Assets/Prefabs/UI/loading.prefab"

function M:Awake()
    self.slider = self:Find("")
end

function M:Start()
    Updater:SetUp({
        complete = handler(self, self.onCompleted),
        onError = handler(self, self.onError),
        onProgress = handler(self, self.onProgress)
    })
    Updater:Check()
end

function M:onCompleted()

end

function M:onError(e)
    print("onError", e)
end

function M:onProgress(name, progress)
    print(name, progress)
end

return M