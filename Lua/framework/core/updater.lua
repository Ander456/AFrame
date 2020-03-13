local M = class("updater")

function M:ctor()
    self.updater = GameObject.Find("AssetsUpdate"):GetComponent(typeof(AssetsUpdater))
    self.updater.updateNeed = handler(self, self.onUpdateNeed)
    self.updater.completed = handler(self, self.onCompleted)
    self.updater.progress = handler(self, self.onProgress)
    self.updater.onError = handler(self, self.onError)
end

function M:SetUp(param)
    self._complete = param.complete 
    self._onError = param.onError  
    self._onProgress = param.onProgress 
end

function M:Check()
    self.updater:Check()
end

function M:onUpdateNeed()
    self:downLoad()
end

function M:onCompleted()
    if self._complete then
        self._complete()
    end
end

function M:onProgress(name, progress)
    if self._onProgress then
        self._onProgress(name, progress)
    end
end

function M:onError(e)
    if self._onError then
        self._onError(e)
    end
end

function M:downLoad()
    self.updater:Download()
end

return M