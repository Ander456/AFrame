local LuaBehaviour = {}

function LuaBehaviour.Init()
    self.list = {}
end

function LuaBehaviour.Destroy()
    self.list = {}
end

function LuaBehaviour.Register()
    
end

function LuaBehaviour.UnRegister()
    -- body
end

function LuaBehaviour.Update()
    -- for key, behaviour in pairs(self.list) do
    --     behaviour:Update()
    -- end
end

function LuaBehaviour.LateUpdate()
    -- for key, behaviour in pairs(self.list) do
    --     behaviour:Update()
    -- end
end

function LuaBehaviour.FixedUpdate()
    -- for key, behaviour in pairs(self.list) do
    --     behaviour:Update()
    -- end
end

return LuaBehaviour