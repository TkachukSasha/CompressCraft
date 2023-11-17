using CompressCraft.Application.Abstractions.Authentication;
using CompressCraft.Application.Abstractions.Storage;
using CompressCraft.Application.Features.Users.Dtos;
using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.Services;
using CompressCraft.Domain.Users.ValueObjects;
using CompressCraft.Shared.Abstractions.Commands;

namespace CompressCraft.Application.Features.Users;

public record RegisterCommand(string UserName, string Password) : ICommand;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IPermissionService _permissionService;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IHttpContextStorage _httpContextStorage;

    public RegisterCommandHandler(
       IUserRepository userRepository,
       IUserRoleRepository userRoleRepository,
       IPasswordManager passwordManager,
       IPermissionService permissionService,
       IJwtTokenProvider jwtTokenProvider,
       IHttpContextStorage httpContextStorage
   )
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _passwordManager = passwordManager;
        _permissionService = permissionService;
        _jwtTokenProvider = jwtTokenProvider;
        _httpContextStorage = httpContextStorage;
    }

    public async Task HandleAsync(RegisterCommand command, CancellationToken cancellationToken = default)
    {
        var user = User.Init(
            new UserName(command.UserName),
            _passwordManager.Secure(command.Password)
        ).Value;

        _userRepository.Insert(user);

        var userRole = UserRole.Init(user.Id, Role.Admin.Value);

        _userRoleRepository.Insert(userRole);

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
