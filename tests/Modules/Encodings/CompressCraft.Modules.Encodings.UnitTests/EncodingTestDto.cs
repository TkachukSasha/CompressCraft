using CompressCraft.Modules.Encodings.Core.Domain;

namespace CompressCraft.Modules.Encodings.UnitTests;

internal class EncodingTestDto
{
    private EncodingTestDto(
        string? message,
        IEnumerable<EncodingTableElement>? elements
    )
    {
        Message = message;
        Elements = elements;
    }

    internal string? Message { get; }

    internal IEnumerable<EncodingTableElement>? Elements { get; }

    internal static EncodingTestDto Init(
        string? message,
        IEnumerable<EncodingTableElement>? elements
    ) => new EncodingTestDto(message, elements);
}
