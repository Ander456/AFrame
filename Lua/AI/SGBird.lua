local events =
{
    EventHandler("attacked", function(inst) inst.sg:GoToState("hit") end),
    EventHandler("death", function(inst) inst.sg:GoToState("death") end),
    EventHandler("flyaway", function(inst) inst.sg:GoToState("flyaway")  end),
}

local states =
{
    State {
        name = "idle",
        tags = {"idle", "canrotate"},
        onenter = function(inst, pushanim)
            print("playAnimation idle")
        end,
        ontimeout = function(inst)
            local r = math.random()
            if r < .5 then
                inst.sg:GoToState("idle")
            elseif r < .7 then
                inst.sg:GoToState("flyaway")
            else 
                inst.sg:GoToState("caw")
            end
        end,
    },

    State {
        name = "death",
        tags = {"busy"},
        
        onenter = function(inst)
            print("playAnimation death")
        end,
    },
    
    State {
        name = "caw",
        tags = {"idle"},
        onenter = function(inst)
            print("playAnimation caw")
        end,
        events =
        {
            EventHandler("animover", function(inst) if math.random() < .5 then inst.sg:GoToState("caw") else inst.sg:GoToState("idle") end end ),
        },
    },
    
    State {
        name = "flyaway",
        tags = {"flying", "busy"},
        onenter = function(inst)
            print("playAnimation flyaway")
        end,
        
        ontimeout = function(inst)
            print("flyaway timeout")
        end,
        
        timeline = 
        {
            TimeEvent(2, function(inst) print("remove self") end)
        }
    },

    State {
        name = "fall",
        tags = {"busy"},
        onenter = function(inst)
            print("playAnimation fall")
        end,
        
        onupdate = function(inst, dt)
            -- print("fall onupdate", dt)
        end,
    },    
    
    State {
        name = "hit",
        tags = {"busy"},
        
        onenter = function(inst)
            inst.sg:GoToState("fall")
        end,
        
        events =
        {
            EventHandler("animover", function(inst) inst.sg:GoToState("idle") end),
        },        
    },    
}
    
return StateGraph("bird", states, events, "idle")
