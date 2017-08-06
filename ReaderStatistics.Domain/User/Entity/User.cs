using System;
using ReaderStatistics.Domain.Shared;

namespace ReaderStatistics.Domain.User.Entity
{
    public class User : Person
    {
        public Guid CompanyId { get; set; }
    }
}