

using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerIdentificationNumber;

[TestFixture]
internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<IdentificationNumber>
{
    protected override Context BuildContext()
    {
        const string rawIdentificationNumber = "40213479476";
        IdentificationNumber subject = new(rawIdentificationNumber);

        return new Context(
            subject: subject,
            subjectCopy: new IdentificationNumber(rawIdentificationNumber),
            other: new IdentificationNumber("40213479477"),
            otherSemanticallyEqualsToSubject: new IdentificationNumber("40213479476"));
    }
}
