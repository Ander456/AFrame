local M = class("ResManager")

function M.Load(assetPath, typ, cb)
    local asset = Assets.LoadAsync(assetPath, typ)
    asset.completed = function(a) 
        if cb then
            cb(a)
        end
    end 
end 

return M