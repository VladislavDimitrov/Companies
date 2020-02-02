using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Models.Companies
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {

        }
        public int ID { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public ICollection<Office> Offices { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
