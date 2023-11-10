using CompressCraft.Core.Abstractions.Abstractions.Kernel;

namespace CompressCraft.Modules.Encodings.Domain;

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
