require("core.init")
require("net.init")

function Update()
    LuaBehaviour.Update()
end

function LateUpdate()
    LuaBehaviour.LateUpdate()
end

function FixedUpdate()
    LuaBehaviour.FixedUpdate()
end

print("lua main")

print(json)
print(require("socket"))
print(pb)


