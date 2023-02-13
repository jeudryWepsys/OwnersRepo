using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Asegurados;

/// <summary>
/// Property (initial dummy class).
/// </summary>
public sealed class Asegurado
{
    private Asegurado(Builder builder)
    {
        Arguments.NotNull(builder, nameof(builder));
        Id = builder.IdOption.ValueOr(Id.Generate());
        Name = builder.NameOption.ValueOrFailure();
        IdentificationNumber = builder.IdentificationNumber.ValueOrFailure();
        Birthday = builder.Birthdate.ValueOrFailure();
        Age = builder.Age.ValueOrFailure();
    }
    
    /// <summary>Property's id.</summary>
    public Id Id { get; }
    
    /// <summary>
    /// Asegurados's name
    /// </summary>
    public Name Name { get; }
    
    /// <summary>
    /// Asegurados's identification number.
    /// </summary>
    public IdentificationNumber IdentificationNumber { get; }
    
    
    /// <summary>
    /// Asegurados's birthdate.
    /// </summary>
    public Birthday Birthday { get; }
    
    /// <summary>
    /// Asegurados's age.
    /// </summary>
    public Age Age { get; }

    /// <summary>
    /// Persists entity.
    /// </summary>
    /// <param name="aseguradoRepository">Implementation of <see cref="IAseguradosRepositoryDummy"/></param>
    public void Persists(IAseguradosRepositoryDummy aseguradoRepository)
    {
        Arguments.NotNull(aseguradoRepository, nameof(aseguradoRepository));
        aseguradoRepository.Save(this);
    }
    
    /// <summary>
    /// Updates entity.
    /// </summary>
    /// <param name="aseguradosRepository">Implementation of <see cref="IAseguradosRepositoryDummy"/></param>
    public void Update(IAseguradosRepositoryDummy aseguradosRepository)
    {
        Arguments.NotNull(aseguradosRepository, nameof(aseguradosRepository));
        aseguradosRepository.Save(this);
    }
    
    /// <summary>
    /// Property's builder.
    /// </summary>
    public sealed class Builder : AbstractEntityBuilder<Asegurado>
    {
        /// <inheritdoc />
        protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

        /// <inheritdoc />
        protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

        internal Option<Id> IdOption { get; private set; }
        
        internal Option<Name> NameOption { private set; get; }

        internal Option<IdentificationNumber> IdentificationNumber { private set; get; }
        
        internal Option<Birthday> Birthdate { private set; get; }
        
        internal Option<Age> Age { private set; get; }

        /// <inheritdoc />
        protected override Asegurado DoBuild()
        {
            State.IsTrue(NameOption.HasValue, "Name.Missing");
            State.IsTrue(IdentificationNumber.HasValue, "IdentificationNumber.Missing");
            State.IsTrue(Birthdate.HasValue, "Birthday.Missing");
            State.IsTrue(Age.HasValue, "Age.Missing");

            return new Asegurado(this);
        }
        
        /// <summary>Adds a valid ID</summary>
        /// <param name="id">Represents the ID.</param>
        /// <returns></returns>
        public Builder WithId(Id id)
            => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

        /// <summary>
        /// Sets Property's name.
        /// </summary>
        /// <param name="name">Represents the name.</param>
        /// <returns>self</returns>
        public Builder WithName(Name name)
            => SetProperty(() => NameOption
                = Arguments.NotNull(name, nameof(name)).SomeNotNull());            
        /// <summary>
        /// Sets Property's identification number.
        /// </summary>
        /// <param name="identificationNumber">Represents the identification number.</param>
        /// <returns>self</returns>
        public Builder WithIdentificationNumber(IdentificationNumber identificationNumber)
            => SetProperty(() => IdentificationNumber
                = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());
        
        /// <summary>
        /// Sets Property's birthdate.
        /// </summary>
        /// <param name="birthday">Represents the birthdate.</param>
        /// <returns>self</returns>
        public Builder WithBirthdate(Birthday birthday)
            => SetProperty(() => Birthdate
                = Arguments.NotNull(birthday, nameof(birthday)).SomeNotNull());
        
        /// <summary>
        /// Sets Property's age.
        /// </summary>
        /// <param name="age">Represents the age.</param>
        /// <returns>self</returns>
        public Builder WithAge(Age age)
            => SetProperty(() => Age
                = Arguments.NotNull(age, nameof(age)).SomeNotNull());
        
        private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
    }

}
