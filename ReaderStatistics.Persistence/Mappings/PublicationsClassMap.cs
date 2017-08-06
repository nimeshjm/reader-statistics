using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using ReaderStatistics.Domain.Publication.Entity;

namespace ReaderStatistics.Persistence.Mappings
{
    public sealed class PublicationsClassMap : CsvClassMap<Publication>
    {
        public PublicationsClassMap()
        {
            this.Map(m => m.Id).Index(0);
            this.Map(m => m.Name).Index(1);
            this.Map(m => m.AuthorIds).ConvertUsing(this.ConvertAuthors);
        }

        private IEnumerable<Guid> ConvertAuthors(ICsvReaderRow row)
        {
            var authors = new List<Guid>();
            for (var i = 2; i <= 6; i++)
            {
                Guid val;
                if (row.TryGetField(i, out val))
                {
                    authors.Add(val);
                }
            }

            return authors;

        }
    }
}