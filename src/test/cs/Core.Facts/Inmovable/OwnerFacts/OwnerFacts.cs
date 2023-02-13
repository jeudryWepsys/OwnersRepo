using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Inmovable.Owners;
using RI.Novus.Core.Inmovable.Properties;
using Id = RI.Novus.Core.Inmovable.Owners.Id;
using IdentificationNumber = RI.Novus.Core.Inmovable.Owners.IdentificationNumber;
using Name = RI.Novus.Core.Inmovable.Owners.Name;

namespace RI.Novus.Core.Facts.Inmovable.OwnerFacts;


[TestFixture]
internal class OwnerFacts
{
    /// <summary>
    /// Tests that the <see cref="Owner"/> constructor throws an <see cref="ArgumentNullException"/> when the <see cref="IOwnerRepositoryDummy"/> is null.
    /// </summary>
    [Test]
     public void When_Using_Persist_With_Null_Repository_Throws_ArgumentNullException()
     {
         // Arrange
         Guid id = Guid.NewGuid();
         string name = "Owner1";
         string identificationNumber = "40213479476";
         DateTimeOffset createdDate = DateTimeOffset.Now;
         int codia = 20;
         ICollection<Property> properties = new List<Property>();
         
         IOwnerRepositoryDummy? ownerRepositoryDummy = null;
         
         var owner = new Owner.Builder()
             .WithId(Id.From(id))
             .WithName(Name.From(name))
             .WithIdentificationNumber(IdentificationNumber.From(identificationNumber))
             .WithCreatedDate(CreatedDate.From(createdDate))
             .WithCodia(Codia.From(codia))
             .WithProperties(properties)
             .Build();

         // Assert
         Assert.That(() =>
         {
             owner.Persists(ownerRepositoryDummy: ownerRepositoryDummy);
         }, Throws.ArgumentNullException);

     }
}