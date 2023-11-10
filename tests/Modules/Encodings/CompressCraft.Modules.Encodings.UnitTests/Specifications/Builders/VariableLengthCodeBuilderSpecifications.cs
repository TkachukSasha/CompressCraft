using System.Text;
using CompressCraft.Modules.Encodings.UnitTests.Utils;

namespace CompressCraft.Modules.Encodings.UnitTests.Specifications.Builders;

public class VariableLengthCodeBuilderSpecifications
{
    [Theory]
    [InlineData("ua-UA")]
    [InlineData("en-US")]
    public void DecodeContent_Should_BeAsProvidedMessage(string languageName)
    {
        // Arrange
        var languageId = CryptographyBuildersHelper.GetEncodingLanguageId(languageName);

        // Act
        CryptographyBuildersHelper.GetData(languageId, out byte[]? encodedData, out string? decodedData, out EncodingTestDto encodingDto);

        // Assert
        decodedData.Should().Be(encodingDto.Message);
    }

    [Theory]
    [InlineData("ua-UA")]
    [InlineData("en-US")]
    public void DecodeContentLength_Should_BeSmallerThanProvidedMessage(string languageName)
    {
        // Arrange
        var languageId = CryptographyBuildersHelper.GetEncodingLanguageId(languageName);

        // Act
        CryptographyBuildersHelper.GetData(languageId, out byte[]? encodedData, out string? decodedData, out EncodingTestDto encodingDto);

        // Assert
        byte[] messageBytes = Encoding.UTF8.GetBytes(encodingDto.Message ?? string.Empty);

        bool condition = messageBytes.Length > encodedData!.Length;

        condition.Should().BeTrue();
    }
}
