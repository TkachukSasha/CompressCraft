namespace CompressCraft.Domain.Users.ValueObjects;

public record PermissionName(string Value)
{
    public static implicit operator PermissionName(string value) => value is null ? string.Empty : new PermissionName(value);
    public static implicit operator string(PermissionName value) => value.Value;
}
