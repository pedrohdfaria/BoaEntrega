using POC.Entities;
using Bogus;
using System;
using POC.Controllers.Models;

namespace POC.Mocks
{
    public static class GlobalPositioningMock
    {

        public static Coordinate getCoordinateActual(int id)
        {
            Randomizer.Seed = new Random(id/2+1);

            var randomCoordinate = new Faker<Coordinate>(locale: "pt_BR")
                .StrictMode(true)
                .RuleFor(o => o.X, f => f.Address.Latitude(-30, 0))
                .RuleFor(o => o.Y, f => f.Address.Longitude(-60, -40));

            return randomCoordinate.Generate();
        }

        public static Coordinate getDestinationCoordinate(int id)
        {
            Randomizer.Seed = new Random(id);

            var randomCoordinate = new Faker<Coordinate>(locale: "pt_BR")
                .StrictMode(true)
                .RuleFor(o => o.X, f => f.Address.Latitude(-30, 0))
                .RuleFor(o => o.Y, f => f.Address.Longitude(-60, -40));

            return randomCoordinate.Generate();
        }

        public static Uri getRealTrackerUrl(Coordinate coordinate)
        {
            string x = coordinate.X.ToString();
            string y = coordinate.Y.ToString();

            string urlBase = "https://www.google.com/maps/search/?api=1&query=";
            string url = urlBase + $"{x}.{y}".Replace(",", "&").Replace(".", ",").Replace("&", ".");

            return new Uri(url);
        }

    }
}
