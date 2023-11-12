﻿namespace CompressCraft.Application.Builders;

public class BinaryChunk
{
    public string Value { get; set; }

    public BinaryChunk(byte value)
    {
        Value = Convert.ToString(value, 2).PadLeft(8, '0');
    }

    public byte Byte()
        => Convert.ToByte(Value, 2);
}
