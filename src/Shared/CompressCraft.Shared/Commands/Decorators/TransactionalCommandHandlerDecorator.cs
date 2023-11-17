using CompressCraft.Shared.Abstractions.Attributes;
using CompressCraft.Shared.Abstractions.Commands;
using CompressCraft.Shared.Abstractions.Database;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Shared.Commands.Decorators
{
    [Decorator]
    internal sealed class TransactionalCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public TransactionalCommandHandlerDecorator(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await unitOfWork.ExecuteAsync(() => handler.HandleAsync(command, cancellationToken));
        }
    }
}
