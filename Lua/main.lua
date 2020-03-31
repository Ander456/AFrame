require("framework.init")

print("lua main")

Schedulers = {}

function Update()
    local dt = UE.Time.deltaTime
    for index, schedule in ipairs(Schedulers) do
        schedule:update(dt)
    end
end

-- --- test rapidjson
-- local t = {a=1,b=2,c="33"}
-- print(json.encode(t))

-- --- test http
-- http.go(function()
--     local req, resp = http({method = "GET", url = "https://www.weibo.com"})
--     print(resp.DataAsText)
-- end)

-- --- test lua-protobuf
-- local pb = require "pb"
-- local protoc = require("net.luaprotobuf.protoc")
-- protoc:load([[
--    message Phone {
--       optional string name        = 1;
--       optional int64  phonenumber = 2;
--    }
--    message Person {
--       optional string name     = 1;
--       optional int32  age      = 2;
--       optional string address  = 3;
--       repeated Phone  contacts = 4;
--    } ]])
-- local data = {
--    name = "ilse",
--    age  = 18,
--    contacts = {
--       { name = "alice", phonenumber = 12312341234 },
--       { name = "bob",   phonenumber = 45645674567 }
--    }
-- }
-- local bytes = assert(pb.encode("Person", data))
-- print(pb.tohex(bytes))
-- local data2 = assert(pb.decode("Person", bytes))
-- dump(data2)

-- --- test xsocket
-- local socket = require("xsocket")
-- local s = socket.new()
-- s:connect("127.0.0.1", 9999)
-- local stringPack = string.pack("<i8", 1234)
-- s:writeBytes(stringPack .."\n")
-- s:flush()

-- --- test class
-- local person = class("person")
-- function person:ctor(name, age)
--     self.name = name
--     self.age = age
-- end
-- function person:say()
--     print(self.name .. " " .. self.age)
-- end
-- local man = class("man", person)
-- function man:ctor(name, age, sex)
--     self.name = name
--     self.age = age
--     self.sex = sex
-- end
-- function man:mansay()
--     self.super.say(self)
--     print(self.sex)
-- end
-- local superman = class("suerpman", man)
-- function superman:ctor(name, age, sex, power)
--     self.name = name
--     self.age = age
--     self.sex = sex
--     self.power = power
-- end
-- function superman:suerpmansay()
--     self.super.say(self)
--     print("superman ", self.sex, self.power)
-- end
-- local p = person.new("john", 50)
-- local m = man.new("alex", 24, "male")
-- local spm = superman.new("superman", 40, "male", 10000)
-- -- p:say()
-- -- m:say()
-- -- m:mansay()
-- spm:say()
-- spm:suerpmansay()

--- test luabehaviour
-- local asset = Assets.LoadAsync("Assets/Prefabs/Cube.prefab", typeof(GameObject))
-- asset.completed = function(a)
--     local prefab = a.asset
--     local go  = GameObject.Instantiate(prefab)
--     go.name = prefab.name
--     local ins = LuaManager.AddLuaComponent(go, LuaBehaviour)
--     ins:StartCoroutine(function()
--         coroutine.yield(CS.UnityEngine.WaitForSeconds(3))
--         GameObject.Destroy(ins.gameObject)
--     end)
--     ins:StartCoroutine(function()
--         print('coroutine a started')
--         while true do
--             coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
--             print('i am coroutine a')
--         end
--     end)
-- end

-- --- test res load
-- Res.Load("Assets/Textures/bg.png", typeof(UE.Texture2D), function(a)
--     print(a.asset)
-- end)
-- local a = Res.LoadSync("Assets/Textures/bg.png", typeof(UE.Texture2D))
-- print(a.asset)

-- Res.Load("Assets/Atlas/Test/icon1.png", typeof(UE.Sprite), function(a)
--     local sp = a.asset
--     Res.Load("Assets/Prefabs/Logo.prefab", typeof(GameObject), function(a)
--         local prefab = a.asset
--         local go = GameObject.Instantiate(prefab)
--         go.name = prefab.name
--         local ins = LuaManager.AddLuaComponent(go, require("base.View"))
--         ins:OnLoaded(asset)
--         local render = ins:AddComponent(typeof(UE.SpriteRenderer))
--         render.sprite = sp
--     end)
-- end)

-- local a = Res.LoadSync("Assets/Atlas/Test/icon2.png", typeof(UE.Sprite))
-- local sp = a.asset
-- a = Res.LoadSync("Assets/Prefabs/Logo.prefab", typeof(GameObject))
-- local prefab = a.asset
-- local go = GameObject.Instantiate(prefab)
-- go.name = prefab.name
-- local ins = LuaManager.AddLuaComponent(go, require("base.View"))
-- ins:OnLoaded(asset)
-- local render = ins:AddComponent(typeof(UE.SpriteRenderer))
-- render.sprite = sp

--- test audio
-- AudioManager:PlaySound("Assets/Audios/kill.mp3")
-- AudioManager:PlayBGM("Assets/Audios/bgm.mp3")
-- print(AudioManager:GetVolume())
-- AudioManager:SetVolume(0.5)
-- print(AudioManager:GetVolume())

--- test load scene
-- local sceneAsset = Res.LoadScene("Assets/Scenes/Loading.unity")
-- sceneAsset:Release()

--- test ui && btn
-- UIManager:Push(require("Home"))

--- test update && reset lua env
-- UIManager:Push(require("Loading"))

--- test timer
local timer = Timer.new()
table.insert(Schedulers, timer)
-- UIManager:Push(require("Home"))
-- local id = timer:schedule(1, function()
--     print("haha")
-- end)
-- timer:delay(5, function()
--     print("delay")
--     timer:unschedule(id)
-- end)

--- test change layer to hide ui
-- local flag = false
-- timer:schedule(3, function()
--     local v = UIManager:Top()
--     if flag then
--         v.gameObject.layer = 5
--         flag = false
--     else
--         v.gameObject.layer = 3
--         flag = true
--     end
-- end)

--- test auto show hide by layer && open anim
UIManager:Push(require("Home"))
UIManager:Push(require("Store"))
UIManager:Push(require("Setting"))
timer:delay(3, function()
    -- UIManager:Pop()
end)


