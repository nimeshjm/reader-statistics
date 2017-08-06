using CsvHelper.Configuration;
using ReaderStatistics.Domain.Shared;

namespace ReaderStatistics.Persistence.Mappings
{
    public sealed class AccessLogClassMap : CsvClassMap<AccessLog>
    {
        public AccessLogClassMap()
        {
            this.Map(m => m.TimeStamp).Index(0);
            this.Map(m => m.PublicationId).Index(1);
            this.Map(m => m.UserId).Index(2);
        }
    }
}