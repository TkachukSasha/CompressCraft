using System.ComponentModel.DataAnnotations.Schema;
using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Abstractions.Kernel;

namespace CompressCraft.Domain.Encodings;

public sealed class EncodingTable : Entity<EncodingTableId>
{
    private EncodingTable(
        EncodingTableId id,
        string encodingLanguageId,
        IEnumerable<EncodingTableElement> elements
    ) : base(id)
    {
        EncodingLanguageId = encodingLanguageId;
        Elements = elements;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EncodingTable()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("encoding_language_id")]
    public string EncodingLanguageId { get; }

    [Column("elements")]
    public IEnumerable<EncodingTableElement> Elements { get; }

    public static Result<EncodingTable> Init(
        string encodingLanguageId,
        IEnumerable<EncodingTableElement> elements
    )
    {
        if (!elements.Any() || elements is null)
            return Result.Failure<EncodingTable>(EncodingErrors.EncodingTableErrors.EncodingTableElementsMustBeProvide);

        return new EncodingTable(new EncodingTableId(), encodingLanguageId, elements);
    }
}

public sealed class EncodingTableId : TypeId
{
    public EncodingTableId()
        : this(ShortGuid.GenerateShortGuid()) { }

    public EncodingTableId(string value) : base(value) { }

    public static implicit operator EncodingTableId(string id) => new(id);

    public static implicit operator string(EncodingTableId id) => id.Value;

    public override string ToString() => Value.ToString();
}

