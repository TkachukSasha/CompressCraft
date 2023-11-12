namespace CompressCraft.Domain.Abstractions.Kernel;

public sealed class ShortGuid
{
    private ShortGuid() { }

    public static string GenerateShortGuid()
    {
        byte[] bytes = Guid.NewGuid().ToByteArray();

        string base64 = Convert.ToBase64String(bytes)
            .Replace("/", "_")
            .Replace("+", "-")
            .Substring(0, 22);

        return base64;
    }
}
