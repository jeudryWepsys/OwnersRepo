
using RI.Novus.Core.Inmovable.Owners;
using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

internal sealed class WithIdentificationNumberMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Owner.Builder, Owner, IdentificationNumber>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Owner.Builder(),
            missingTestedProperty: CreateBuilderWithoutIdentificationNumber(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutIdentificationNumber(),
            firstValue: IdentificationNumber.From("40213479476"),
            secondValue: IdentificationNumber.From("40213479477"));
    }

    protected override void SetProperty(Owner.Builder builder, IdentificationNumber value)
        => builder.WithIdentificationNumber(value);

    protected override IdentificationNumber GetProperty(Owner buildable) => buildable.IdentificationNumber;
}
