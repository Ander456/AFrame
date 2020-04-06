--- brain

Brain = Class(function(self)
    self.inst = nil
end)

function Brain:ForceUpdate()
    if self.bt then
        self.bt:ForceUpdate()
    end
end

function Brain:__tostring()
    if self.bt then
        return string.format("--brain--\nsleep time: %2.2f\n%s", self:GetSleepTime(), tostring(self.bt))
    end
    return "--brain--"
end

function Brain:GetSleepTime()
    if self.bt then
        return self.bt:GetSleepTime()
    end
    return 0
end

function Brain:Start()
    if self.OnStart then
        self:OnStart()
    end
end

function Brain:Update()
    if self.bt then
        self.bt:Update()
    end
end

function Brain:Stop()
    if self.bt then
        self.bt:Stop()
    end
end