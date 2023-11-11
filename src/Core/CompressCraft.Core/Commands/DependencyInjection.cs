﻿using System.Reflection;
using CompressCraft.Core.Abstractions.Abstractions.Attributes;
using CompressCraft.Core.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CompressCraft.Core.Commands;

public static class DependencyInjection
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assemblies = Assembly.GetCallingAssembly();

        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}