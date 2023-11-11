using System.Reflection;
using CompressCraft.Modules.Encodings.Core;

namespace CompressCraft.Modules.Encodings.ArchitectureTests;

public abstract class BaseArchitectureTest
{
    protected static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}
