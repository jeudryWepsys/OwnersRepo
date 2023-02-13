using RI.Novus.Core.Asegurados;
using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts;


[TestFixture]
internal class AseguradoFacts
{
    /// <summary>
    /// Tests that the <see cref="Asegurado"/> constructor throws an <see cref="ArgumentNullException"/> when the <see cref="IAseguradosRepositoryDummy"/> is null.
    /// </summary>
    [Test]
     public void When_Using_Persist_With_Null_Repository_Throws_ArgumentNullException()
     {
         // Arrange
         string name = "Asegurado1";
         Guid id = Guid.NewGuid();
         string identificationNumber = "123456789";
         DateTimeOffset birthdate = DateTimeOffset.Now;
         int age = 20;
         
         IAseguradosRepositoryDummy? aseguradoRepositoryDummy = null;
         
         var asegurado = new Asegurado.Builder()
             .WithId(Id.From(id))
             .WithName(Name.From(name))
             .WithIdentificationNumber(IdentificationNumber.From(identificationNumber))
             .WithBirthdate(Birthday.From(birthdate))
             .WithAge(Age.From(age))
             .Build();

         // Assert
         Assert.That(() =>
         {
             asegurado.Persists(aseguradoRepository: aseguradoRepositoryDummy);
         }, Throws.ArgumentNullException);

     }
}