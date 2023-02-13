using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Inmovable.Properties;

/// <summary>
/// Property (initial dummy class).
/// </summary>
public sealed class Property
{
    private Property(Builder builder)
    {
        Arguments.NotNull(builder, nameof(builder));
        Id = builder.IdOption.ValueOr(Id.Generate());
        Type = builder.TypeOption.ValueOrFailure();
        OwnerId = builder.OwnerIdOption.ValueOrFailure("Form Id is required");
        Area = builder.AreaOption;
        Region = builder.RegionOption;
        Surface = builder.SurfaceOption.ValueOrFailure("Surface is required");
    }
    
    public void Update(IPropertyRepositoryDummy propertyRepositoryDummy, Guid propertyId)
    {
        Arguments.NotNull(propertyRepositoryDummy, nameof(propertyRepositoryDummy));
        propertyRepositoryDummy.UpdateProperty(propertyId, this);
    }
    
    /// <summary>Property's id.</summary>
    public Id Id { get; }
    
    /// <summary>
    /// Represents the ID of associated Form definition
    /// </summary>
    public Guid OwnerId { get; }
    
    /// <summary>Represents a authentication type</summary>
    public Type Type { get; }
    
    public Option<Area> Area { get; }
    
    public Option<Region> Region { get; }
    
    public Surface Surface { get; }
    
    

    /// <summary>
    /// Property's builder.
    /// </summary>
    public sealed class Builder : AbstractEntityBuilder<Property>
    {
        /// <inheritdoc />
        protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

        /// <inheritdoc />
        protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

        internal Option<Id> IdOption { get; private set; }
        internal Option<Type> TypeOption { get; private set; }
        internal Option<Guid> OwnerIdOption { get; private set; }
        
        internal Option<Area> AreaOption { get; private set; }
        
        internal Option<Region> RegionOption { get; private set; }
        
        internal Option<Surface> SurfaceOption { get; private set; }

        /// <inheritdoc />
        protected override Property DoBuild()
        {
            State.IsTrue(TypeOption.HasValue, nameof(TypeOption));
            State.IsTrue(OwnerIdOption.HasValue, nameof(OwnerIdOption));
            State.IsTrue(SurfaceOption.HasValue, nameof(SurfaceOption));

            return new Property(this);
        }
       
        /// <summary>Adds a valid ID</summary>
        /// <param name="id">Represents the ID.</param>
        /// <returns></returns>
        public Builder WithId(Id id)
            => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());
        
        /// <summary>Sets the authentication type</summary>
        /// <param name="type"></param>
        public Builder WithType(Type type)
            => SetProperty(() =>
            {
                Arguments.ValidEnumerationMember(type, nameof(type));
                TypeOption = type.Some();
            });
        
        /// <summary>Valid ID of associated action activity</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Builder WithOwnerId(Guid id)
            => SetProperty(() => OwnerIdOption = id.Some());
        
        /// <summary>Represents the area of the property</summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public Builder WithArea(Area area)
            => SetProperty(() => AreaOption = area.Some());
        
        /// <summary>Represents the region of the property</summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public Builder WithRegion(Region region)
            => SetProperty(() => RegionOption = region.Some());
        
        /// <summary>Represents the surface of the property</summary>
        /// <param name="surface"></param>
        /// <returns></returns>
        public Builder WithSurface(Surface surface)
            => SetProperty(() => SurfaceOption
                = Arguments.NotNull(surface, nameof(surface)).SomeNotNull());

        private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
    }
    
    public static void Delete(IPropertyRepositoryDummy propertyRepositoryDummy, Guid propertyId)
    {
        Arguments.NotNull(propertyRepositoryDummy, nameof(propertyRepositoryDummy));
        propertyRepositoryDummy.DeleteProperty(propertyId);
    }
}
