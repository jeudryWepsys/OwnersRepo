using System.Collections.Generic;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Properties;

namespace RI.Novus.Core.Inmovable.Owners;

/// <summary>
/// Represents the owner entity.
/// </summary>
public sealed class Owner
{
    private Owner(Builder builder)
    {
        Arguments.NotNull(builder, nameof(builder));
        Id = builder.IdOption.ValueOr(Id.Generate());
        Name = builder.NameOption.ValueOrFailure();
        IdentificationNumber = builder.IdentificationNumberOption.ValueOrFailure();
        CreatedDate = builder.CreatedDateOption.ValueOrFailure();
        Codia = builder.CodiaOption.ValueOrFailure();
        Properties = builder.PropertyOption.ValueOrFailure();
    }
    
    /// <summary>Owner's id.</summary>
    public Id Id { get; }
    
    /// <summary>
    /// Owner's name
    /// </summary>
    public Name Name { get; }
    
    /// <summary>
    /// Owner's identification number.
    /// </summary>
    public IdentificationNumber IdentificationNumber { get; }

    /// <summary>
    /// Owner's created date.
    /// </summary>
    public CreatedDate CreatedDate { get; }
    
    /// <summary>
    /// Owner's age.
    /// </summary>
    public Codia Codia { get; }
    
    /// <summary>
    /// Owner's properties.
    /// </summary>
    public IEnumerable<Property> Properties { get; }
    
    /// <summary>
    /// Persists owner and property.
    /// </summary>
    /// <param name="ownerRepository">Represents the owner repository.</param>
    public void Persists(IOwnerRepository ownerRepository)
    {
        Arguments.NotNull(ownerRepository, nameof(ownerRepository));
        State.IsFalse(ownerRepository.Exists(IdentificationNumber), "The given name already exists on database");
        ownerRepository.Save(this);
    }
    
    /// <summary>
    /// Delete owner's property.
    /// </summary>
    /// <param name="propertyRepositoryDummy">Represents the property repository.</param>
    /// <param name="propertyId">Represents the property id.</param>
    public void Delete(IPropertyRepositoryDummy propertyRepositoryDummy, Guid propertyId)
    {
        Arguments.NotNull(propertyRepositoryDummy, nameof(propertyRepositoryDummy));
        propertyRepositoryDummy.Delete(this, propertyId);
    }

    /// <summary>
    /// Update owner's property.
    /// </summary>
    /// <param name="propertyRepositoryDummy">Represents the property repository.</param>
    /// <param name="propertyId">Represents the property id.</param>
    /// <param name="propertyToUpdate"></param>
    public void Update(IPropertyRepositoryDummy propertyRepositoryDummy, Guid propertyId, Property propertyToUpdate)
    {
        Arguments.NotNull(propertyRepositoryDummy, nameof(propertyRepositoryDummy));
        propertyRepositoryDummy.Update(this, propertyId, propertyToUpdate);
    }
    
    /// <summary>
    /// Property's builder.
    /// </summary>
    public sealed class Builder : AbstractEntityBuilder<Owner>
    {
        /// <inheritdoc />
        protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

        /// <inheritdoc />
        protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

        internal Option<Id> IdOption { get; private set; }

        internal Option<Name> NameOption { private set; get; }

        internal Option<IdentificationNumber> IdentificationNumberOption { private set; get; }
        
        internal Option<CreatedDate> CreatedDateOption { private set; get; }
        
        internal Option<Codia> CodiaOption { private set; get; }
        
        internal Option<IEnumerable<Property>> PropertyOption { private set; get; }
        
        /// <inheritdoc />
        protected override Owner DoBuild()
        {
            State.IsTrue(NameOption.HasValue, "Name is Missing");
            State.IsTrue(IdentificationNumberOption.HasValue, "IdentificationNumber is Missing");
            State.IsTrue(CreatedDateOption.HasValue, "Birthday is Missing");
            State.IsTrue(CodiaOption.HasValue, "Age is Missing");
            State.IsTrue(PropertyOption.HasValue, "Property is Missing");

            return new Owner(this);
        }
        
        /// <summary>Adds a valid ID</summary>
        /// <param name="id">Represents the ID.</param>
        /// <returns></returns>
        public Builder WithId(Id id)
            => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

        /// <summary>
        /// Sets Owner's name.
        /// </summary>
        /// <param name="name">Represents the name.</param>
        /// <returns>self</returns>
        public Builder WithName(Name name)
            => SetProperty(() => NameOption
                = Arguments.NotNull(name, nameof(name)).SomeNotNull());            
        /// <summary>
        /// Sets Owner's identification number.
        /// </summary>
        /// <param name="identificationNumber">Represents the identification number.</param>
        /// <returns>self</returns>
        public Builder WithIdentificationNumber(IdentificationNumber identificationNumber)
            => SetProperty(() => IdentificationNumberOption
                = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());

        /// <summary>
        /// Sets Owner's createdDate.
        /// </summary>
        /// <param name="createdDate"></param>
        /// <returns>self</returns>
        public Builder WithCreatedDate(CreatedDate createdDate)
            => SetProperty(() => CreatedDateOption
                = Arguments.NotNull(createdDate, nameof(createdDate)).SomeNotNull());
        
        /// <summary>
        /// Sets Owner's codia.
        /// </summary>
        /// <param name="codia">Represents the codia.</param>
        /// <returns>self</returns>
        public Builder WithCodia(Codia codia)
            => SetProperty(() => CodiaOption
                = Arguments.NotNull(codia, nameof(codia)).SomeNotNull());
        
        /// <summary>
        /// Sets Owner's properties.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public Builder WithProperties(IEnumerable<Property> property)
            => SetProperty(() => PropertyOption
                = Arguments.NotNull(property, nameof(property)).SomeNotNull());
        
        private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
    }
    
}
