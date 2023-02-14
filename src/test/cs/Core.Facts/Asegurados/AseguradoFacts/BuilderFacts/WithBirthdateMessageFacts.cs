using RI.Novus.Core.Asegurados;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal class WithCreatedMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Birthday>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutBirthdate(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutBirthdate(),
            firstValue: Birthday.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: Birthday.From(DateTimeOffset.UtcNow.AddHours(-2)));
    }

    protected override void SetProperty(Asegurado.Builder builder, Birthday value)
        => builder.WithBirthdate(value);

    protected override Birthday GetProperty(Asegurado buildable) => buildable.Birthday;
}
