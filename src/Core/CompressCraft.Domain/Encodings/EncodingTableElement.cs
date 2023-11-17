using System.ComponentModel.DataAnnotations.Schema;
using CompressCraft.Domain.Abstractions.Errors;

namespace CompressCraft.Domain.Encodings;

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EncodingTableElement()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("symbol")]
    public char Symbol { get; }

    [Column("code")]
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
