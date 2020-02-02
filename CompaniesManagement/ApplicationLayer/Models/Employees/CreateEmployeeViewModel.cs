using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Models.Employees
{
    public class CreateEmployeeViewModel
    {
        public CreateEmployeeViewModel()
        {

        }
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public int VacationDays { get; set; }
        [Required]
        public string ExperienceLevel { get; set; }
        [Required]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        [Required]
        public int OfficeID { get; set; }
        public List<SelectListItem> Offices { get; set; } = new List<SelectListItem>();
    }
}
