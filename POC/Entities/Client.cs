using System;

namespace POC.Entities
{
    public class Client
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime? FirstOrder { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

}
