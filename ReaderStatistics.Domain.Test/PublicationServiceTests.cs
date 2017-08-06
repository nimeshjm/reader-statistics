using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ReaderStatistics.Domain.Publication;
using ReaderStatistics.Persistence.Repositories;

namespace ReaderStatistics.Domain.Tests
{
    [TestFixture]
    public class PublicationServiceTests
    {

        [Test]
        public void FindTopPublicationsByViews_Return()
        {
            var sut = new PublicationService(new AccessLogSequentialFileReadRepository(), new PublicationMemoryRepository(), new AuthorMemoryRepository());

            var views = sut.FindTopPublicationsByViews();

            var publicationAuthorses = views.ToList();
        }
    }
}
