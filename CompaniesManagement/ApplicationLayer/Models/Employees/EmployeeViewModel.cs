using DataLayer.Entities;
using System;

namespace ApplicationLayer.Models.Employees
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {

        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartingDate { get; set; }
        public double Salary { get; set; }
        public int VacationDays { get; set; }
        public string ExperienceLevel { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int OfficeID { get; set; }
        public Office Office { get; set; }
    }
}
