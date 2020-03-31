local M = class("Home", View)

M.ASSET_PATH = "Assets/Prefabs/UI/Home.prefab"
M.OPEN_ANIM = -1
M.BLOCK = -1

function M:Start()
    --- data 
    self.data = DBind.ob({
        score = 100,
        name = "abc"
    })

    --- view
    self:OnClick("Root/Button", function()
        print("click Home Button")
    end)

    self:OnClick("Root/Button2", function()
        print("click Home Button2")
        UIManager:Push(require("Setting"))
    end)

    self.score = self:Find("Root/Score", typeof(UE.UI.Text))
    DBind.bind(self.score, self.data, "score", function(v, o)
        self.score.text = v
    end)

    self:StartCoroutine(function()
        while true do
            coroutine.yield(CS.UnityEngine.WaitForSeconds(3))
            self.data.score = math.random(100, 1000)
        end
    end)
end

return M