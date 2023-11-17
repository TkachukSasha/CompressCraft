using CompressCraft.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Infrastructure.Database.Repositories;

internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(
        CompressCraftContext dbContext
    ) : base(dbContext)
    {
    }

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        => await _dbContext.Users.SingleOrDefaultAsync(x => x.UserName == userName, cancellationToken);
}
