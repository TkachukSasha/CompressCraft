﻿namespace CompressCraft.Core.Abstractions.Abstractions.Kernel;

public abstract class TypeId : IEquatable<TypeId>
{
    public string Value { get; }

    protected TypeId(string value)
        => Value = value;

    public bool IsEmpty() => Value == string.Empty;

    public bool Equals(TypeId? other)
    {
        if (ReferenceEquals(null, other)) return false;

        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;

        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((TypeId)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static implicit operator string(TypeId typeId) => typeId.Value;

    public static bool operator ==(TypeId a, TypeId b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is not null && b is not null)
            return a.Value.Equals(b.Value);

        return false;
    }

    public static bool operator !=(TypeId a, TypeId b) => !(a == b);

    public override string ToString() => Value.ToString();
}
