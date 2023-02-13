using RI.Novus.Core.Inmovable.Owners;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.OwnerNameFacts;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<Name>
{
    protected override Context BuildContext()
    {
        const string rawName = "Owner1";
        Name subject = new(rawName);

        return new Context(
            lessThanSubject: new Name("Asegurado"),
            subject: subject,
            subjectCopy: new Name(rawName),
            otherSemanticallyEqualsToSubject: new Name("Owner1"),
            greatherThanSubject: new Name("Owner2"),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(Name left, Name right)
        => left == right;
    protected override bool ExecuteNotEqualsOperator(Name left, Name right)
        => left != right;
    protected override bool ExecuteLessThanOperator(Name left, Name right)
        => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(Name left, Name right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(Name left, Name right)
        => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(Name left, Name right)
        => left >= right;
}
