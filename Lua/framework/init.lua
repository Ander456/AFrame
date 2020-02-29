--- c# ---
UE = CS.UnityEngine
GameObject = UE.GameObject
Assets = CS.XAsset.Assets
LuaManager = CS.LuaManager

CSAudioManager = CS.AudioManager

--- lua ---
--- core
require("framework.core.functions")
Dispatcher = require("framework.core.Dispatcher")
LuaBehaviour = require("framework.core.LuaBehaviour")

--- base
Res = require("framework.base.ResManager")
UIManager = require("framework.base.UIManager").new()
View = require("framework.base.View")
AudioManager = require("framework.base.AudioManager").new()

--- net
require("framework.net.init")