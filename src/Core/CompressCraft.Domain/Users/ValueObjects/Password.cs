namespace CompressCraft.Domain.Users.ValueObjects;

public record Password(string Value)
{
    public static implicit operator Password(string value) => value is null ? string.Empty : new Password(value);
    public static implicit operator string(Password value) => value.Value;
}

