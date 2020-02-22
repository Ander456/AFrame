local M = class("ResManager")

function M.Load(assetPath, typ, cb)
    local asset = Assets.LoadAsync(assetPath, typ)
    asset.completed = function(a) 
        if cb then
            cb(a)
        end
    end 
end

function M.LoadSync(assetPath, typ)
    local asset = Assets.Load(assetPath, typ)
    return asset
end 

return M