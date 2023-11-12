namespace CompressCraft.Domain.Users.Services;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(UserId userId);
}
