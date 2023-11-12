using CompressCraft.Domain.Abstractions.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CompressCraft.Domain.Abstractions.Attributes;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString()) { }
}

