using CompressCraft.Domain.Abstractions.Authentication;

namespace CompressCraft.Application.Abstractions.Authentication;

public interface IJwtTokenProvider
{
    JsonWebToken CreateToken(
        string userGid,
        string userName,
        HashSet<string> permissions
        );
}
