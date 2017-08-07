using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using ReaderStatistics.Console.ViewModels;
using ReaderStatistics.Domain.Publication;
using ReaderStatistics.Domain.User;
using ReaderStatistics.Persistence.Repositories;

namespace ReaderStatistics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialise View model mappers
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));

            // initialise composition root - use DI framework if the app gets complex
            var publicationService = new PublicationService(new AccessLogSequentialFileReadRepository(), new PublicationMemoryRepository(), new AuthorMemoryRepository());

            var views = publicationService.FindTopPublicationsByViews();
            var vm = Mapper.Map<IEnumerable<PublicationAuthors>>(views);

            System.Console.WriteLine("The top 10 research publications, by number of views from unique users");
            foreach (var publicationAuthors in vm)
            {
                System.Console.WriteLine($"name: {publicationAuthors.Name}, views: {publicationAuthors.NumberOfViews}, authors: {publicationAuthors.Authors}");
            }

            System.Console.WriteLine("=====");
            System.Console.WriteLine();


            var userService = new UserService(new AccessLogSequentialFileReadRepository(), new UserMemoryRepository());
            var views2 = userService.FindTopUsersByPublicationAccess();
            var vm2 = Mapper.Map<IEnumerable<UserAccess>>(views2);

            System.Console.WriteLine("The 10 users who accessed the most publications");
            foreach (var users in vm2)
            {
                System.Console.WriteLine($"name: {users.Name}, publications: {users.NumberOfViews}");
            }
        }
    }
}
