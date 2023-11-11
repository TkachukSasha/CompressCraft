using CompressCraft.Core.Abstractions.Time;

namespace CompressCraft.Core.Time;

internal sealed class UtcClock : IUtcClock
{
    public DateTime GetUtcClock()
        => DateTime.UtcNow;
}
