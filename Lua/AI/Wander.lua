Wander = Class(BehaviourNode, function(self, inst, homelocation, max_dist, times)
    BehaviourNode._ctor(self, "Wander")
    self.homepos = homelocation
    self.maxdist = max_dist
    self.inst = inst
    self.far_from_home = false
    
    self.times =
    {
		minwalktime = times and times.minwalktime or 2,
		randwalktime = times and times.randwalktime or 3,
		minwaittime = times and times.minwaittime or 1,
		randwaittime = times and times.randwaittime or 3,
    }
end)

function Wander:Visit()

    if self.status == READY then
		self:Wait(self.times.minwaittime + math.random()*self.times.randwaittime)
        self.walking = false
        self.status = RUNNING
    elseif self.status == RUNNING then
		if not self.walking and self:IsFarFromHome() then
            self:PickNewDirection()
		end
        if GetTime() > self.waittime then
            self:PickNewDirection()
        else
            if not self.walking then
				self:Sleep(self.waittime - GetTime())
            end
        end
    end
end

local function tostring_float(f)
    return f and string.format("%2.2f", f) or tostring(f)
end

function Wander:DBString()
    local w = self.waittime - GetTime()
    return string.format("%s for %2.2f, %s, %s, %s", 
        self.walking and 'walk' or 'wait', 
        w, 
        tostring(self:GetHomePos()), 
        tostring_float(math.sqrt(self:GetDistFromHomeSq() or 0)), 
        self.far_from_home and "Go Home" or "Go Wherever")
end

function Wander:GetHomePos()
    return self.homepos
end

function Wander:GetDistFromHomeSq()
    local homepos = self:GetHomePos()
	if not homepos then
		return nil
	end
    -- local pos = Vector3(self.inst.Transform:GetWorldPosition())
    -- return distsq(homepos, pos)
    return math.random(10, 100)
end
	
function Wander:IsFarFromHome()
	if self:GetHomePos() then
		return self:GetDistFromHomeSq() > self:GetMaxDistSq()
	end
	return false
end

function Wander:GetMaxDistSq()
    return self.maxdist * self.maxdist
end

function Wander:Wait(t)
    self.waittime = t+GetTime()
    self:Sleep(t)
end

function Wander:PickNewDirection()
    self.walking = not self.walking
    self.far_from_home = self:IsFarFromHome()
    if self.walking then
        if self.far_from_home then
            -- self.inst.components.locomotor:GoToPoint(self:GetHomePos())
            print("go home pos")
        else
            print("wander ...")
        end
        self:Wait(self.times.minwalktime+math.random() * self.times.randwalktime)
    else
        print("stand ...")
        self:Wait(self.times.minwaittime+math.random()*self.times.randwaittime)
    end
end


