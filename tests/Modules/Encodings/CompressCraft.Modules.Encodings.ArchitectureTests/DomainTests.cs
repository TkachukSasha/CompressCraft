using CompressCraft.Core.Abstractions.Abstractions.Kernel;

namespace CompressCraft.Modules.Encodings.ArchitectureTests;

public class DomainTests : BaseArchitectureTest
{
    [Fact]
    public void Builders_Should_Implement_IBuilder_Interface()
    {
        var result = Types.InAssembly(Assembly)
            .That()
            .ImplementInterface(typeof(IBuilder))
            .Should()
            .HaveNameEndingWith("Builder")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Builders_Should_BeSealed()
    {
        var result = Types.InAssembly(Assembly)
            .That()
            .ImplementInterface(typeof(IBuilder))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
