﻿using CompressCraft.Domain.Abstractions.Kernel;

namespace CompressCraft.Domain.Encodings;

public class EncodingAlgorithm : Enumeration<EncodingAlgorithm>
{
    public static readonly EncodingAlgorithm Ukrainian = new EncodingVariableLengthAlgorithm();
    public static readonly EncodingAlgorithm English = new EncodingShannonFanoAlgorithm();

    public EncodingAlgorithm(
        string value,
        string name
    ) : base(value, name)
    {
    }

    public ICollection<EncodingFile>? EncodingFiles { get; } = default;

    private sealed class EncodingVariableLengthAlgorithm : EncodingAlgorithm
    {
        public EncodingVariableLengthAlgorithm()
            : base(ShortGuid.GenerateShortGuid(), "variable_length_code") { }
    }

    private sealed class EncodingShannonFanoAlgorithm : EncodingAlgorithm
    {
        public EncodingShannonFanoAlgorithm()
            : base(ShortGuid.GenerateShortGuid(), "shannon_fano") { }
    }
}
