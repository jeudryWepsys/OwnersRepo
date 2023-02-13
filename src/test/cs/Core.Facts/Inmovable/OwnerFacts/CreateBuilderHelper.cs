using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.ProtoDomainPrimitives.Numerics;
using Id = RI.Novus.Core.Inmovable.Owners.Id;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Name,
        IdentificationNumber,
        CreatedDate,
        Codia,
        Properties
    }
    internal static Owner.Builder CreateUsedBuilder()
    {
        Owner.Builder builder = CreateFullBuilder();

        _ = builder.Build();    

        return builder;
    }

    internal static Owner.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    
    internal static Owner.Builder CreateBuilderWithoutId() 
        => CreateBuilderWithout(BuilderProperty.Id);
    
    internal static Owner.Builder CreateBuilderWithoutName()
        => CreateBuilderWithout(BuilderProperty.Name);
    
    internal static Owner.Builder CreateBuilderWithoutIdentificationNumber()
        => CreateBuilderWithout(BuilderProperty.IdentificationNumber);
    
    internal static Owner.Builder CreateBuilderWithoutCreatedDate()
        => CreateBuilderWithout(BuilderProperty.CreatedDate);
    
    internal static Owner.Builder CreateBuilderWithoutCodia()
        => CreateBuilderWithout(BuilderProperty.Codia);
    
    internal static Owner.Builder CreateBuilderWithoutProperties()
        => CreateBuilderWithout(BuilderProperty.Properties);
    
    internal static Owner.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Owner.Builder>> setters
            = new Dictionary<BuilderProperty, Action<Owner.Builder>>
        {
            [BuilderProperty.Id] = b 
                => b.WithId(Id.Generate()),
            [BuilderProperty.Name] = b
                => b.WithName(new Name("Owner1")),
            [BuilderProperty.IdentificationNumber] = b
                => b.WithIdentificationNumber(new IdentificationNumber("40213479576")),
            [BuilderProperty.Codia] = b
                => b.WithCodia(new Codia(new PositiveInteger(1))),
            [BuilderProperty.CreatedDate] = b
                => b.WithCreatedDate(new CreatedDate(new PastOrPresentTimestamp( new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero)))),
            [BuilderProperty.Properties] = b
                => b.WithProperties(new List<Property>())
        };

        var builder = new Owner.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
