using System.Linq;
using NUnit.Framework;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistic.Persistence.Tests
{
    [TestFixture]
    public class UsersClassMapTests
    {
        [Test]
        public void UsersClassMap_CreatesCorrectMap()
        {
            var sut = new UsersClassMap();

            Assert.That(sut.PropertyMaps.Count, Is.EqualTo(4));
            Assert.That(sut.PropertyMaps.First().Data.Names.First(), Is.EqualTo("Id"));
            Assert.That(sut.PropertyMaps.ElementAt(1).Data.Names.First(), Is.EqualTo("LastName"));
            Assert.That(sut.PropertyMaps.ElementAt(2).Data.Names.First(), Is.EqualTo("FirstName"));
            Assert.That(sut.PropertyMaps.ElementAt(3).Data.Names.First(), Is.EqualTo("CompanyId"));
        }
    }
}