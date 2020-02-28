--- c# ---
UE = CS.UnityEngine
GameObject = UE.GameObject
Assets = CS.XAsset.Assets
LuaManager = CS.LuaManager

CSAudioManager = CS.AudioManager

--- lua ---
--- core
require("core.functions")
Dispatcher = require("core.Dispatcher")
LuaBehaviour = require("core.LuaBehaviour")

--- base
Res = require("base.ResManager")
UIManager = require("base.UIManager").new()
AudioManager = require("base.AudioManager").new()