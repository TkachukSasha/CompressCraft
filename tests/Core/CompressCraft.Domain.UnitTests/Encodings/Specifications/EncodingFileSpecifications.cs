using CompressCraft.Domain.Encodings;

namespace CompressCraft.Domain.UnitTests.Encodings.Specifications;

public class EncodingFileSpecifications
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Init_Should_Failed_WhenFilePathAreNullOrWhiteSpace(string filePath)
    {
        // Act
        var file = EncodingFile.Init(
            filePath,
            "1",
            "2",
            100,
            50
        );

        // Assert
        file.IsFailure.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    public void Init_Should_Failed_WhenEncodingSizeAreSmallerThanZero(uint encodingSize)
    {
        // Act
        var file = EncodingFile.Init(
            "https://test.com",
            "1",
            "2",
            encodingSize,
            50
        );

        // Assert
        file.IsFailure.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    public void Init_Should_Failed_WhenDefaultSizeAreSmallerThanZero(uint defaultSize)
    {
        // Act
        var file = EncodingFile.Init(
            "https://test.com",
            "1",
            "2",
            100,
            defaultSize
        );

        // Assert
        file.IsFailure.Should().BeTrue();
    }
}
