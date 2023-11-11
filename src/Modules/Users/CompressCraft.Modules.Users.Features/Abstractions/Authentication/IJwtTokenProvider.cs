using CompressCraft.Core.Abstractions.Abstractions.Authentication;

namespace CompressCraft.Modules.Users.Features.Abstractions.Authentication;

public interface IJwtTokenProvider
{
    JsonWebToken CreateToken(
        string userGid,
        string userName,
        HashSet<string> permissions
        );
}
