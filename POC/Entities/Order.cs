using POC.Controllers.Models;
using POC.Mocks;
using System;

namespace POC.Entities
{
    public class Order
    {
        public Product Product { get; set; }
        public Client Client { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Coordinate ActualCoordinate { get; set; }
        public Coordinate Destination { get; set; }
        public Uri RealTrackerUrl { get; set; }


        public Order(int id)
        {
            Product = ProductMock.GetMockedProduct(id);
            Client = ClientMock.GetMockedClient(id);
            OrderStatus = OrderStatus.EmRotaParaDestino;
            ActualCoordinate = GlobalPositioningMock.getCoordinateActual(id);
            Destination = GlobalPositioningMock.getDestinationCoordinate(id);
            RealTrackerUrl = GlobalPositioningMock.getRealTrackerUrl(ActualCoordinate);  
        }
    }
}
