using System.ComponentModel.DataAnnotations.Schema;
using CompressCraft.Domain.Abstractions.Errors;
using CompressCraft.Domain.Abstractions.Kernel;

namespace CompressCraft.Domain.Encodings;

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EncodingFile()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    [Column("file_path")]
    public string FilePath { get; }

    [Column("encoding_algorithm_id")]
    public string EncodingAlgorithmId { get; }

    [Column("encoding_table_language_id")]
    public string EncodingTableLanguageId { get; }

    [Column("encoding_size")]
    public uint EncodingSize { get; }

    [Column("default_size")]
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

