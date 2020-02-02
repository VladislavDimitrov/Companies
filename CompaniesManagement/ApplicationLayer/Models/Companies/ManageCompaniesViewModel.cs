using DataLayer.Entities;
using System.Collections.Generic;

namespace ApplicationLayer.Models.Companies
{
    public class ManageCompaniesViewModel
    {
        public ManageCompaniesViewModel()
        {

        }
        public string Input { get; set; }
        public List<CompanyViewModel> Companies { get; set; } = new List<CompanyViewModel>(50);
    }
}
