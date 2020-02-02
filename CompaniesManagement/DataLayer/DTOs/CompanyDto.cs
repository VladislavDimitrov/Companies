using DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationLayer.Utilities.DTOs
{
    public class CompanyDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Office> Offices { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
