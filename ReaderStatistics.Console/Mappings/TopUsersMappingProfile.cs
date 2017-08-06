using AutoMapper;

namespace ReaderStatistics.Console.Mappings
{
    public class TopUsersMappingProfile : Profile
    {
        public TopUsersMappingProfile()
        {
            this.CreateMap<Domain.User.Entity.UserAccess, ViewModels.UserAccess>().ConvertUsing(
                entity => new ViewModels.UserAccess()
                              {
                                  Name = $"{entity.User.FirstName} {entity.User.LastName}",
                                  NumberOfViews = entity.NumberOfViews,
                              });
        }
    }
}