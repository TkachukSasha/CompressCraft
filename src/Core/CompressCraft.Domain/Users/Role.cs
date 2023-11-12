using CompressCraft.Domain.Abstractions.Kernel;

namespace CompressCraft.Domain.Users;

public class Role : Enumeration<Role>
{
    public static readonly Role Admin = new AdminRole();
    public static readonly Role User = new UserRole();
    public static readonly Role Anonymous = new AnonymousRole();

    public Role(string value, string name)
        : base(value, name)
    {
    }

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public ICollection<User>? Users { get; set; } = default;

    private sealed class AdminRole : Role
    {
        public AdminRole()
            : base(ShortGuid.GenerateShortGuid(), "admin") { }
    }

    private sealed class UserRole : Role
    {
        public UserRole()
           : base(ShortGuid.GenerateShortGuid(), "user") { }
    }

    private sealed class AnonymousRole : Role
    {
        public AnonymousRole()
          : base(ShortGuid.GenerateShortGuid(), "anonymous") { }
    }
}
