require("core.init")
require("net.init")

function Update()
end

function LateUpdate()
end

function FixedUpdate()
end

print("lua main")

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