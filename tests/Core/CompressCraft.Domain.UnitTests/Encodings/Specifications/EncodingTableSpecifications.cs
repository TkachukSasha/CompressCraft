using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Encodings;

namespace CompressCraft.Domain.UnitTests.Encodings.Specifications;

public class EncodingTableSpecifications
{
    [Fact]
    public void Init_Should_ReturnEncodingTable_WhenIsValid()
    {
        // Arrange
        EncodingTableLanguage? encodingLanguageId = EncodingTableLanguage.FromName("en-US");

        Result<EncodingTableElement> element = EncodingTableElement.Init(' ', "21342");

        List<EncodingTableElement> elements = new List<EncodingTableElement>() { element.Value };

        // Act
        var encodingTable = EncodingTable.Init(encodingLanguageId!.Value, elements);

        // Assert
        encodingTable.Should().NotBeNull();
    }

    [Fact]
    public void Init_Should_Failed_WhenElementsAreEmpty()
    {
        // Arrange
        EncodingTableLanguage? encodingLanguageId = EncodingTableLanguage.FromName("en-US");

        // Act
        var encodingTable = EncodingTable.Init(encodingLanguageId!.Value, Enumerable.Empty<EncodingTableElement>());

        // Assert
        encodingTable.IsFailure.Should().BeTrue();
    }
}
