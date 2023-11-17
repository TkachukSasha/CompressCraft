namespace CompressCraft.Shared.Abstractions.Database;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}
