using CompressCraft.Core.Abstractions.Abstractions.Errors;
using CompressCraft.Core.Abstractions.Abstractions.Kernel;

namespace CompressCraft.Modules.Encodings.Core.Domain;

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

    public string EncodingLanguageId { get; }

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

