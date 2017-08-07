using System;
using AutoMapper;
using NUnit.Framework;
using ReaderStatistics.Console.Mappings;
using ReaderStatistics.Domain.User.Entity;
using UserAccess = ReaderStatistics.Console.ViewModels.UserAccess;

namespace ReaderStatistics.Console.Tests
{
    [TestFixture]
    public class TopUsersMappingProfileTests
    {
        [Test]
        public void TopUsersMappingProfile_ValidConfiguration()
        {
            Mapper.Initialize(m => m.AddProfile<TopUsersMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void TopUsersMappingProfile_Map()
        {
            Mapper.Initialize(m => m.AddProfile<TopUsersMappingProfile>());

            var publicationAuthors = new Domain.User.Entity.UserAccess
                                         {
                                             NumberOfViews = 1,
                                             User = new User
                                                        {
                                                            CompanyId = Guid.Parse("4E98200E-F757-4C91-8111-667CCD47005D"),
                                                            FirstName = "first",
                                                            LastName = "last",
                                                            Id = Guid.Parse("D30C7357-4E0E-4AFC-A812-09A7C172EE13")
                                                        }
                                         };

            var actual = Mapper.Map<UserAccess>(publicationAuthors);

            Assert.That(actual.Name, Is.EqualTo("first last"));
            Assert.That(actual.NumberOfViews, Is.EqualTo(1));
        }
    }
}