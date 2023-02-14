using RI.Novus.Core.Asegurados;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Id>
{
    protected override Context BuildContext()
    {
        return new Context(new Asegurado.Builder(),
                CreateBuilderWithoutId(),
                CreateUsedBuilder(),
                CreateBuilderWithoutId(), Id.Generate(), Id.Generate());
    }
    
    protected override void SetProperty(Asegurado.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(Asegurado buildable) => buildable.Id;
}
