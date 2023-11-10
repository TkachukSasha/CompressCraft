using CompressCraft.Core.Abstractions.Abstractions.Errors;

namespace CompressCraft.Modules.Encodings.Domain;

public static class EncodingErrors
{
    public static class EncodingTableErrors
    {
        public static readonly Error EncodingTableElementsMustBeProvide = new Error(
            $"[{nameof(EncodingTable)}]",
            "Encoding table elements must be provide"
        );
    }

    public static class EncodingTableElementErrors
    {
        public static readonly Error EncodingTableElementCodeMustBeProvide = new Error(
            $"[{nameof(EncodingTableElement)}]",
            "Encoding table element code must be provide"
        );
    }
}
