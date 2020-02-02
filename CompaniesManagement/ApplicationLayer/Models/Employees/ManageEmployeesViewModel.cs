using System.Collections.Generic;

namespace ApplicationLayer.Models.Employees
{
    public class ManageEmployeesViewModel
    {
        public ManageEmployeesViewModel()
        {
                
        }
        public string Input { get; set; }
        public List<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>(50);
    }
}
