using Bogus;
using POC.Entities;
using System;

namespace POC.Mocks
{
    public static class ProductMock
    {
        public static Product GetMockedProduct(int id)
        {
            Randomizer.Seed = new Random(id);

            var randomProduct = new Faker<Product>(locale: "pt_BR")
                .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Commerce.Product())
                .RuleFor(o => o.Manufacturer, f => f.Company.CompanyName())
                .RuleFor(o => o.Fragile, f => true)
                .RuleFor(o => o.Size, f => f.PickRandom<Size>())
                .RuleFor(o => o.Price, f => f.Random.Float(0f,9000f));

            var product = randomProduct.Generate();

            return product;
        }
    }
}