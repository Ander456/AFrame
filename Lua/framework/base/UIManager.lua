local M = class("UIManager")

function M:ctor()
    self.stack = {}
    self.root = GameObject.Find("UI/UIRoot").transform
end

function M:Load(cls, assetPath, cb)
    Res.Load(assetPath, typeof(GameObject), function(a)
        local prefab = a.asset
        local go  = GameObject.Instantiate(prefab, self.root)  
        go.name = prefab.name   
        local ins = LuaManager.AddLuaComponent(go, cls)
        ins:OnLoaded(a)
        cb(ins)
    end)
end 

function M:LoadSync(cls, assetPath)
    local a =  Res.LoadSync(cls.assetPath, typeof(GameObject))
    local prefab = a.asset
    local go  = GameObject.Instantiate(prefab, self.root)  
    go.name = prefab.name   
    local ins = LuaManager.AddLuaComponent(go, cls)
    ins:OnLoaded(a)
    return ins
end

function M:PushSync(...)
    local params = {...}
    local cls = table.remove(params, 1)
    local view = self:LoadSync(cls, cls.assetPath)
    table.insert(self.stack, view)
    view:OnOpen(table.unpack(params))
end

function M:Push(...)
    local params = {...}
    local cls = table.remove(params, 1)
    self:Load(cls, cls.assetPath, function(view)
        table.insert(self.stack, view)
        view:OnOpen(table.unpack(params))
        --- add logci ex: hide below fo the top
    end)
end

function M:Pop()
    local view = table.remove(self.stack, #self.stack)
    if view then
        view:Close()
    end
    --- add logic ex: show the below of the top
    return view
end

function M:Remove(view)
    for index = #self.stack, 1, -1 do
        if self.stack[index] == view then
            table.remove(self.stack, index)
        end
    end
end

return M