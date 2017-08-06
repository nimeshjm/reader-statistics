using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ReaderStatistics.Domain.Publication;
using ReaderStatistics.Domain.Publication.Entity;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.Shared;

namespace ReaderStatistics.Domain.Tests
{
    [TestFixture]
    public class PublicationServiceTests
    {
        private Mock<IAccessLogRepository> accessLogRepository;
        Mock<IRepository<Publication.Entity.Publication>> publicationRepository;
        Mock<IRepository<Author>> authorRepository;

        [SetUp]
        public void Setup()
        {
            this.accessLogRepository = new Mock<IAccessLogRepository>();
            this.publicationRepository = new Mock<IRepository<Publication.Entity.Publication>>();
            this.authorRepository = new Mock<IRepository<Author>>();
        }

        [Test]
        public void FindTopPublicationsByViews_WithoutAccessLogs_ReturnsNoItems()
        {
            var sut = new PublicationService(this.accessLogRepository.Object, this.publicationRepository.Object, this.authorRepository.Object);

            var actual = sut.FindTopPublicationsByViews().ToList();

            Assert.That(actual.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void FindTopPublicationsByViews_WithSingleAccess_ReturnsOneItem()
        {
            var authorId = Guid.Parse("088CF176-3316-40F1-B76A-988BE88F2E36");
            var userId = Guid.Parse("9EE0528F-86DC-464E-9F5E-89B5149A03AD");
            var publicationId = Guid.Parse("B9D1FF7D-7EAB-468E-B335-4AF2B1D5AED7");

            AccessLogsTestData.SetupSingleAccess(publicationId, userId, this.accessLogRepository);
            this.SetupSinglePublication(publicationId, authorId);
            this.SetupSingleAuthor(authorId);

            var sut = new PublicationService(this.accessLogRepository.Object, this.publicationRepository.Object, this.authorRepository.Object);

            var actual = sut.FindTopPublicationsByViews().ToList();

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.First().Name, Is.EqualTo("pub1"));
            Assert.That(actual.First().NumberOfViews, Is.EqualTo(1));
            Assert.That(actual.First().Authors.Count(), Is.EqualTo(1));
            Assert.That(actual.First().Authors.First().Id, Is.EqualTo(authorId));
            Assert.That(actual.First().Authors.First().FirstName, Is.EqualTo("first"));
            Assert.That(actual.First().Authors.First().LastName, Is.EqualTo("last"));
        }

        [Test]
        public void FindTopPublicationsByViews_WithSingleAccessAndMissingPublication_ReturnsOneItem()
        {
            var userId = Guid.Parse("9EE0528F-86DC-464E-9F5E-89B5149A03AD");
            var publicationId = Guid.Parse("B9D1FF7D-7EAB-468E-B335-4AF2B1D5AED7");

            AccessLogsTestData.SetupSingleAccess(publicationId, userId, accessLogRepository);
            this.SetupMissingPublication();

            var sut = new PublicationService(this.accessLogRepository.Object, this.publicationRepository.Object, this.authorRepository.Object);

            var actual = sut.FindTopPublicationsByViews().ToList();

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.First().Name, Is.Empty);
            Assert.That(actual.First().NumberOfViews, Is.EqualTo(1));
            Assert.That(actual.First().Authors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void FindTopPublicationsByViews_WithMultipleAccess_ReturnsItems()
        {
            AccessLogsTestData.SetupMultipleAccess(accessLogRepository);
            this.SetupMissingPublication();
            var sut = new PublicationService(this.accessLogRepository.Object, this.publicationRepository.Object, this.authorRepository.Object);

            var actual = sut.FindTopPublicationsByViews().ToList();

            Assert.That(actual.Count, Is.EqualTo(2));
            Assert.That(actual.First().NumberOfViews, Is.EqualTo(4));
            Assert.That(actual.ElementAt(1).NumberOfViews, Is.EqualTo(2));
        }

        private void SetupSingleAuthor(Guid author)
        {
            this.authorRepository.Setup(a => a.GetById(author))
                .Returns(new Author { Id = author, FirstName = "first", LastName = "last" });
        }

        private void SetupSinglePublication(Guid publicationId, Guid author)
        {
            this.publicationRepository.Setup(a => a.GetById(publicationId)).Returns(
                new Publication.Entity.Publication { Name = "pub1", AuthorIds = new[] { author }, Id = publicationId });
        }

        private void SetupMissingPublication()
        {
            this.publicationRepository.Setup(a => a.GetById(It.IsAny<Guid>())).Returns(Publication.Entity.Publication.Null);
        }
    }
}
