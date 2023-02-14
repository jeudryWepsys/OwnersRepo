using RI.Novus.Core.Inmovable.Owners;
using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

internal sealed class WithNameMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Owner.Builder, Owner, Name>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Owner.Builder(),
            missingTestedProperty: CreateBuilderWithoutName(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutName(),
            firstValue: Name.From("Owner1"),
            secondValue: Name.From("Owner2"));
    }

    protected override void SetProperty(Owner.Builder builder, Name value)
        => builder.WithName(value);

    protected override Name GetProperty(Owner buildable) => buildable.Name;
}
