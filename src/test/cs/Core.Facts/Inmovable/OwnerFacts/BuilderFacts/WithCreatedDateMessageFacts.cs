using RI.Novus.Core.Inmovable.Owners;
using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;
using Owner = RI.Novus.Core.Inmovable.Owners.Owner;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

internal class WithCreatedMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Owner.Builder, Owner, CreatedDate>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Owner.Builder(),
            missingTestedProperty: CreateBuilderWithoutCreatedDate(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutCreatedDate(),
            firstValue: CreatedDate.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: CreatedDate.From(DateTimeOffset.UtcNow.AddHours(-2)));
    }

    protected override void SetProperty(Owner.Builder builder, CreatedDate value)
        => builder.WithCreatedDate(value);

    protected override CreatedDate GetProperty(Owner buildable) => buildable.CreatedDate;
}
