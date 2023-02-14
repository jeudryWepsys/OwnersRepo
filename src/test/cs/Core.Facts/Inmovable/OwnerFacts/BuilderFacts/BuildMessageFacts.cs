using static RI.Novus.Core.Facts.Inmovable.OwnerFacts.CreateBuilderHelper;
using Owner = RI.Novus.Core.Inmovable.Owners.Owner;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    /// <summary>
    ///   Tests that the <see cref="Core.Inmovable.Owners.Owner.Builder.Build"/> method throws an <see cref="InvalidOperationException"/> when the <see cref="Core.Inmovable.Owners.Owner.Builder"/> is missing a required property.
    /// </summary>
    /// <param name="missingProperty"></param>
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty)
    {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None)
            .And.Not.EqualTo(BuilderProperty.Id));

        Owner.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    /// <summary>
    ///  Tests that the <see cref="Owner.Builder.Build"/> method throws an <see cref="InvalidOperationException"/> when the <see cref="Owner.Builder"/> is missing a required property.
    /// </summary>
    /// <param name="missingProperty"></param>
    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None)] BuilderProperty missingProperty)
    {
        Owner.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
