using System.Reflection;
using CompressCraft.Modules.Encodings.Domain;

namespace CompressCraft.Modules.Encodings.ArchitectureTests;

public abstract class BaseArchitectureTest
{
    protected static readonly Assembly DomainAssembly = typeof(AssemblyMarker).Assembly;
}
