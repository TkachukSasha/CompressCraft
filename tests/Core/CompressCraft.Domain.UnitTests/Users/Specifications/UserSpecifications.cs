using CompressCraft.Domain.Users;

namespace CompressCraft.Domain.UnitTests.Users.Specifications;

public class UserSpecifications
{
    [Theory]
    [InlineData(" ")]
    [InlineData(null)]
    public void Init_Should_Failed_WhenUserNameIsNullOrWhiteSpace(string userName)
    {
        // Act
        var user = User.Init(
            userName,
            "23423432"
        );

        // Assert
        user.IsFailure.Should().BeTrue();
    }

    [Theory]
    [InlineData(" ")]
    [InlineData(null)]
    public void Init_Should_Failed_WhenPasswordIsNullOrWhiteSpace(string password)
    {
        // Act
        var user = User.Init(
            "test",
            password
        );

        // Assert
        user.IsFailure.Should().BeTrue();
    }
}
