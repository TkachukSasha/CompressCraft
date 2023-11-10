using System.Text;
using CompressCraft.Core.Abstractions.Abstractions.Kernel;
using CompressCraft.Modules.Encodings.Domain.Builders.Chunks;

namespace CompressCraft.Modules.Encodings.Domain.Builders;

public sealed class VariableLengthCodeEncoderBuilder : IBuilder
{
    private VariableLengthCodeEncoderBuilder(string content, IEnumerable<EncodingTableElement> encodingTableElements)
        => (Content, EncodingTableElements) = (content, encodingTableElements);

    public string Content { get; private set; }

    public IEnumerable<EncodingTableElement> EncodingTableElements { get; private set; } = Enumerable.Empty<EncodingTableElement>();

    public static VariableLengthCodeEncoderBuilder Init(string content, IEnumerable<EncodingTableElement> encodingTableElements)
        => new VariableLengthCodeEncoderBuilder(content, encodingTableElements);

    public VariableLengthCodeEncoderBuilder PrepareContent()
    {
        var response = new StringBuilder();

        foreach (char symbol in Content)
        {
            if (char.IsUpper(symbol))
            {
                response.Append("!");
                response.Append(char.ToLower(symbol));

                continue;
            }

            response.Append(symbol);
        }

        Content = response.ToString();

        return this;
    }

    private byte[] Encode(int chunkSize)
    {
        var response = new StringBuilder();

        foreach (char symbol in Content)
        {
            if (EncodingTableElements.FirstOrDefault(x => x.Symbol == symbol) is null)
                throw new ArgumentNullException(symbol.ToString());

            response.Append(EncodingTableElements.FirstOrDefault(x => x.Symbol == symbol)!.Code);
        }

        BinaryChunks chunks = SplitByChunks(response.ToString(), chunkSize);

        List<byte> encodedBytes = new List<byte>();

        foreach (var binaryChunk in chunks)
        {
            byte encodedByte = binaryChunk.Byte();
            encodedBytes.Add(encodedByte);
        }

        return encodedBytes.ToArray();
    }

    private BinaryChunks SplitByChunks(string content, int chunkSize)
    {
        int contentLength = content.Length;

        int chunksCount = contentLength / chunkSize;

#pragma warning disable S1854 // Unused assignments should be removed
        if (contentLength % chunkSize != 0) chunksCount++;
#pragma warning restore S1854 // Unused assignments should be removed

        BinaryChunks result = new BinaryChunks();

        StringBuilder buffer = new StringBuilder();

        for (int i = 0; i < contentLength; i++)
        {
            buffer.Append(content[i]);

            if ((i + 1) % chunkSize == 0)
            {
                result.Add(new BinaryChunk(Convert.ToByte(buffer.ToString(), 2)));
                buffer.Clear();
            }
        }

        if (buffer.Length != 0)
        {
            string lastChunk = buffer.ToString();
            lastChunk += new string('0', chunkSize - lastChunk.Length);

            result.Add(new BinaryChunk(Convert.ToByte(lastChunk, 2)));
        }

        return result;
    }

    public byte[] Build()
        => Encode(8);
}
