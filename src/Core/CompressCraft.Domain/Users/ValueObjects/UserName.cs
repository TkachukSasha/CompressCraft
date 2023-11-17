namespace CompressCraft.Domain.Users.ValueObjects;

public record UserName(string Value)
{
    public static implicit operator UserName(string value) => value is null ? string.Empty : new UserName(value);
    public static implicit operator string(UserName value) => value.Value;
}
