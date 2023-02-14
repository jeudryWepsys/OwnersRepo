using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Optional.Unsafe;
using RI.Novus.Core.Inmovable.Properties;
using Triplex.Validations;
using Type = RI.Novus.Core.Inmovable.Properties.Type;

namespace Persistence.Models;

/// <summary>
/// Represents the database representation for a property.
/// </summary>
public sealed class PropertyPM
{
    /// <summary>
    /// Creates a instance of <see cref="PropertyPM"/>
    /// </summary>
    /// <param name="id">Represents the property id.</param>
    /// <param name="ownerId">Represents the property owner id.</param>
    /// <param name="surface">Represents the property surface.</param>
    /// <param name="type">Represents the property type.</param>
    /// <param name="area">Represents the property area.</param>
    /// <param name="region">Represents the property region.</param>
    public PropertyPM(Guid id, Guid ownerId, decimal surface, Type type, decimal area, decimal region)
    {
        Id = id;
        OwnerId = ownerId;
        Surface = surface;
        Type = type;
        Area = area;
        Region = region;
    }
    
    /// <summary>
    /// Indicates property id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Indicates property owner id.
    /// </summary>
    [Required]
    public Guid OwnerId { get; set; }
    
    /// <summary>
    /// Indicates property owner.
    /// </summary>
    [ForeignKey(nameof(OwnerId))]
    [NotMapped]
    public OwnerPM? PropertyOwner { get; set; } 
    
    /// <summary>
    /// Indicates property surface.
    /// </summary>
    [Required]
    [Range(minimum: 0, maximum: 1000000000)]
    public decimal Surface { get; set; }

    /// <summary>
    /// Indicates property type.
    /// </summary>
    [Required]
    public Type Type { get; set; }
    
    /// <summary>
    /// Indicates property area.
    /// </summary>
    [Range(minimum: 0, maximum: 1000000000)]
    public decimal Area { get; set; }
    
    /// <summary>
    /// Indicates property region.
    /// </summary>
    [Range(minimum: 0, maximum: 1000000000)]
    public decimal Region { get; set; }

    /// <summary>
    /// Converts a model to an entity.
    /// </summary>
    /// <returns></returns>
    public Property ToEntity()
    {
        return new Property.Builder()
            .WithId(RI.Novus.Core.Inmovable.Properties.Id.From(Id))
            .WithOwnerId(OwnerId)
            .WithSurface(RI.Novus.Core.Inmovable.Properties.Surface.From(Surface))
            .WithType(Type)
            .WithArea(RI.Novus.Core.Inmovable.Properties.Area.From((decimal)Area))
            .WithRegion(RI.Novus.Core.Inmovable.Properties.Region.From((decimal)Region))
            .Build();
    }
    
    /// <summary>
    /// Converts an entity to a model.
    /// </summary> 
    /// <param name="property">The property entity.</param>
    /// <returns></returns>
    public static PropertyPM FromEntity(Property property)
    {
        Arguments.NotNull(property, nameof(property));

        return new PropertyPM(property.Id.Value, property.OwnerId, property.Surface.Value, property.Type, property.Area.ValueOrDefault().Value, property.Region.ValueOrDefault().Value);
    }
}
