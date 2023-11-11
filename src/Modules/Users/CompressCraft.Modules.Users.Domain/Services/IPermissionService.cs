namespace CompressCraft.Modules.Users.Domain.Services;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(UserId userId);
}
