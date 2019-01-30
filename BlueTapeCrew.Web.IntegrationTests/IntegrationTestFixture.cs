using System;
using System.Collections.Concurrent;
using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlueTapeCrew.Web.IntegrationTests
{
    [CollectionDefinition("IntegrationTest")]
    public class IntegrationTest : ICollectionFixture<IntegrationTextFixture> { }

    public class IntegrationTextFixture : IDisposable
    {
        public readonly ApplicationDbContext Db;

        //teardown objects
        private readonly ConcurrentBag<object> _objectsToDelete = new ConcurrentBag<object>();

        //fields
        //public Uri ProductionCheckoutUri => ConfigurationStubs.ProductionCheckoutUri;

        public SiteSetting SiteSettings;

        //repositories

        public IntegrationTextFixture()
        {

            var services = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            Db = services.GetRequiredService<ApplicationDbContext>();

            //var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseSqlServer($"Server=localhost\\SQLEXPRESS;Database=btcdb;Trusted_Connection=True;MultipleActiveResultSets=true")
            //    .UseInternalServiceProvider(serviceProvider);

            //Db = new BtcEntities(builder.Options);

            //repos
            //InvoiceRepository = new InvoiceRepository(Db);
            //SiteSettingsRepository = new SiteSettingsRepository(Db);

            //services
            //InvoiceService = new InvoiceService(InvoiceRepository);
            //EmailService = new EmailService();
            //SiteSettingsService = new SiteSettingsService(SiteSettingsRepository);
            //PaypalService = new PaypalService(SiteSettingsService);

            //SiteSettings = SiteSettingsService.Get().Result;
        }

        public void Teardown(object entity)
        {
            _objectsToDelete.Add(entity);
        }

        public void Dispose()
        {
            foreach (var entity in _objectsToDelete)
            {
                switch (entity)
                {
                    case Invoice invoice:
                        //await InvoiceService.Delete(invoice.Id);
                        break;
                }
            }
        }



    }
}