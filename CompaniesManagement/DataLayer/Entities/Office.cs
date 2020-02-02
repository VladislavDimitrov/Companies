using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Office
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public bool Headquarters { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
