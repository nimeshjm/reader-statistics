using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using ReaderStatistics.Console.ViewModels;
using ReaderStatistics.Domain.Publication;
using ReaderStatistics.Domain.User;
using ReaderStatistics.Domain.User.Entity;
using ReaderStatistics.Persistence.Repositories;

namespace ReaderStatistics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));

            var publicationService = new PublicationService(new AccessLogSequentialFileReadRepository(), new PublicationMemoryRepository(), new AuthorMemoryRepository());

            var views = publicationService.FindTopPublicationsByViews();

            var vm = Mapper.Map<IEnumerable<PublicationAuthors>>(views);

            foreach (var publicationAuthors in vm)
            {
                System.Console.WriteLine($"name: {publicationAuthors.Name}, views: {publicationAuthors.NumberOfViews}, authors: {publicationAuthors.Authors}");
            }



            var userService = new UserService(new AccessLogSequentialFileReadRepository(), new UserMemoryRepository());
            var views2 = userService.FindTopUsersByPublicationAccess();
            var vm2 = Mapper.Map<IEnumerable<ViewModels.UserAccess>>(views2);
            foreach (var users in vm2)
            {
                System.Console.WriteLine($"name: {users.Name}, publications: {users.NumberOfViews}");
            }



        }
    }
}
