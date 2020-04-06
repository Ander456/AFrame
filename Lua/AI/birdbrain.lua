local SEE_PLAYER_DIST = 5

local BirdBrain = Class(Brain, function(self, inst)
    Brain._ctor(self, inst)
end)

local function ShouldFlyAway(inst)
    local busy = inst.sg:HasStateTag("sleeping") or inst.sg:HasStateTag("busy") or inst.sg:HasStateTag("flying")
    if not busy then
        return math.random() > 0.5
    end
end

local function FlyAway(inst)
    -- inst:PushEvent("flyaway")
end

function BirdBrain:OnStart()
    local root = PriorityNode(
    {
        IfNode(function() return ShouldFlyAway(self.inst) end, "Threat Near",
            ActionNode(function() return FlyAway(self.inst) end)),
        Wander(self.inst, function() return {x = 100, y = 100} end, 40)),
    }, .25)
    
    self.bt = BT(self.inst, root)
end

return BirdBrain