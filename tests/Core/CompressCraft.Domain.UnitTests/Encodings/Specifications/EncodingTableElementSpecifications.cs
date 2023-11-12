using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Encodings;

namespace CompressCraft.Domain.UnitTests.Encodings.Specifications;

public class EncodingTableElementSpecifications
{
    [Theory]
    [InlineData(' ', "")]
    [InlineData(' ', null)]
    public void Init_Should_Failed_WhenCodeIsInvalid(char symbol, string code)
    {
        // Act
        Result<EncodingTableElement> result = EncodingTableElement.Init(symbol, code);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(EncodingErrors.EncodingTableElementErrors.EncodingTableElementCodeMustBeProvide);
    }

    [Theory]
    [InlineData(' ', "324242")]
    [InlineData('a', "54")]
    public void Init_Should_ReturnEncodingTableElement_WhenIsValid(char symbol, string code)
    {
        // Act
        Result<EncodingTableElement> result = EncodingTableElement.Init(symbol, code);

        // Assert
        result.Value.Should().NotBeNull();
    }
}
