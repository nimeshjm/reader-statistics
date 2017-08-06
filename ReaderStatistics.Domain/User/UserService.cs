using System.Collections.Generic;
using System.Linq;
using ReaderStatistics.Domain.Publication.Entity;
using ReaderStatistics.Domain.Repositories;
using ReaderStatistics.Domain.User.Entity;

namespace ReaderStatistics.Domain.User
{
    public class UserService
    {
        private readonly IAccessLogRepository _accessLogRepository;

        private readonly IRepository<Entity.User> _userRepository;

        public UserService(IAccessLogRepository accessLogRepository, IRepository<Entity.User> userRepository)
        {
            this._accessLogRepository = accessLogRepository;
            this._userRepository = userRepository;
        }

        public IEnumerable<UserAccess> FindTopUsersByPublicationAccess()
        {
            var list = this._accessLogRepository
                .Read()
                .GroupBy(a => a.UserId)
                .OrderByDescending(p => p.Count())
                .Take(10)
                .Select(a => new UserAccess
                                 {
                                     User = this._userRepository.GetById(a.Key),
                                     NumberOfViews = a.Count()
                                 })
                ;

            return list;
        }
    }
}
