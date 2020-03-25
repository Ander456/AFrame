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
Timer = require("framework.core.timer")
LuaBehaviour = require("framework.core.LuaBehaviour")
DBind = require("framework.core.dataBinding")

--- base
Res = require("framework.base.ResManager")
UIManager = require("framework.base.UIManager").new()
View = require("framework.base.View")
AudioManager = require("framework.base.AudioManager").new()

--- net
require("framework.net.init")