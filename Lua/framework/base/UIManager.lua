local M = class("UIManager")

local LAYER_UI = 5
local LAYER_NULL = 3

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
    return view
end

function M:Push(...)
    local params = {...}
    local cls = table.remove(params, 1)
    self:Load(cls, cls.assetPath, function(view)
        self:Hide(self:Top())
        table.insert(self.stack, view)
        view:OnOpen(table.unpack(params))
        self:tweenOpen(view)
    end)
end

function M:Pop()
    local view = table.remove(self.stack, #self.stack)
    if view then
        view:Close()
    end
    self:Show(self:Top())
    return view
end

function M:Remove(view)
    local idx = -1
    local len = #self.stack
    for index = #self.stack, 1, -1 do
        if self.stack[index] == view then
            table.remove(self.stack, index)
            idx = index
        end
    end
    if idx == len then
        self:Show(self:Top())
    end
end

function M:Top()
    return self.stack[#self.stack]
end

function M:Bottom()
    return self.stack[1]
end

function M:Hide(view)
    if #self.stack == 1 then
        return
    end
    if view then
        view.gameObject.layer = LAYER_NULL
    end
end

function M:Show(view)
    if view then
        view.gameObject.layer = LAYER_UI
    end
end

function M:tweenOpen(view)
    if view.class.openAnim == -1 then
        return
    end
    view.transform.localScale = UE.Vector3.zero
    view.transform:DOScale(1, 0.3)
end

return M