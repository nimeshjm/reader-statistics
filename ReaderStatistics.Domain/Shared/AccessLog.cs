using System;

namespace ReaderStatistics.Domain.Shared
{
    public class AccessLog
    {
        public DateTime TimeStamp { get; set; }

        public Guid PublicationId { get; set; }

        public Guid UserId { get; set; }
    }
}