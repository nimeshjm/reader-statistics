using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.User;

namespace ReaderStatistics.Domain.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        internal Mock<IAccessLogRepository> accessLogRepository;
        private Mock<IRepository<User.Entity.User>> userRepository;

        [SetUp]
        public void Setup()
        {
            this.accessLogRepository = new Mock<IAccessLogRepository>();
            this.userRepository = new Mock<IRepository<User.Entity.User>>();
        }

        [Test]
        public void FindTopUsersByPublicationAccess_WithSingleAccess_ReturnsOneItem()
        {
            var userId = Guid.Parse("9EE0528F-86DC-464E-9F5E-89B5149A03AD");
            var publicationId = Guid.Parse("B9D1FF7D-7EAB-468E-B335-4AF2B1D5AED7");
            AccessLogsTestData.SetupSingleAccess(publicationId, userId, this.accessLogRepository);
            this.userRepository.Setup(a => a.GetById(userId)).Returns(new User.Entity.User { Id = userId, FirstName = "first", LastName = "last" });
            var sut = new UserService(accessLogRepository.Object, userRepository.Object);

            var actual = sut.FindTopUsersByPublicationAccess().ToList();

            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.First().User.Id, Is.EqualTo(userId));
        }

        [Test]
        public void FindTopUsersByPublicationAccess_WithMultipleAccess_ReturnsItems()
        {
            AccessLogsTestData.SetupMultipleAccess(this.accessLogRepository);
            var sut = new UserService(accessLogRepository.Object, userRepository.Object);

            var actual = sut.FindTopUsersByPublicationAccess().ToList();

            Assert.That(actual.Count, Is.EqualTo(2));
            Assert.That(actual.First().NumberOfViews, Is.EqualTo(4));
            Assert.That(actual.ElementAt(1).NumberOfViews, Is.EqualTo(2));
        }
    }
}