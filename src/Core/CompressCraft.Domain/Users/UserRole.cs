using System.ComponentModel.DataAnnotations.Schema;

namespace CompressCraft.Domain.Users;

public sealed class UserRole
{
    private UserRole(
        string userId,
        string roleId
    )
    {
        UserId = userId;
        RoleId = roleId;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private UserRole()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("user_id")]
    public UserId UserId { get; }

    public User? User { get; }

    [Column("role_id")]
    public string RoleId { get; }

    public Role? Role { get; }

    public static UserRole Init(
        string userId,
        string roleId
    ) => new UserRole(userId, roleId);
}

