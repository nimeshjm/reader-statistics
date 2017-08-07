using System.Linq;
using NUnit.Framework;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Tests
{
    [TestFixture]
    public class PublicationsClassMapTests
    {
        [Test]
        public void PublicationsClassMap_CreatesCorrectMap()
        {
            var sut = new PublicationsClassMap();

            Assert.That(sut.PropertyMaps.Count, Is.EqualTo(3));
            Assert.That(sut.PropertyMaps.First().Data.Names.First(), Is.EqualTo("Id"));
            Assert.That(sut.PropertyMaps.ElementAt(1).Data.Names.First(), Is.EqualTo("Name"));
            Assert.That(sut.PropertyMaps.ElementAt(2).Data.Names.First(), Is.EqualTo("AuthorIds"));
        }
    }
}