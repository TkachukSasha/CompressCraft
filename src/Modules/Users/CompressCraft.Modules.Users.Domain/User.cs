using CompressCraft.Core.Abstractions.Abstractions.Kernel;
using CompressCraft.Modules.Users.Domain.ValueObjects;

namespace CompressCraft.Modules.Users.Domain;

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

    public static User Init(
        UserName userName,
        Password password
    ) => new User(new UserId(), userName, password);
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
