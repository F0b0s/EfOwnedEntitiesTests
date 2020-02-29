using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreOwnwedEntityInMemory
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => {
                builder.AddFilter((category, level) =>
        level == LogLevel.Debug)
    .AddConsole();
            });

        static async Task Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: "TestDb")
                //.UseLoggerFactory(MyLoggerFactory)
                .Options;

            /// Create new Company in db with True values
            var context = new MyContext(options);
            var company = new Company
            {
                Name = "Test company",
                Settings = new Settings()
                {
                    StandartAccess = true,
                    ExtendedAcces = true,
                    Flag1 = true
                }
            };
            context.Companies.Add(company);
            await context.SaveChangesAsync();

            /// Updating owned property fields to false
            var fromDbForUpdating = await context.Companies
                .Where(x => x.Id == company.Id)
                .FirstOrDefaultAsync();

            company.Settings = new Settings()
            {
                StandartAccess = false,
                ExtendedAcces = false,
                Flag1 = false
            };
            await context.SaveChangesAsync();

            /// Read updated company from existing context with cached entity, expecting to see flags with false values - is OK
            var fromDbCached = await context.Companies
                .Where(x => x.Id == company.Id)
                .FirstOrDefaultAsync();
            LogCompany(fromDbCached);

            // closing context with cached values 
            context.Dispose();

            /// Read updated company from db, expecting to see flags with false values - OK, entity has false values
            var newContext = new MyContext(options);
            var fromDb = await newContext.Companies
                .Where(x => x.Id == company.Id)
                .FirstOrDefaultAsync();
            LogCompany(fromDb);

            Console.ReadLine();
        }

        private static void LogCompany(Company cmp)
        {
            Console.WriteLine($"Name: '{cmp.Name}', Id: {cmp.Id}, StandartAccess: {cmp.Settings.StandartAccess}, ExtendedAccess: {cmp.Settings.ExtendedAcces}, Flag1: {cmp.Settings.Flag1}");
        }
    }
}
