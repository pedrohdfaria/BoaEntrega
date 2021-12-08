namespace POC.Controllers.Models
{
    public class Route
    {
        public  Coordinate Starting {get; set;}
        public  Coordinate Destination {get; set;}
        public string[] Directions { get; set; }
    }

    
}
