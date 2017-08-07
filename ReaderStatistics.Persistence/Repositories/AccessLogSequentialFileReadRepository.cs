using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.Shared;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Repositories
{
    public sealed class AccessLogSequentialFileReadRepository : IAccessLogRepository, IDisposable
    {
        private readonly CsvReader csv;

        private readonly StreamReader streamReader;

        public AccessLogSequentialFileReadRepository()
        {
            this.streamReader = File.OpenText("db\\readershipStats.csv");
            this.csv = new CsvReader(this.streamReader);
            this.csv.Configuration.RegisterClassMap<AccessLogClassMap>();
        }

        public IEnumerable<AccessLog> Read()
        {
            return this.csv.GetRecords<AccessLog>();
        }

        public void Dispose()
        {
            this.csv?.Dispose();
            this.streamReader?.Dispose();
        }
    }
}