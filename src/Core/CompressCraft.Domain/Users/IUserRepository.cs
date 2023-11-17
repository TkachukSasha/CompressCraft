namespace CompressCraft.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);

    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);

    void Insert(User user);
}
