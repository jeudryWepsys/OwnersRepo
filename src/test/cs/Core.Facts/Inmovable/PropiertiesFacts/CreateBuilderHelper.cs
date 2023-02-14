using RI.Novus.Core.Inmovable.Properties;
using Id = RI.Novus.Core.Inmovable.Properties.Id;
using Type = RI.Novus.Core.Inmovable.Properties.Type;

namespace RI.Novus.Core.Facts.Inmovable.PropiertiesFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Type,
        OwnerId,
        Surface
    }
    internal static Property.Builder CreateUsedBuilder()
    {
        Property.Builder builder = CreateFullBuilder();

        _ = builder.Build();    

        return builder;
    }

    internal static Property.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    
    internal static Property.Builder CreateBuilderWithoutId() 
        => CreateBuilderWithout(BuilderProperty.Id);
    
    internal static Property.Builder CreateBuilderWithoutType() => CreateBuilderWithout(BuilderProperty.Type);

    internal static Property.Builder CreateBuilderWithoutSurface() => CreateBuilderWithout(BuilderProperty.Surface);

    internal static Property.Builder CreateBuilderWithoutOwnerId() => CreateBuilderWithout(BuilderProperty.OwnerId);

    internal static Property.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Property.Builder>> setters
            = new Dictionary<BuilderProperty, Action<Property.Builder>>
        {
            [BuilderProperty.Id] = b 
                => b.WithId(Id.Generate()),
            [BuilderProperty.Type] = b 
                => b.WithType(Type.Business),
            [BuilderProperty.OwnerId] = b 
                => b.WithOwnerId(Guid.NewGuid()),
            [BuilderProperty.Surface] = b 
                => b.WithSurface(Surface.From(123.45M)),
        };

        var builder = new Property.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
