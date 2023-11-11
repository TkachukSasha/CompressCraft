﻿namespace CompressCraft.Core.Abstractions.Storage;

public interface IHttpContextStorage
{
    void Set<TEntity>(string key, TEntity entity);
    object? Get(string key);
}
