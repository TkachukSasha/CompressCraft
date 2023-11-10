using System.Text;
using CompressCraft.Core.Abstractions.Abstractions.Kernel;
using CompressCraft.Modules.Encodings.Domain.Builders.Trees;

namespace CompressCraft.Modules.Encodings.Domain.Builders;

public sealed class VariableLengthCodeDecoderBuilder : IBuilder
{
    private VariableLengthCodeDecoderBuilder(byte[] data, IEnumerable<EncodingTableElement> encodingTableElements, DecodingTreeNode decodingTree)
        => (EncodedData, EncodingTableElements, DecodingTree) = (data, encodingTableElements, decodingTree);

    public byte[] EncodedData { get; private set; }

    public string Content { get; private set; } = string.Empty;

    private DecodingTreeNode DecodingTree { get; set; }

    public IEnumerable<EncodingTableElement> EncodingTableElements { get; private set; }

    public static VariableLengthCodeDecoderBuilder Init(byte[] data, IEnumerable<EncodingTableElement> encodingTableElements)
        => new VariableLengthCodeDecoderBuilder(data, encodingTableElements, new DecodingTreeNode().Get(encodingTableElements));

    public VariableLengthCodeDecoderBuilder Decode()
    {
        var response = new StringBuilder();

        foreach (byte code in EncodedData)
        {
            var binChunk = ConvertBytesToString(code);
            response.Append(binChunk);
        }

        var decodedText = DecodingTree.Decode(response.ToString());

        ExportText(decodedText);

        return this;
    }

    private void ExportText(string content)
    {
        var response = new StringBuilder();

        bool isCapital = false;

        foreach (char symbol in content)
        {
            if (isCapital)
            {
                response.Append(char.ToUpper(symbol));
                isCapital = false;
                continue;
            }

            if (symbol == '!') isCapital = true;
            else response.Append(symbol);
        }

        Content = response.ToString().TrimEnd();
    }

    private string ConvertBytesToString(byte code)
        => Convert.ToString(code, 2).PadLeft(8, '0');

    public string Build()
        => Content;
}
