using RI.Novus.Core.Inmovable.Owners;
using Triplex.ProtoDomainPrimitives.Numerics;
using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

internal sealed class WithCodiaMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Owner.Builder, Owner, Codia>
{
    protected override Context BuildContext()
    {
        return new Context(new Owner.Builder(),
                    CreateBuilderWithoutCodia(),
                    CreateUsedBuilder(),
                    CreateBuilderWithoutCodia(),
                    new Codia(new PositiveInteger(1)),
                    new Codia(new PositiveInteger(2)));
    }
    
    
    protected override void SetProperty(Owner.Builder builder, Codia value)
        => builder.WithCodia(value);

    protected override Codia GetProperty(Owner buildable)
        => buildable.Codia;
}
