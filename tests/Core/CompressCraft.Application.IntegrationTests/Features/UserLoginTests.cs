using CompressCraft.Application.Features.Users;
using CompressCraft.Domain.Users;

namespace CompressCraft.Application.IntegrationTests.Features;

public class UserLoginTests : BaseIntegrationTest
{
    public UserLoginTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Login_ShouldFailed_WhenUserIsNotFound_Cause_UserName_IsNullOrWhiteSpace(string userName)
    {
        // Arrange
        var command = new LoginCommand(userName, "test_password");

        // Act
        Task Action() => _dispatcher.SendAsync(command, default);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(Action);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Login_ShouldFailed_PasswordIsNotValid(string password)
    {
        // Arrange
        var command = new LoginCommand("admin", password);

        // Act
        Task Action() => _dispatcher.SendAsync(command, default);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(Action);
    }

    [Fact]
    public async Task Login_Should_Successed_WhenRequestDataIsValid()
    {
        // Arrange
        var user = User.Init(
            "admin",
            _passwordManager.Secure("admin_password")
        ).Value;

        await _dbContext.Users.AddAsync(user);

        var userRole = UserRole.Init(
            user.Id,
            Role.Admin.Value
        );

        await _dbContext.UserRoles.AddAsync(userRole);

        await _dbContext.SaveChangesAsync();

        var command = new LoginCommand("admin", "admin_password");

        // Act
        await _dispatcher.SendAsync(command, default);

        var authData = _httpContextStorage.Get("auth_data");

        // Assert
        Assert.NotNull(authData);
    }
}
