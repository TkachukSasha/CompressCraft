using CompressCraft.Core.Abstractions.Abstractions.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CompressCraft.Core.Abstractions.Abstractions.Attributes;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString()) { }
}

