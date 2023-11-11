namespace CompressCraft.Modules.Users.Infrastructure.Authentication;

internal static class Extensions
{
    internal static long ToTimestamp(this DateTime date)
    {
        var centuryBegin = DateTime.UnixEpoch;

        var expectedDate = date.Subtract(new TimeSpan(centuryBegin.Ticks));

        return expectedDate.Ticks / 10000;
    }
}
