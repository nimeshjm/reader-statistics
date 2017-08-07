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
    public class AuthorMemoryRepository : IRepository<Author>
    {
        private readonly Dictionary<Guid, Author> authors;

        public AuthorMemoryRepository()
        {
            using (var streamReader = File.OpenText("db\\authors.csv"))
            {
                using (var csv = new CsvReader(streamReader))
                {
                    csv.Configuration.RegisterClassMap<AuthorsClassMap>();

                    this.authors = csv.GetRecords<Author>().ToDictionary(
                        a => a.Id,
                        a => new Author { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName });
                }
            }
        }

        public Author GetById(Guid id)
        {
            return this.authors[id];
        }
    }
}