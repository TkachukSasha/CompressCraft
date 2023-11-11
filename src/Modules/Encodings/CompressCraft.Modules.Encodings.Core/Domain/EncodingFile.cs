using CompressCraft.Core.Abstractions.Abstractions.Errors;
using CompressCraft.Core.Abstractions.Abstractions.Kernel;

namespace CompressCraft.Modules.Encodings.Core.Domain;

public sealed class EncodingFile : Entity<EncodingFileId>
{
    private EncodingFile(
        EncodingFileId id,
        string filePath,
        string encodingAlgorithmId,
        string encodingTableLanguageId,
        uint encodingSize,
        uint defaultSize
    ) : base(id)
    {
        FilePath = filePath;
        EncodingAlgorithmId = encodingAlgorithmId;
        EncodingTableLanguageId = encodingTableLanguageId;
        EncodingSize = encodingSize;
        DefaultSize = defaultSize;
    }

    public string FilePath { get; }

    public string EncodingAlgorithmId { get; }

    public string EncodingTableLanguageId { get; }

    public uint EncodingSize { get; }

    public uint DefaultSize { get; }

    public static Result<EncodingFile> Init(
        string filePath,
        string encodingAlgorithmId,
        string encodingTableLanguageId,
        uint encodingSize,
        uint defaultSize
    )
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return Result.Failure<EncodingFile>(EncodingErrors.EncodingFileErrors.EncodingFilePathMustBeProvide);

        if (encodingSize == 0)
            return Result.Failure<EncodingFile>(EncodingErrors.EncodingFileErrors.EncodingFileSizeMustBeGreaterThanZero);

        if (defaultSize == 0)
            return Result.Failure<EncodingFile>(EncodingErrors.EncodingFileErrors.EncodingFileDefaultSizeMustBeGreaterThanZero);

        return new EncodingFile(new EncodingFileId(), filePath, encodingAlgorithmId, encodingTableLanguageId, encodingSize, defaultSize);
    }
}

public sealed class EncodingFileId : TypeId
{
    public EncodingFileId()
        : this(ShortGuid.GenerateShortGuid()) { }

    public EncodingFileId(string value) : base(value) { }

    public static implicit operator EncodingFileId(string id) => new(id);

    public static implicit operator string(EncodingFileId id) => id.Value;

    public override string ToString() => Value.ToString();
}

