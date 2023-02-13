using static RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.CreateBuilderHelper;
using Property = RI.Novus.Core.Inmovable.Properties.Property;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts.BuilderFacts;

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

        Property.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }
    
    /// <summary>
    ///  Tests that the <see cref="Property.Builder.Build"/> method throws an <see cref="InvalidOperationException"/> when the <see cref="Property.Builder"/> is missing a required property.
    /// </summary>
    /// <param name="missingProperty"></param>
    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None)] BuilderProperty missingProperty)
    {
        Property.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
