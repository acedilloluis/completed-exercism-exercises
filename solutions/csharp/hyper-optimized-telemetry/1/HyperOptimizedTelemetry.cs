public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        //unsigned short prefix byte: 2
        if (reading >= UInt16.MinValue && reading <= UInt16.MaxValue)
            return [2, ..BitConverter.GetBytes(reading)];   
        //signed int prefix byte: 252
        if (reading > UInt16.MaxValue && reading <= Int32.MaxValue)
            return [252, ..BitConverter.GetBytes(reading)];
        //unsigned int prefix byte: 4
        if(reading > Int32.MaxValue && reading <= UInt32.MaxValue)
            return [4, ..BitConverter.GetBytes(reading)];
        //signed long prefix byte: 248
        if(reading > UInt32.MaxValue && reading <= Int64.MaxValue)
            return [248, ..BitConverter.GetBytes((Int64)reading)];
        //signed short prefix byte: 254
        if (reading < UInt16.MinValue && reading >= Int16.MinValue)
        {
            byte[] bytes = BitConverter.GetBytes((Int16)reading);
            return [254, ..bytes, ..new byte[9 - bytes.Length - 1]];   
        }
        //signed int prefix byte: 252
        if (reading < Int16.MinValue && reading >= Int32.MinValue)
        {
            byte[] bytes = BitConverter.GetBytes((Int32)reading);
            return [252, ..bytes, ..new byte[9 - bytes.Length - 1]];
        }
        //signed long prefix byte: 248
        if (reading < Int32.MinValue && reading >= Int64.MinValue)
            return [248, ..BitConverter.GetBytes(reading)];
        else
            return BitConverter.GetBytes(reading);
    }

    public static long FromBuffer(byte[] buffer) =>
        buffer[0] switch
        {    
            2 => BitConverter.ToUInt16(buffer, 1),
            254 => BitConverter.ToInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            248 => BitConverter.ToInt64(buffer, 1),
            _ => 0
        };
}
