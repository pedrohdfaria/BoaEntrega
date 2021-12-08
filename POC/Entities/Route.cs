using POC.Exceptions;
using POC.Mocks;
using System.Collections.Generic;

namespace POC.Controllers.Models
{
    public class Route
    {
        public Coordinate Starting { get; set; }
        public Coordinate Destination { get; set; }
        public List<string> Directions { get; set; }
        public int Fuel { get; set; }
        public int Time { get; set; }

        public Route(Coordinate starting, Coordinate destination)
        {
            Starting = starting;
            Destination = destination;
            ValidateNewRoute();
            Directions = RouteMock.GetMockedDirections(starting,destination);
            Fuel = RouteMock.GetMockedFuel(starting, destination);
            Time = RouteMock.GetMockedTime(starting, destination);
        }

        public void ValidateNewRoute()
        {
            if (Starting.X == Destination.X && Starting.Y == Destination.Y)
                { throw new BoaEntregaException("As coordenadas de origem e destino devem ser diferentes"); }
            if (Starting.X < -90 || Starting.X > 90 || Starting.Y < -180 || Starting.Y > 180)
                { throw new BoaEntregaException("Coordenadas de origem inválidas"); }
            if (Destination.X < -90 || Destination.X > 90 || Destination.Y < -180 || Destination.Y > 180)
                { throw new BoaEntregaException("Coordenadas de destino inválidas"); }
        }
    }
    
}
