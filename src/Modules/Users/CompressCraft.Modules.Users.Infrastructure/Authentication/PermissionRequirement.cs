using Microsoft.AspNetCore.Authorization;

namespace CompressCraft.Modules.Users.Infrastructure.Authentication;

internal sealed class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
        => Permission = permission;

    public string Permission { get; private set; }
}
