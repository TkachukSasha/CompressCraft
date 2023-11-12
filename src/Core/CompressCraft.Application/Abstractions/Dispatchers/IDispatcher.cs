using CompressCraft.Application.Abstractions.Commands;
using CompressCraft.Application.Abstractions.Queries;

namespace CompressCraft.Application.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
