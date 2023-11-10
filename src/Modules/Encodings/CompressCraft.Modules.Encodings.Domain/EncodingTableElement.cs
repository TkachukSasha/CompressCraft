using CompressCraft.Core.Abstractions.Abstractions.Errors;

namespace CompressCraft.Modules.Encodings.Domain;

public sealed class EncodingTableElement
{
    private EncodingTableElement(
        char symbol,
        string code
    )
    {
        Symbol = symbol;
        Code = code;
    }

    public char Symbol { get; }

    public string Code { get; }

    public static Result<EncodingTableElement> Init(
        char symbol,
        string code
    )
    {
        if (string.IsNullOrWhiteSpace(code))
            return Result.Failure<EncodingTableElement>(
                EncodingErrors.EncodingTableElementErrors.EncodingTableElementCodeMustBeProvide
            );

        return new EncodingTableElement(symbol, code);
    }
}
