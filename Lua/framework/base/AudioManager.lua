local M = class("AudioManager")

function M:ctor()
    self.ins = CSAudioManager.Instance
end

function M:PlayBGM(path)
    self.ins:PlayBGM(path)
end

function M:StopBGM()
    self.ins:StopBGM()
end

function M:PauseBGM()
    self.ins:PauseBGM()
end

function M:ResumeBGM()
    self.ins:ResumeBGM()
end

function M:PlaySound(path)
    self.ins:PlayOneShot(path)
end

function M:ToggleMute(flag)
    self.ins:ToggleMute(flag)
end

function M:SetVolume(value)
    self.ins.MusicVolume = value
    self.ins.SoundVolume = value
end

function M:GetVolume()
    return self.ins.MusicVolume
end

return M