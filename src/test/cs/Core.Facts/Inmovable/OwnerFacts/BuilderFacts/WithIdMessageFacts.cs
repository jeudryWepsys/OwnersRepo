using RI.Novus.Core.Inmovable.Owners;
using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

internal sealed class WithIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Owner.Builder, Owner, Id>
{
    protected override Context BuildContext()
    {
        return new Context(new Owner.Builder(),
                CreateBuilderWithoutId(),
                CreateUsedBuilder(),
                CreateBuilderWithoutId(), Id.Generate(), Id.Generate());
    }
    
    protected override void SetProperty(Owner.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(Owner buildable) => buildable.Id;
}
