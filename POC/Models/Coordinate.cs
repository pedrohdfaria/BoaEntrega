namespace POC.Controllers.Models
{
    public class Coordinate
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Coordinate() { }

        public Coordinate(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}
