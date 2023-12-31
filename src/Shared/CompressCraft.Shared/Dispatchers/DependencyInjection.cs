﻿using CompressCraft.Shared.Abstractions.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Shared.Dispatchers;

public static class DependencyInjection
{
    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services.AddSingleton<IDispatcher, Dispatcher>();
}
