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

    public UserName UserName { get; }

    public Password Password { get; }

    public ICollection<Role> Roles { get; } = new List<Role>();

    public static Result<User> Init(
        UserName userName,
        Password password
    )
    {
        if (string.IsNullOrWhiteSpace(userName.Value))
            Result.Failure<User>(UsersErrors.UserErrors.UserNameMustBeProvide);

        if (string.IsNullOrWhiteSpace(password.Value))
            Result.Failure<User>(UsersErrors.UserErrors.PasswordMustBeProvide);

        return new User(new UserId(), userName, password);
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
