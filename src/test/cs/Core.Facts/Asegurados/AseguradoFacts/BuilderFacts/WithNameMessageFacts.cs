using RI.Novus.Core.Asegurados;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithNameMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Name>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutName(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutName(),
            firstValue: Name.From("Asegurado1"),
            secondValue: Name.From("Asegurado2"));
    }

    protected override void SetProperty(Asegurado.Builder builder, Name value)
        => builder.WithName(value);

    protected override Name GetProperty(Asegurado buildable) => buildable.Name;
}
