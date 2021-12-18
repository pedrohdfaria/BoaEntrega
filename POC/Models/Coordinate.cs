namespace POC.Controllers.Models
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate() { }

        public Coordinate(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
