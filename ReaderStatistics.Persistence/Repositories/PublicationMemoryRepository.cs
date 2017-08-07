using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ReaderStatistics.Domain.Publication.Entity;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Repositories
{
    public class PublicationMemoryRepository : IRepository<Publication>
    {
        private readonly Dictionary<Guid, Publication> publications;

        public PublicationMemoryRepository()
        {
            using (var streamReader = File.OpenText("publications.csv"))
            {
                using (var csv = new CsvReader(streamReader))
                {
                    csv.Configuration.RegisterClassMap<PublicationsClassMap>();

                    this.publications = csv.GetRecords<Publication>().ToDictionary(
                        a => a.Id,
                        a => new Publication { Id = a.Id, Name = a.Name, AuthorIds = a.AuthorIds});
                }
            }
        }

        public Publication GetById(Guid id)
        {
            Publication publication;
            return this.publications.TryGetValue(id, out publication) ? publication : Publication.Null;
        }
    }
}