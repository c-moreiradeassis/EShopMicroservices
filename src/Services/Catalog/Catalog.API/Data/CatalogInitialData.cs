using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());

            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("f37b7520-a063-4e81-8332-e1e84a6e249f"),
                Name = "IPhone X",
                Description = "This phone is the best one ever.",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string>{"Smart Phone"}
            }
        };
    }
}
