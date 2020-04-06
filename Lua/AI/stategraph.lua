ActionHandler = Class(function(self, action, state, condition)
    self.action = action
    if type(state) == "string" then
        self.deststate = function(inst) return state end
    else
        self.deststate = state
    end
    self.condition = condition
end)

EventHandler = Class(function(self, name, fn)
    local info = debug.getinfo(3, "Sl")
    self.defline = string.format("%s:%d", info.short_src, info.currentline)
    assert (type(name) == "string")
    assert (type(fn) == "function")
    self.name = string.lower(name)
    self.fn = fn
end)

TimeEvent = Class(function(self, time, fn)
    local info = debug.getinfo(3, "Sl")
    self.defline = string.format("%s:%d", info.short_src, info.currentline)
    assert (type(time) == "number")
    assert (type(fn) == "function")
    self.time = time
    self.fn = fn
end) 

State = Class(function(self, args)
    local info = debug.getinfo(3, "Sl")
    self.defline = string.format("%s:%d", info.short_src, info.currentline)
    
    assert(args.name, "State needs name")
    self.name = args.name
    self.onenter = args.onenter
    self.onexit = args.onexit
    self.onupdate = args.onupdate
    self.ontimeout = args.ontimeout
    
    self.tags = {}
    if args.tags then
        for k, v in ipairs(args.tags) do
            self.tags[v] = true
        end
    end
    
    self.events = {}
    if args.events ~= nil then
        for k,v in pairs(args.events) do
            assert(v:is_a(EventHandler), "non-EventHandler in event list")
            self.events[v.name] = v
        end
    end
    
    self.timeline = {}
    if args.timeline ~= nil then
        for k,v in ipairs(args.timeline) do
            assert(v:is_a(TimeEvent), "non-TimeEvent in timeline")
            table.insert(self.timeline, v)
        end
    end
end)

function State:HandleEvent(sg, eventname, data)
    if not data or not data.state or data.state == self.name then
        local handler = self.events[eventname]
        if handler ~= nil then
            return handler.fn(sg.inst, data)
        end
    end
    return false
end

StateGraph = Class(function(self, name, states, events, defaultstate, actionhandlers)
    assert(name and type(name) == "string", "You must specify a name for this stategraph")
    local info = debug.getinfo(3, "Sl")
    self.defline = string.format("%s:%d", info.short_src, info.currentline)
    self.name = name
    self.defaultstate = defaultstate
    
    self.actionhandlers = {}
    if actionhandlers then
        for k,v in pairs(actionhandlers) do
            assert(v:is_a(ActionHandler),"Non-action handler added in actionhandler table!")
            self.actionhandlers[v.action] = v
        end
    end

    self.events = {}
    for k,v in pairs(events) do
        assert(v:is_a(EventHandler),"Non-event added in events table!")
        self.events[v.name] = v
    end

    self.states = {}
    for k,v in pairs(states) do
        assert(v:is_a(State),"Non-state added in state table!")
        self.states[v.name] = v
    end
end)

function StateGraph:__tostring()
    return "Stategraph : " .. self.name
end

---@stategrph is the stategrph
---@inst is an instance of a game entity
StateGraphInstance = Class(function(self, stategraph, inst)
    self.sg = stategraph
    self.currentstate = nil
    self.timeinstate = 0
    self.lastupdatetime = 0
    self.timelineindex = nil
    self.inst = inst
    self.statestarttime = 0
end)

function StateGraphInstance:__tostring()
    local str =  string.format([[sg="%s", state="%s", time=%2.2f]], self.sg.name, self.currentstate.name, GetTime() - self.statestarttime)
    str = str..[[, tags = "]]
    for k,v in pairs(self.tags) do
        str = str..tostring(k)..","
    end
    str = str..[["]]
    return str
end
    
function StateGraphInstance:GetTimeInState()
    return GetTime() - self.statestarttime
end

function StateGraphInstance:IsListeningForEvent(event)
    return self.currentstate.events[event] ~= nil or self.sg.events[event] ~= nil
end

function StateGraphInstance:InNewState()
	return self.laststate ~= self.currentstate
end

function StateGraphInstance:GoToState(statename, params)
    local state = self.sg.states[statename]
    
    if not state then 
		print (self.inst, "TRY TO GO TO INVALID STATE", statename)
		return 
    end
    
    if self.currentstate ~= nil and self.currentstate.onexit ~= nil then 
        self.currentstate.onexit(self.inst)
    end

    self.tags = {}
    if state.tags then
        for i,k in pairs(state.tags) do
            self.tags[i] = true
        end
    end
    self.timeout = nil
    self.laststate = self.currentstate
    self.currentstate = state
    self.timeinstate = 0

    if self.currentstate.timeline ~= nil then
        self.timelineindex = 1
    else
        self.timelineindex = nil
    end
    
    if self.currentstate.onenter ~= nil then
        self.currentstate.onenter(self.inst, params)
    end
    
    self.lastupdatetime = GetTime()
    self.statestarttime = self.lastupdatetime    

end

function StateGraphInstance:AddStateTag(tag)
    self.tags[tag] = true
end

function StateGraphInstance:RemoveStateTag(tag)
    self.tags[tag] = nil
end

function StateGraphInstance:HasStateTag(tag)
    return self.tags and (self.tags[tag] == true)
end

function StateGraphInstance:SetTimeout(time)
    self.timeout = time
end

function StateGraphInstance:UpdateState(dt)
    if not self.currentstate then 
        return
    end

    self.timeinstate = self.timeinstate + dt
    local startstate = self.currentstate
    
    if self.timeout then
        self.timeout = self.timeout - dt
        if self.timeout <= (1/30) then
            self.timeout = nil
            if self.currentstate.ontimeout then
                self.currentstate.ontimeout(self.inst)
                if startstate ~= self.currentstate then
                    return
                end
            end
        end
    end
    
    while self.timelineindex and self.currentstate.timeline[self.timelineindex] and self.currentstate.timeline[self.timelineindex].time <= self.timeinstate do

		local idx = self.timelineindex
        self.timelineindex = self.timelineindex + 1
        if self.timelineindex > #self.currentstate.timeline then
            self.timelineindex = nil
        end
        
        local old_time = self.timeinstate
        local extra_time = self.timeinstate - self.currentstate.timeline[idx].time
        self.currentstate.timeline[idx].fn(self.inst)
        
        if startstate ~= self.currentstate or old_time > self.timeinstate then
            self:Update(extra_time)
            return 0
        end
    end
    
    if self.currentstate.onupdate ~= nil then
        self.currentstate.onupdate(self.inst, dt)
    end
end

function StateGraphInstance:Update()
    local dt = 0
    if self.lastupdatetime then
        dt = GetTime() - self.lastupdatetime
    end
    self.lastupdatetime = GetTime()
	
    self:UpdateState(dt)
end