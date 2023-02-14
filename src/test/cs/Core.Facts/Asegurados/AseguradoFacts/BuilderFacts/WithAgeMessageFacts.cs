using RI.Novus.Core.Asegurados;
using Triplex.ProtoDomainPrimitives.Numerics;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithDocumentIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Age>
{
    protected override Context BuildContext()
    {
        return new Context(new Asegurado.Builder(),
                    CreateBuilderHelper.CreateBuilderWithoutAge(),
                    CreateBuilderHelper.CreateUsedBuilder(),
                    CreateBuilderHelper.CreateBuilderWithoutAge(),
                    new Age(new PositiveInteger(1)),
                    new Age(new PositiveInteger(2)));
    }

    protected override Age GetProperty(Asegurado buildable)
        => buildable.Age;

    protected override void SetProperty(Asegurado.Builder builder, Age value)
        => builder.WithAge(value);
}
