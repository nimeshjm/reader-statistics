using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Tests
{
    [TestFixture]
    public class AuthorsClassMapTests
    {
        [Test]
        public void AuthorsClassMap_CreatesCorrectMap()
        {
            var sut = new AuthorsClassMap();

            Assert.That(sut.PropertyMaps.Count, Is.EqualTo(3));
            Assert.That(sut.PropertyMaps.First().Data.Names.First(), Is.EqualTo("Id"));
            Assert.That(sut.PropertyMaps.ElementAt(1).Data.Names.First(), Is.EqualTo("LastName"));
            Assert.That(sut.PropertyMaps.ElementAt(2).Data.Names.First(), Is.EqualTo("FirstName"));
        }
    }
}