using CompressCraft.Core.Abstractions.Abstractions.Kernel;

namespace CompressCraft.Modules.Encodings.Core.Domain;

public class EncodingTableLanguage : Enumeration<EncodingTableLanguage>
{
    public static readonly EncodingTableLanguage Ukrainian = new UkrainianLanguage();
    public static readonly EncodingTableLanguage English = new EnglishLanguage();

    public EncodingTableLanguage(
        string value,
        string name
    ) : base(value, name)
    {
    }

    public ICollection<EncodingTable>? EncodingTables { get; set; } = default;

    public ICollection<EncodingFile>? EncodingFiles { get; set; } = default;

    private sealed class UkrainianLanguage : EncodingTableLanguage
    {
        public UkrainianLanguage()
            : base(ShortGuid.GenerateShortGuid(), "ua-UA") { }
    }

    private sealed class EnglishLanguage : EncodingTableLanguage
    {
        public EnglishLanguage()
            : base(ShortGuid.GenerateShortGuid(), "en-US") { }
    }
}
