using System.Collections.Generic;
using System.Linq;
using ReaderStatistics.Domain.Publication.Entity;
using ReaderStatistics.Domain.Repositories;

namespace ReaderStatistics.Domain.Publication
{
    public class PublicationService
    {
        private readonly IAccessLogRepository _accessLogRepository;

        private readonly IRepository<Entity.Publication> _publicationRepository;

        private readonly IRepository<Author> _authorRepository;

        public PublicationService(IAccessLogRepository accessLogRepository, IRepository<Entity.Publication> publicationRepository, IRepository<Author> authorRepository)
        {
            this._accessLogRepository = accessLogRepository;
            this._publicationRepository = publicationRepository;
            this._authorRepository = authorRepository;
        }

        public IEnumerable<PublicationAuthors> FindTopPublicationsByViews()
        {
            var groupBy = this._accessLogRepository
                .Read()
                .GroupBy(a => a.PublicationId);

            var list = groupBy
                .OrderByDescending(p => p.Count())
                .Take(10)
                .Select(a =>
                        {
                            var publication = this._publicationRepository.GetById(a.Key);
                            return new PublicationAuthors
                                       {
                                           NumberOfViews = a.Count(),
                                           Name = publication.Name,
                                           Authors = publication.AuthorIds.Select(_authorRepository.GetById)
                                       };
                        })
                ;

            return list;
        }
    }
}
