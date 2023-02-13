using Optional.Unsafe;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.Validations;
using Type = RI.Novus.Core.Inmovable.Properties.Type;

namespace WebApiExample.ViewModels;

/// <summary>
/// Represents a property model.
/// </summary>
public sealed class PropertyModel
{
    /// <summary>
    /// Gets or sets the property identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the owner identifier.
    /// </summary>
    public Guid OwnerId { get; set; }
    
    /// <summary>
    /// Gets or sets the surface.
    /// </summary>
    public decimal Surface { get; set; }
    
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public Type Type { get; set; }
    
    /// <summary>
    /// Gets or sets the area.
    /// </summary>
    public decimal Area { get; set; }
    
    /// <summary>
    /// Gets or sets the region.
    /// </summary>
    public decimal Region { get; set; }
    
    /// <summary>
    /// Converts to Property entity.
    /// </summary>
    /// <returns>An instance of <see cref="RI.Novus.Core.Asegurados.Asegurado"/></returns>
    public Property ToEntity()
    {
        return new Property.Builder()
            .WithOwnerId(OwnerId)
            .WithSurface(RI.Novus.Core.Inmovable.Properties.Surface.From(Surface))
            .WithType(Type)
            .WithArea(RI.Novus.Core.Inmovable.Properties.Area.From(Area))
            .WithRegion(RI.Novus.Core.Inmovable.Properties.Region.From(Region))
            .Build(); 
    }
    
    /// <summary>
    /// Converts from Property entity.
    /// </summary>
    /// <param name="owner">Represents an owner.</param>
    /// <returns></returns>
    public static PropertyModel FromEntity(Property owner)
    {
        Arguments.NotNull(owner, nameof(owner));

        return new PropertyModel
        {
            Id = owner.Id.Value,
            OwnerId = owner.OwnerId,
            Surface = owner.Surface.Value,
            Type = owner.Type,
            Area = owner.Area.ValueOrDefault().Value,
            Region = owner.Region.ValueOrDefault().Value
        };
    }
}