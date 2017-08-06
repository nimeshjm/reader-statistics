using System;

namespace ReaderStatistics.Domain.Repositories
{
    public interface IRepository<T> where T : Shared.Entity
    {
        T GetById(Guid id);
    }
}