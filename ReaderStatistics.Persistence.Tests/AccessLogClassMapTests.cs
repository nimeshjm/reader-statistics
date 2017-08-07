using System.Linq;
using NUnit.Framework;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Tests
{
    [TestFixture]
    public class AccessLogClassMapTests
    {
        [Test]
        public void AccessLogClassMap_CreatesCorrectMap()
        {
            var sut = new AccessLogClassMap();

            Assert.That(sut.PropertyMaps.Count, Is.EqualTo(3));
            Assert.That(sut.PropertyMaps.First().Data.Names.First(), Is.EqualTo("TimeStamp"));
            Assert.That(sut.PropertyMaps.ElementAt(1).Data.Names.First(), Is.EqualTo("PublicationId"));
            Assert.That(sut.PropertyMaps.ElementAt(2).Data.Names.First(), Is.EqualTo("UserId"));
        }
    }
}
