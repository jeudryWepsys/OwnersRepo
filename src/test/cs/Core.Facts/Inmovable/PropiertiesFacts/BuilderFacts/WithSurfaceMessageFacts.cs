using static RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.CreateBuilderHelper;
using RI.Novus.Core.Inmovable.Properties;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.BuilderFacts;

internal class WithSurfaceMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Property.Builder, Property, Surface>{
    protected override Context BuildContext()
    {
        return new Context(empty: new Property.Builder(),
            missingTestedProperty: CreateBuilderWithoutSurface(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutSurface(),
            firstValue: Surface.From(123.45M),
            secondValue: Surface.From(125.3M));
    }

    protected override void SetProperty(Property.Builder builder, Surface value)
        => builder.WithSurface(value);

    protected override Surface GetProperty(Property buildable) => buildable.Surface;
}
