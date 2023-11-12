namespace CompressCraft.Application.Abstractions.Storage;

public interface IHttpContextStorage
{
    void Set<TEntity>(string key, TEntity entity);
    object? Get(string key);
}
