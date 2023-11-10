namespace CompressCraft.Modules.Encodings.ArchitectureTests;

public class LayerTests : BaseArchitectureTest
{
    [Fact]
    public void Domain_Should_NotHaveDependencyOnOther_Projects()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOnAny()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}

