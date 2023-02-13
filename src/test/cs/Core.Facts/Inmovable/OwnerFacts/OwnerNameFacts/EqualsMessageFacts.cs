using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerNameFacts;

internal sealed class EqualsMessageFacts : AbstractEquatableTestFixture<Name>
{
    protected override Context BuildContext()
    {
        const string rawName = "Owner1";
        Name subject = new(rawName);

        return new Context(
            subject: subject,
            subjectCopy: new Name(rawName),
            other: new Name("Owner2"),
            otherSemanticallyEqualsToSubject: new Name("Owner1"));
    }
}