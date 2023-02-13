using RI.Novus.Core.Inmovable.Properties;
using static RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.BuilderFacts;

internal sealed class WithOwnerIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Property.Builder, Property, Id>
{
    protected override Context BuildContext()
    {
        return new Context(new Property.Builder(),
                CreateBuilderWithoutId(),
                CreateUsedBuilder(),
                CreateBuilderWithoutId(), Id.Generate(), Id.Generate());
    }
    
    protected override void SetProperty(Property.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(Property buildable) => buildable.Id;
}
