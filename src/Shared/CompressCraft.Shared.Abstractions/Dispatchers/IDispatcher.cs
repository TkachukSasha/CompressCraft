using CompressCraft.Shared.Abstractions.Commands;
using CompressCraft.Shared.Abstractions.Queries;

namespace CompressCraft.Shared.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
