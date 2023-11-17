using CompressCraft.Application.Abstractions.Authentication;
using CompressCraft.Application.Abstractions.Storage;
using CompressCraft.Application.Features.Users.Dtos;
using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.Services;
using CompressCraft.Shared.Abstractions.Commands;

namespace CompressCraft.Application.Features.Users;

public record LoginCommand(string UserName, string Password) : ICommand;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IPermissionService _permissionService;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IHttpContextStorage _httpContextStorage;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IPermissionService permissionService,
        IJwtTokenProvider jwtTokenProvider,
        IHttpContextStorage httpContextStorage
    )
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _permissionService = permissionService;
        _jwtTokenProvider = jwtTokenProvider;
        _httpContextStorage = httpContextStorage;
    }

    public async Task HandleAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.GetByUserNameAsync(command.UserName, cancellationToken);

        if (user is null)
            throw new ArgumentNullException($"{nameof(User)}, user with [{command.UserName}] not found!");

        if (string.IsNullOrWhiteSpace(command.Password))
            throw new ArgumentNullException($"{nameof(User)}, user password [{command.Password}] is incorrect!");

        bool isValidPassword = _passwordManager.Validate(command.Password, user.Password);

        if (!isValidPassword)
            throw new ArgumentException($"{nameof(User)}, password [{command.Password}] isn't valid");

        HashSet<string>? permissions = await _permissionService.GetPermissionsAsync(user.Id);

        var jwt = _jwtTokenProvider.CreateToken(
            user.Id,
            user.UserName,
            permissions
        );

        _httpContextStorage.Set("auth_data", new AuthDto(
            user.Id,
            user.UserName,
            jwt.AccessToken,
            jwt.Expires
        ));
    }
}
