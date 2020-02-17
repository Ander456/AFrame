require("core.init")
require("net.http.init")

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

