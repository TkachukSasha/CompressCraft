using CompressCraft.Domain.Users;

namespace CompressCraft.Domain.UnitTests.Users.Specifications;

public class PermissionSpecifications
{
    [Theory]
    [InlineData(" ")]
    [InlineData(null)]
    public void Init_Should_Failed_WhenPermissionNameIsNullOrWhiteSpace(string permissionName)
    {
        // Act
        var permission = Permission.Init(permissionName);

        // Assert
        permission.IsFailure.Should().BeTrue();
    }
}
