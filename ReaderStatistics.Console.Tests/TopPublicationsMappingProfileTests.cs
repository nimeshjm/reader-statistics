using System;
using System.Linq;
using AutoMapper;
using NUnit.Framework;
using ReaderStatistics.Console.Mappings;
using ReaderStatistics.Domain.Publication.Entity;

namespace ReaderStatistics.Console.Tests
{
    [TestFixture]
    public class TopPublicationsMappingProfileTests
    {
        [Test]
        public void TopPublicationsMappingProfile_ValidConfiguration()
        {
            Mapper.Initialize(m => m.AddProfile<TopPublicationsMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void TopPublicationsMappingProfile_Map()
        {
            Mapper.Initialize(m => m.AddProfile<TopPublicationsMappingProfile>());

            var publicationAuthors = new PublicationAuthors
                                         {
                                             Name = "name",
                                             NumberOfViews = 1,
                                             Authors = new[]
                                                           {
                                                               new Author
                                                                   {
                                                                       FirstName = "first1",
                                                                       LastName = "last1",
                                                                       Id = Guid.Parse("A442766D-8C7A-4FD2-A17E-019BA0626F44")
                                                                   },
                                                               new Author
                                                                   {
                                                                       FirstName = "first2",
                                                                       LastName = "last2",
                                                                       Id = Guid.Parse("B6798560-D9DB-4771-974C-9DC368DA25D4")
                                                                   },
                                                           }
                                         };

            var actual = Mapper.Map<ViewModels.PublicationAuthors>(publicationAuthors);

            Assert.That(actual.Name, Is.EqualTo("name"));
            Assert.That(actual.NumberOfViews, Is.EqualTo(1));
            Assert.That(actual.Authors, Is.EqualTo("[first1 last1, first2 last2]"));
        }
    }
}
