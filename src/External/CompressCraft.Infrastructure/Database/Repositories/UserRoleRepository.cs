using CompressCraft.Domain.Users;

namespace CompressCraft.Infrastructure.Database.Repositories;

internal sealed class UserRoleRepository : IUserRoleRepository
{
    private readonly CompressCraftContext _context;

    public UserRoleRepository(CompressCraftContext context) => _context = context;

    public void Insert(UserRole userRole)
        => _context.UserRoles.Add(userRole);
}
