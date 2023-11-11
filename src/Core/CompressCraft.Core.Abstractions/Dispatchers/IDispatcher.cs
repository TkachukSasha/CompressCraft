using CompressCraft.Core.Abstractions.Commands;
using CompressCraft.Core.Abstractions.Queries;

namespace CompressCraft.Core.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
