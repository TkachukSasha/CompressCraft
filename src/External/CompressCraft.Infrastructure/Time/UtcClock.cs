using CompressCraft.Application.Abstractions.Time;

namespace CompressCraft.Infrastructure.Time;

internal sealed class UtcClock : IUtcClock
{
    public DateTime GetUtcClock()
        => DateTime.UtcNow;
}
