local Socket        = require "xsocket"
local PacketBuffer  = require "net.tcp.PacketBuffer"

local STATUS_IOERROR = "ioerror"
local STATUS_CONNECTED = "connected"
local STATUS_DISCONNECTED = "disconnected"

local TcpClient = class('TcpClient', Dispatcher)

function TcpClient:ctor()
    self._host = nil
    self._port = nil
    self._socket = Socket.new()
    self._status = self._socket.status
    self._connecting = false
    self._buffer = PacketBuffer.new()
    self._callContexts = setmetatable({}, {__mode = 'kv'})
    self._callRequests = {}
end

function TcpClient:dispose()
    self._socket:close()
end

function TcpClient:_ping()
    if self.connected then
    end
end

function TcpClient:connected()
    return self._status == STATUS_CONNECTED
end

function TcpClient:host()
    local host = self._host
    return host and #host > 0 and host or nil
end

function TcpClient:port()
    return self._port
end

function TcpClient:_update()
    local socket = self._socket
    local status = socket.status

    if status ~= self._status or self._connecting then
        self._status = status
        self._connecting = false
        if status == STATUS_CONNECTED then
            self:dispatch(STATUS_CONNECTED)
        elseif status == STATUS_DISCONNECTED then
            self:dispatch(STATUS_DISCONNECTED)
        elseif status == STATUS_IOERROR then
            self:dispatch(STATUS_IOERROR)
        end
    end

    if status == STATUS_CONNECTED then
        local bytesAvailable = socket.bytesAvailable
        while bytesAvailable > 0 do
            -- read content
            bytesAvailable = socket.bytesAvailable
        end
    end
end

function TcpClient:connect(host, port)
    self._host = assert(host)
    self._port = assert(port)
    self._socket:connect(host, port)
    self._connecting = true
end

function TcpClient:close()
    self._status = false
    self._socket:close()
end

function TcpClient:clear()
    self._socket:clear()
    self._callRequests = {}
end

function TcpClient:send(opcode, data)
    -- write content
end

return TcpClient
