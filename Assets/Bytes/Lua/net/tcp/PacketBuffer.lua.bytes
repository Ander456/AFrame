local HEADER_LEN = 8

local PacketBuffer = class('PacketBuffer')

function PacketBuffer:ctor()
    self._length = -1
    self._op = 0
    self._csn = 0
    self._ssn = 0
    self._cryptType = 0
    self._cryptKey = 0
end

function PacketBuffer:clear()
    self._length = -1
end

function PacketBuffer:write(socket, op, csn, ssn, data)
    socket:writeUshort(HEADER_LEN + #data) -- len
    socket:writeUshort(op)                 -- opcode
    socket:writeUshort(csn)                -- client session
    socket:writeUshort(ssn)                -- server session
    socket:writeUbyte(0)                   -- crypt type
    socket:writeUbyte(0)                   -- crypt key
    socket:writeBytes(data)
    socket:flush()
end

function PacketBuffer:read(socket, bytesAvailable)
    if self._length == -1 then
        if bytesAvailable >= HEADER_LEN + 2 then
            self._length = socket:readUshort()
            self._length = self._length - HEADER_LEN
            self._op = socket:readUshort()
            self._csn = socket:readUshort()
            self._ssn = socket:readUshort()
            self._cryptType = socket:readUbyte()
            self._cryptKey = socket:readUbyte()
            bytesAvailable = bytesAvailable - (HEADER_LEN - 2)
            assert(self._length >= 0, self._length)
        else
            return
        end
    end

    if bytesAvailable >= self._length then
        local bytes
        if self._length == 0 then
            bytes = ""
        else
            bytes = socket:readBytes(self._length)
        end
        self._length = -1
        return self._op, self._csn, self._ssn, bytes
    end
end

return PacketBuffer