using CompressCraft.Core.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace CompressCraft.Core.Storage;

internal sealed class HttpContextStorage : IHttpContextStorage
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextStorage(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public void Set<TEntity>(string key, TEntity entity)
        => _httpContextAccessor.HttpContext?.Items.TryAdd(key, entity);

    public object? Get(string key)
    {
        if (_httpContextAccessor.HttpContext is null)
            return null;

        if (_httpContextAccessor.HttpContext.Items.TryGetValue(key, out var entity))
            return entity;

        return null;
    }
}
