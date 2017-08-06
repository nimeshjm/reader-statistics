using CsvHelper.Configuration;
using ReaderStatistics.Domain.Publication.Entity;

namespace ReaderStatistics.Persistence.Mappings
{
    public sealed class AuthorsClassMap : CsvClassMap<Author>
    {
        public AuthorsClassMap()
        {
            this.Map(m => m.Id).Index(0);
            this.Map(m => m.LastName).Index(1);
            this.Map(m => m.FirstName).Index(2);
        }
    }
}