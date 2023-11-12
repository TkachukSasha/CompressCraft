using CompressCraft.Domain.Abstractions.Errors;

namespace CompressCraft.Domain.Encodings;

public static class EncodingErrors
{
    public static class EncodingTableErrors
    {
        public static readonly Error EncodingTableElementsMustBeProvide = new Error(
            $"[{nameof(EncodingTable)}]",
            "Encoding table elements must be provide"
        );
    }

    public static class EncodingFileErrors
    {
        public static readonly Error EncodingFilePathMustBeProvide = new Error(
            $"[{nameof(EncodingFile)}]",
            "Encoding file path must be provide"
        );

        public static readonly Error EncodingFileSizeMustBeGreaterThanZero = new Error(
            $"[{nameof(EncodingFile)}]",
            "Encoding file size must be greater than zero"
        );

        public static readonly Error EncodingFileDefaultSizeMustBeGreaterThanZero = new Error(
           $"[{nameof(EncodingFile)}]",
           "Encoding file default size must be greater than zero"
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
