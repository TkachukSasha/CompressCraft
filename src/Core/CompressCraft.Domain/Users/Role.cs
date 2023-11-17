using CompressCraft.Domain.Abstractions.Kernel;

namespace CompressCraft.Domain.Users;

public class Role : Enumeration<Role>
{
    public static readonly Role Admin = new AdminRole();
    public static readonly Role Participant = new ParticipantRole();

    public Role(string value, string name)
        : base(value, name)
    {
    }

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    private sealed class AdminRole : Role
    {
        public AdminRole()
            : base(ShortGuid.GenerateShortGuid(), "admin") { }
    }

    private sealed class ParticipantRole : Role
    {
        public ParticipantRole()
           : base(ShortGuid.GenerateShortGuid(), "participant") { }
    }
}
