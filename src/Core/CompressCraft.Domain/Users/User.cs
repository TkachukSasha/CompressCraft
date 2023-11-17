using System.ComponentModel.DataAnnotations.Schema;
using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Abstractions.Kernel;
using CompressCraft.Domain.Users.ValueObjects;

namespace CompressCraft.Domain.Users;

public sealed class User : Entity<UserId>
{
    private User(
        UserId id,
        UserName userName,
        Password password
    ) : base(id)
    {
        UserName = userName;
        Password = password;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("user_name")]
    public UserName UserName { get; }

    [Column("password")]
    public Password Password { get; }

    public ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();

    public static Result<User> Init(
        string userName,
        string password
    )
    {
        if (string.IsNullOrWhiteSpace(userName))
            return Result.Failure<User>(UsersErrors.UserErrors.UserNameMustBeProvide);

        if (string.IsNullOrWhiteSpace(password))
            return Result.Failure<User>(UsersErrors.UserErrors.PasswordMustBeProvide);

        return new User(new UserId(), new UserName(userName), new Password(password));
    }
}

public sealed class UserId : TypeId
{
    public UserId()
        : this(ShortGuid.GenerateShortGuid()) { }

    public UserId(string value) : base(value) { }

    public static implicit operator UserId(string id) => new(id);

    public static implicit operator string(UserId id) => id.Value;

    public override string ToString() => Value.ToString();
}
