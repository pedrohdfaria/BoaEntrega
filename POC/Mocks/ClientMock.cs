using POC.Entities;
using Bogus;
using System;

namespace POC.Mocks
{
    public static class ClientMock
    {
        public static Client GetMockedClient(int id)
        {
            Randomizer.Seed = new Random(id);

            var randomClient = new Faker<Client>(locale: "pt_BR")
                .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Document, f => string.Join("",f.Random.Digits(8)))
                .RuleFor(o => o.FirstOrder, f => DateTime.Now.AddMonths(f.Random.Number(-20, -1)))
                .RuleFor(o => o.BirthDate, f => f.Person.DateOfBirth)
                .RuleFor(o => o.Address, f => f.Address.StreetAddress())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.State, f => f.Address.State());

            var client = randomClient.Generate();

            return client;
        }
        
    }
}
