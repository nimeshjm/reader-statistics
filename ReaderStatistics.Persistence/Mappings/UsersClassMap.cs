using CsvHelper.Configuration;
using ReaderStatistics.Domain.User.Entity;

namespace ReaderStatistics.Persistence.Mappings
{
    public sealed class UsersClassMap : CsvClassMap<User>
    {
        public UsersClassMap()
        {
            this.Map(m => m.Id).Index(0);
            this.Map(m => m.LastName).Index(1);
            this.Map(m => m.FirstName).Index(2);
            this.Map(m => m.CompanyId).Index(3);
        }
    }
}