using System;
using System.Collections.Generic;
using Moq;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.Shared;

namespace ReaderStatistics.Domain.Tests
{
    public static class AccessLogsTestData
    {
        public static void SetupSingleAccess(Guid publicationId, Guid userId, Mock<IAccessLogRepository> accessLogRepository)
        {
            accessLogRepository.Setup(a => a.Read()).Returns(
                new List<AccessLog>
                    {
                        new AccessLog
                            {
                                PublicationId = publicationId,
                                TimeStamp = DateTime.Parse("2010-01-01 10:00:00"),
                                UserId = userId
                            }
                    });
        }
        public static void SetupMultipleAccess(Mock<IAccessLogRepository> accessLogRepository)
        {
            var publication1Id = Guid.NewGuid();
            var publication2Id = Guid.NewGuid();
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();

            accessLogRepository.Setup(a => a.Read()).Returns(
                new List<AccessLog>
                    {
                        new AccessLog
                            {
                                PublicationId = publication1Id,
                                TimeStamp = DateTime.Parse("2010-01-01 10:00:00"),
                                UserId = user1Id
                            },
                        new AccessLog
                            {
                                PublicationId = publication2Id,
                                TimeStamp = DateTime.Parse("2010-01-01 11:00:00"),
                                UserId = user1Id
                            },
                        new AccessLog
                            {
                                PublicationId = publication1Id,
                                TimeStamp = DateTime.Parse("2010-01-01 12:00:00"),
                                UserId = user2Id
                            },
                        new AccessLog
                            {
                                PublicationId = publication1Id,
                                TimeStamp = DateTime.Parse("2010-01-01 13:00:00"),
                                UserId = user2Id
                            },
                        new AccessLog
                            {
                                PublicationId = publication2Id,
                                TimeStamp = DateTime.Parse("2010-01-01 14:00:00"),
                                UserId = user2Id
                            },
                        new AccessLog
                            {
                                PublicationId = publication1Id,
                                TimeStamp = DateTime.Parse("2010-01-01 15:00:00"),
                                UserId = user2Id
                            },
                    });
        }
    }
}