using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlueTapeCrew.Web.IntegrationTests
{
    [Collection("IntegrationTest")]
    public class ProductRepositoryTests
    {
        private readonly IntegrationTextFixture _fixture;

        public ProductRepositoryTests(IntegrationTextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetProducts()
        {
            var products = await _fixture.Db.Products.ToListAsync();
            Assert.True(products.Any());
        }
    }
}
