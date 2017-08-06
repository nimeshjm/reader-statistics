using System.Collections.Generic;
using ReaderStatistics.Domain.Shared;

namespace ReaderStatistics.Domain.Repositories
{
    public interface IAccessLogRepository
    {
        IEnumerable<AccessLog> Read();
    }
}