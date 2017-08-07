using System.Linq;
using AutoMapper;
using ReaderStatistics.Console.ViewModels;

namespace ReaderStatistics.Console.Mappings
{
    public class TopPublicationsMappingProfile : Profile
    {
        public TopPublicationsMappingProfile()
        {
            this.CreateMap<Domain.Publication.Entity.PublicationAuthors, PublicationAuthors>().ConvertUsing(
                entity => new PublicationAuthors
                          {
                              Name = entity.Name,
                              NumberOfViews = entity.NumberOfViews,
                              Authors = $"[{string.Join(", ", entity.Authors.Select(a => $"{a.FirstName} {a.LastName}"))}]"
                          });
        }
    }
}
