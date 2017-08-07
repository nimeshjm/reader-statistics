using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.User.Entity;
using ReaderStatistics.Persistence.Mappings;

namespace ReaderStatistics.Persistence.Repositories
{
    public class UserMemoryRepository : IRepository<User>
    {
        private readonly Dictionary<Guid, User> users;

        public UserMemoryRepository()
        {
            using (var streamReader = File.OpenText("users.csv"))
            {
                using (var csv = new CsvReader(streamReader))
                {
                    csv.Configuration.RegisterClassMap<UsersClassMap>();

                    this.users = csv.GetRecords<User>().ToDictionary(
                        a => a.Id,
                        a => new User { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName, CompanyId = a.CompanyId });
                }
            }
        }

        public User GetById(Guid id)
        {
            return this.users[id];
        }
    }
}